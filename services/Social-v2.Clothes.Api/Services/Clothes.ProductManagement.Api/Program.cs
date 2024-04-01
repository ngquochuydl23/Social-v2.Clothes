
using Clothes.Commons;
using Clothes.Commons.Seedworks;
using Clothes.ProductManagement.Api.Extensions;
using Clothes.ProductManagement.Api.Infrastructure;
using Newtonsoft.Json;

namespace Clothes.ProductManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
               .AddWebApiConfiguration(builder.Configuration)
               .AddDbContext<ClothesProductContext>(builder.Configuration)
               .AddAutoMapperConfig<AutoMapperProfile>();

            var app = builder.Build();
            if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.AddCommonApplicationBuilder();
            app.Run();
        }
    }
}