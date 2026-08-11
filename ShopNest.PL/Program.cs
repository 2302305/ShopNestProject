using Microsoft.EntityFrameworkCore;
using ShopNest.API.Extensions;
using ShopNest.Domain.Contracts;
using ShopNest.Domain.Contracts.Initialization;
using ShopNest.Presistence.Data.DataSeeding;
using ShopNest.Presistence.Data.DbContexts;
using ShopNest.Presistence.Repositories;
using ShopNest.Services.Abstraction.Services;
using ShopNet.Services.MappingProfiles;
using ShopNet.Services.ServicesImplementation;

namespace ShopNest.PL
{
    public class Program
    { //SEPERATION OF CONCERNS AND OPEN FOR EXTENSION CLOSE FOR MODIFICATION
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Services Registration

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IDataInitializer, DataInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductService, ProductService>();
            //Imapper 15 License in production
            //builder.Services.AddAutoMapper(l => l.LicenseKey = "", typeof(ProductProfile).Assembly);
            //Imapper 14 No License Required in Production niether development
            builder.Services.AddAutoMapper(typeof(ServiceAssemblyMarker).Assembly);
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion
            #region DI Container Building -> IService Provider
            var app = builder.Build();
            await app.MigrateDataBaseAsync();
            await app.SeedDataAsync();
            #endregion

            #region Pipeline Configuration -> Middlewares Sequence
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            await app.RunAsync();
        }
    }
}
