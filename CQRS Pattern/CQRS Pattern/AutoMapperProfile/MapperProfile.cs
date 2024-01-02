using AutoMapper;
using CQRS_Pattern.DAL.Entities;
using CQRS_Pattern.DTOs;

namespace CQRS_Pattern.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
        }
    }
}
