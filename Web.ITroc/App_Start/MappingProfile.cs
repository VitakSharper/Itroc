using AutoMapper;
using Web.ITroc.Core.Models;
using Web.ITroc.Core.ViewModels;

namespace Web.ITroc.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ads, AdsToIndexViewModel>();
        }
    }
}