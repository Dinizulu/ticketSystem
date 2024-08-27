using AutoMapper;
using ticketSystem.DTOs.User;
using ticketSystem.Models;

namespace ticketSystem.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserResponse>()
                .ForMember(dest => dest.userId,src => src.MapFrom(x => x.userId))
                .ForMember(dest => dest.Role, src => src.MapFrom(x => x.Role))
                .ForMember(dest => dest.fullName,src => src.MapFrom(x => x.firstName+" "+x.lastName))
                .ForMember(dest => dest.email,src => src.MapFrom(x => x.email));
            CreateMap<User, UserResponse>();
        }
    }

    public class CreateUserProfile : Profile
    {
        public CreateUserProfile()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Role, src => src.MapFrom(x => x.Role))
                .ForMember(dest => dest.firstName, src => src.MapFrom(x => x.firstName))
                .ForMember(dest => dest.lastName, src => src.MapFrom(x => x.lastName))
                .ForMember(dest => dest.email, src => src.MapFrom(x => x.email))
                .ForMember(dest => dest.password, src => src.MapFrom(x => x.password));
        }
    }
}
