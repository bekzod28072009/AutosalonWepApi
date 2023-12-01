using Autosalon.Domain.Entities.Users;
using Autosalon.Service.Dto_s;
using System.Linq.Expressions;

namespace Autosalon.Service.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetAll(Expression<Func<User, bool>> expression, string[] includes = null);
        ValueTask<UserDto> GetAsync(Expression<Func<User, bool>> expression, string[] includes = null);
        ValueTask<UserDto> CreateAsync(UserDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        UserDto Update(int id, UserDto entity);
    }
}
