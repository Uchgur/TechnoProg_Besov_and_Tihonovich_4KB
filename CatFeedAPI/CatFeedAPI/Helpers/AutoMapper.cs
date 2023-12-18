using AutoMapper;
using CatFeedAPI.DTOs;
using CatFeedAPI.Entities;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite.Geometries;

namespace CatFeedAPI.Helpers
{
    public class AutoMapper: Profile
    {
        public AutoMapper() 
        {
            CreateMap<FeederDTO, Feeder>().ReverseMap();
            CreateMap<FeederCreationDTO, Feeder>();

            CreateMap<ApplicationUser, UserDTO>();

            CreateMap<LogCreationDTO, Log>();
            CreateMap<LogDTO, Log>().ReverseMap();
        }
    }
}
