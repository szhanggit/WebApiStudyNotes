using AutoMapper;
using IdentityBasicEx.Models;

namespace IdentityBasicEx
{
    public class MappingProfile : Profile
    {
		public MappingProfile()
		{
			CreateMap<UserForRegistrationDto, User>();
		}
	}
}
