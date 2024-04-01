
using Clothes.Commons;
using Clothes.User.Api.Extensions;
using Clothes.User.Api.Infrastucture;

namespace Clothes.User.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
               .AddWebApiConfiguration(builder.Configuration)
               .AddDbContext<ClothesUserContext>(builder.Configuration)
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
