using Social_v2.Clothes.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Social_v2.Clothes.Api.Extensions.JwtHelpers;
using Microsoft.Extensions.Options;
using Social_v2.Clothes.Api.Extensions.EmailSender;
using Mailjet.Client;
using Microsoft.Extensions.Configuration;

namespace Social_v2.Clothes.Api.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddJwtExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("Identifier"));
            services.AddSingleton<IJwtExtension, JwtExtension>();
            return services;
        }

        public static IServiceCollection AddForwardHeader(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            return services;
        }

        public static IServiceCollection AddDefaultOpenApi(this IServiceCollection services, IConfiguration configuration)
        {
            var openApi = configuration.GetSection("OpenApi");

            if (!openApi.Exists())
                return services;

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                var document = openApi.GetRequiredSection("Document");
                var version = document.GetRequiredValue("Version") ?? "v1";

                options.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = document.GetRequiredValue("Title"),
                    Version = version,
                    Description = document.GetRequiredValue("Description")
                });


                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
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

            var identifierSection = configuration.GetSection("Identifier");


            if (!identifierSection.Exists())
            {
                // No identity section, so no authentication
                return services;
            }

            services
              .AddAuthentication(option =>
              {
                  option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                  option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(options =>
              {
                  var issuer = identifierSection.GetRequiredValue("Issuer");
                  var audience = identifierSection.GetRequiredValue("Audience");
                  var secretKey = identifierSection.GetRequiredValue("SecretKey");

                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = issuer,
                      ValidAudience = audience,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                  };
              });
            return services;
        }


        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClothesDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            return services;
        }

        public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddLogging(loggingBuilder =>
            //{
            //  loggingBuilder.AddSeq(configuration.GetSection("Seq"));
            //});
            return services;
        }

        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            return services;
        }

        public static IServiceCollection AddEmailSender(this IServiceCollection services, IConfiguration configuration)
        {
            var mailJet = configuration.GetSection("MailJet");

            if (!mailJet.Exists())
                return services;


            var privateKey = mailJet.GetRequiredValue("privateKey");
            var publicKey = mailJet.GetRequiredValue("publicKey");


            services.AddHttpClient<IMailjetClient, MailjetClient>(client =>
            {
                client.SetDefaultSettings();
                client.UseBasicAuthentication(publicKey, privateKey);
            });

            services.AddSingleton<IEmailSender, EmailSenderImpl>();
            return services;
        }
    }
}
