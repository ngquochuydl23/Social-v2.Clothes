
using Social_v2.Clothes.Api.Extensions;
using Social_v2.Clothes.Api.Infrastructure.Repository;
using Social_v2.Clothes.Api.Infrastructure;
using Clothes.Commons;

namespace Social_v2.Clothes.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
               .AddWebApiConfiguration(builder.Configuration)
               .AddDbContext<ClothesDbContext>(builder.Configuration)
               .AddAutoMapperConfig<AutoMapperProfile>();

            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(x => x
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.AddCommonApplicationBuilder();
            app.Run();
        }
    }
}