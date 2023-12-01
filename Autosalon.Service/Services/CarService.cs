using AutoMapper;
using Autosalon.DataAcces.IRepository;
using Autosalon.Domain.Entities.Cars;
using Autosalon.Service.Dto_s;
using Autosalon.Service.Interfaces;
using System.Linq.Expressions;

namespace Autosalon.Service.Services
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> repository;
        private readonly IMapper mapper;
        public CarService(IMapper mapper,
            IGenericRepository<Car> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async ValueTask<CarDto> CreateAsync(CarDto entity)
        {
            var car = new Car();
            if(entity is not null)
            {
                var newCar = mapper.Map<Car>(entity);
                car = await repository.CreateAsync(newCar);
            }
            repository.SaveChangesAsync();
            return mapper.Map<CarDto>(car);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Car, bool>> expression)
        {
            bool result = await repository.DeleteAsync(expression);
            await repository.SaveChangesAsync();
            return result;
        }

        public IQueryable<Car> GetAll(Expression<Func<Car, bool>> expression, string[] includes = null)
            => repository.GetAll(expression, includes);

        public async ValueTask<CarDto> GetAsync(Expression<Func<Car, bool>> expression, string[] includes = null)
        {
            var car = await repository.GetAsync(expression, includes);
            return mapper.Map<CarDto>(car);
        }

        public CarDto Update(int id, CarDto entity)
        {
            var car = mapper.Map<Car>(entity);
            car.Id = id;
            var newCar = repository.Update(car);
            return mapper.Map<CarDto>(newCar);
        }
    }
}
