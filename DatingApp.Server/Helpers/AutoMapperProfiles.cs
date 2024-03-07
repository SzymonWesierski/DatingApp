using AutoMapper;
using DatingApp.Server.DTOs;
using DatingApp.Server.Entities;
using DatingApp.Server.Extensions;

namespace DatingApp.Server.Helpers
{
	public class AutoMapperProfiles : Profile
	{
        public AutoMapperProfiles()
        {
			CreateMap<AppUser, MemberDto>()
				.ForMember(dest => dest.PhotoUrl,
				opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain == true).Url))
				.ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
			CreateMap<Photo, PhotoDto>();
			CreateMap<MemberUpdateDto, AppUser>();
			CreateMap<RegisterDto, AppUser>();
		}
    }
}
