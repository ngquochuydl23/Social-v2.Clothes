
using Clothes.Commons;
using Clothes.ProductManagement.Api.Extensions;
using Clothes.ProductManagement.Api.Infrastructure;

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
            app.AddCommonApplicationBuilder();
            app.Run();
        }
    }
}