using Autosalon.Domain.Commons;
using System.Linq.Expressions;

namespace Autosalon.DataAcces.IRepository
{
    public interface IGenericRepository<T> where T : Auditable
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null);
        ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null);
        ValueTask<T> CreateAsync(T entity);
        ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        T Update(T entity);
        public ValueTask SaveChangesAsync();
    }
}
