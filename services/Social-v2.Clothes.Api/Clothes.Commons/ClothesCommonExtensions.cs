using AutoMapper;
using Clothes.Commons.Seedworks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Logging;
using Clothes.Commons.Middlewares;
using Clothes.Commons.Settings.JwtSetting;
using Microsoft.Extensions.Hosting;
using Redis.OM;
using IdentityServer4.AccessTokenValidation;
using OpenIddict.Client;

namespace Clothes.Commons
{
    public static class ClothesCommonExtensions
    {
        public static IServiceCollection AddWebApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services
                 .AddControllers()
                 .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddCors();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            services
                 .AddTransient<IHttpContextAccessor, HttpContextAccessor>()
                 .AddDefaultOpenApi(configuration)
                 .AddDefaultAuthentication(configuration)
                 .AddLogger(configuration)
                 .AddJwtExtension(configuration)
                 .AddRedisConfiguration(configuration);
            return services;
        }

        public static IServiceCollection AddDbContext<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            services.AddDbContext<T>(x => x.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

            services.AddScoped<DbContext, T>();
            services.AddTransient(typeof(IEfRepository<,>), typeof(EfRepository<,>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddAutoMapperConfig<TProfile>(this IServiceCollection services) where TProfile : Profile
        {
            services.AddAutoMapper(typeof(TProfile).Assembly);
            return services;
        }
        public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("Seq");
            if (!section.Exists())
                return services;

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSeq(section);
            });
            return services;
        }

        public static IServiceCollection AddDefaultOpenApi(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("OpenApi");
            if (!section.Exists())
                return services;

            var document = section.GetRequiredSection("Document");

            if (!document.Exists())
                return services;

            var version = document.GetRequiredValue("Version") ?? "v1";
            var title = document.GetRequiredValue("Title");
            var description = document.GetRequiredValue("Description");

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = title,
                    Version = version,
                    Description = description
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                      {
                        new OpenApiSecurityScheme
                        {
                          Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
                          new string[] {}
                        }
                    });
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
            return services;
        }

        public static IServiceCollection AddDefaultAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("Identity");
            if (!section.Exists())
            {
                return services;
            }
            var apiName = section.GetRequiredValue("ApiName");
            var authority = section.GetRequiredValue("Authority");

            services
                .AddOpenIddict()
                .AddClient(options =>
                {
                    // Allow grant_type=client_credentials to be negotiated.
                    options.AllowClientCredentialsFlow();

                    // Disable token storage, which is not necessary for non-interactive flows like
                    // grant_type=password, grant_type=client_credentials or grant_type=refresh_token.
                    options.DisableTokenStorage();

                    options.UseSystemNetHttp();

                    // Add a client registration with the client identifier and secrets issued by the server.
                    options.AddRegistration(new OpenIddictClientRegistration
                    {
                        Issuer = new Uri("https://localhost:5002/", UriKind.Absolute),
                        ClientId = "service-worker",
                        ClientSecret = "388D45FA-B36B-4988-BA59-B187D329C207"
                    });
                });
            return services;
        }

        public static IServiceCollection AddJwtExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("Identity");
            if (!section.Exists())
                return services;

            services.Configure<JwtSettings>(section);
            services.AddSingleton<IJwtExtension, JwtExtension>();
            return services;
        }

        public static IServiceCollection AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("Redis");
            if (!section.Exists())
                return services;

            var redisConnectionString = section.GetRequiredValue("Title");
            services.AddSingleton(new RedisConnectionProvider(configuration[redisConnectionString]));
            services.AddTransient(typeof(IRedisRepository<,>), typeof(RedisRepository<,>));
            return services;
        }


        public static IApplicationBuilder AddCommonApplicationBuilder(this WebApplication app)
        {
            if (!app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseMiddleware<ErrorHandlingMiddleWare>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            return app;
        }

        private static string GetRequiredValue(this IConfiguration configuration, string name) =>
            configuration[name] ?? throw new InvalidOperationException($"Configuration missing value for: {(configuration is IConfigurationSection s ? s.Path + ":" + name : name)}");
    }
}