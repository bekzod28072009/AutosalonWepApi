using AutoMapper;
using Autosalon.DataAcces.IRepository;
using Autosalon.Domain.Entities.Cars;
using Autosalon.Domain.Entities.Users;
using Autosalon.Service.Dto_s;
using Autosalon.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> repository;
        private readonly IMapper mapper;
        public UserService(IMapper mapper,
            IGenericRepository<User> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async ValueTask<UserDto> CreateAsync(UserDto entity)
        {
            var user = new User();
            if (entity is not null)
            {
                var newUser = mapper.Map<User>(entity);
                user = await repository.CreateAsync(newUser);
            }
            repository.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            bool result = await repository.DeleteAsync(expression);
            await repository.SaveChangesAsync();
            return result;
        }

        public IQueryable<User> GetAll(Expression<Func<User, bool>> expression, string[] includes = null)
            => repository.GetAll(expression, includes);

        public async ValueTask<UserDto> GetAsync(Expression<Func<User, bool>> expression, string[] includes = null)
        {
            var user = await repository.GetAsync(expression, includes);
            return mapper.Map<UserDto>(user);
        }

        public UserDto Update(int id, UserDto entity)
        {
            var user = mapper.Map<User>(entity);
            user.Id = id;
            var newUser = repository.Update(user);
            return mapper.Map<UserDto>(newUser);
        }
    }
}
