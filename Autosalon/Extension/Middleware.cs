using Autosalon.DataAcces.DbContexts;
using Autosalon.DataAcces.IRepository;
using Autosalon.DataAcces.Repository;
using Autosalon.Domain.Entities.Cars;
using Autosalon.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Autosalon.Extension
{
    public static class Middleware
    {
        public static void AddDBConTextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AutosalonDbContext>(option =>
            option.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

            //public static void AddService(this IServiceCollection services)
            //{
            //    services.AddTransient<IFoodService, FoodService>();
            //    services.AddTransient<IOrderInFoodService, OrderInFoodService>();
            //}

            public static void AddRepository(this IServiceCollection services)
            {
                services.AddTransient<IGenericRepository<Car>, GenericRepository<Car>>();
                services.AddTransient<IGenericRepository<User>, GenericRepository<User>>();
            }
    }
}
