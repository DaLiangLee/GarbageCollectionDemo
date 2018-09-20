using AutoMapper;
using Tv.Models;
using Tv.ViewModels;
using Garbage.Models;
using Garbage.ViewModels;

namespace Tv.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TvNetwork, TvNetworkViewModel>();
            CreateMap<TvShow, TvShowViewModel>();
            CreateMap<GCCategory, GCSubCategoryViewModel>();
            CreateMap<GCSubCategory, GCSubCategoryViewModel>();
        }
    }
}