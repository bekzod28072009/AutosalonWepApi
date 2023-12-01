using Autosalon.DataAcces.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Autosalon.Extension
{
    public static class Middleware
    {
        public static void AddDBConTextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AutosalonDbContext>(option =>
            option.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
