using AutoMapper;
using Autosalon.Domain.Entities.Cars;
using Autosalon.Domain.Entities.Users;
using Autosalon.Service.Dto_s;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Autosalon.Configuration
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
