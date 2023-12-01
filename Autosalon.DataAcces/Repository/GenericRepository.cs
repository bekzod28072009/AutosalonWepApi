using Autosalon.DataAcces.DbContexts;
using Autosalon.DataAcces.IRepository;
using Autosalon.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Autosalon.DataAcces.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        private readonly AutosalonDbContext dbContext;
        private readonly DbSet<T> dbSet;
        public GenericRepository(AutosalonDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }
        public async ValueTask<T> CreateAsync(T entity) =>
            (await dbContext.AddAsync(entity)).Entity;

        public async ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await GetAsync(expression);

            if (entity == null) 
                return false;

            dbSet.Remove(entity);
            return true;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            IQueryable<T> query = expression is null? dbSet: dbSet.Where(expression);

            if(includes != null)
                foreach(var include in includes)
                    if(!string.IsNullOrEmpty(include))
                        query = query.Include(include);
            return query;
        }

        public async ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null)
            => await dbSet.Where(expression).FirstOrDefaultAsync();

        public async ValueTask SaveChangesAsync()
           => await dbContext.SaveChangesAsync();

        public T Update(T entity) 
            => dbSet.Update(entity).Entity;
    }
}
