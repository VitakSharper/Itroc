using AutoMapper;
using Web.ITroc.Core.Dtos;
using Web.ITroc.Core.Models;

namespace Web.ITroc.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Codepostal, PostalCodeDto>();
        }
    }
}