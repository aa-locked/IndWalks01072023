using AutoMapper;
using IndWalks.API.Model.Domain;
using IndWalks.API.Model.DTO;
using IndWalks.API.Model.DTO.Walks;

namespace IndWalks.API.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddWalkRequestDTO, Walk>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<Difficulty,DiffcultyDTO>().ReverseMap();
            CreateMap<UpdateWalkReqDTO, Walk>().ReverseMap();   
        }
    }
}
