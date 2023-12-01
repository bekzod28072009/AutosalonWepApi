using Autosalon.Domain.Entities.Cars;
using Autosalon.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Autosalon.DataAcces.DbContexts
{
    public class AutosalonDbContext : DbContext
    {
        public AutosalonDbContext(DbContextOptions<AutosalonDbContext> options) : base(options) 
        { }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}
