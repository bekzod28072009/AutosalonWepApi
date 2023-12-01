using Autosalon.Domain.Entities.Cars;
using Autosalon.Domain.Entities.Users;
using Autosalon.Service.Dto_s;
using System.Linq.Expressions;

namespace Autosalon.Service.Interfaces
{
    public interface ICarService
    {
        IQueryable<Car> GetAll(Expression<Func<Car, bool>> expression, string[] includes = null);
        ValueTask<CarDto> GetAsync(Expression<Func<Car, bool>> expression, string[] includes = null);
        ValueTask<CarDto> CreateAsync(CarDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Car, bool>> expression);
        CarDto Update(int id, CarDto entity);
    }
}
