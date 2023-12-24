
using Social_v2.Clothes.Api.Extensions;
using Social_v2.Clothes.Api.Infrastructure.Repository;
using Social_v2.Clothes.Api.Middlewares;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Social_v2.Clothes.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
              .AddControllers()
              .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();
            builder.Services
                    .AddForwardHeader()
                    .AddDefaultOpenApi(builder.Configuration)
                    .AddDefaultAuthentication(builder.Configuration)
                    .AddDbContext(builder.Configuration)
                    .AddLogger(builder.Configuration)
                    .AddJwtExtension(builder.Configuration)
                    .AddAutoMapperConfig()
                    .AddEmailSender(builder.Configuration);

            builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}
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
        }
    }
}