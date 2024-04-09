
using Clothes.Commons;
using Clothes.Order.Api.Extensions;
using Clothes.Order.Api.Infrastructure;

namespace Clothes.Order.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
               .AddWebApiConfiguration(builder.Configuration)
               .AddDbContext<ClothesOrderContext>(builder.Configuration)
               .AddAutoMapperConfig<AutoMapperProfile>();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.AddCommonApplicationBuilder();
            app.Run();
        }
    }
}
