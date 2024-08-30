using AutoMapper;
using ticketSystem.DTOs.Bug;
using ticketSystem.Models;

namespace ticketSystem.Profiles
{
    public class BugProfile : Profile
    {
        public BugProfile()
        {
            CreateMap<Bug,bugDto>()
                .ForMember(dest => dest.bugId, src => src.MapFrom(x => x.bugId))
                .ForMember(dest => dest.bugName,src => src.MapFrom(x => x.bugName))
                .ForMember(dest => dest.bugDescription, src => src.MapFrom(x => x.bugDescription))
                .ForMember(dest => dest.bugSummery, src => src.MapFrom(x => x.bugSummery))
                .ForMember(dest => dest.bugSeverity, src => src.MapFrom(x => x.bugSeverity))
                .ForMember(dest => dest.bugStatus, src => src.MapFrom(x => x.bugSeverity));
        }
    }
    public class CreateBugProfile : Profile
    {
        public CreateBugProfile()
        {
            CreateMap<CreateBugDto,Bug>()
                .ForMember(dest => dest.bugName, src => src.MapFrom(x => x.bugName))
                .ForMember(dest => dest.bugDescription, src => src.MapFrom(x => x.bugDescription))
                .ForMember(dest => dest.bugSummery, src => src.MapFrom(x => x.bugSummery))
                .ForMember(dest => dest.bugSeverity, src => src.MapFrom(x => x.bugSeverity))
                .ForMember(dest => dest.bugStatus, src => src.MapFrom(x => x.bugSeverity));
        }
    }
    public class EditBugProfile : Profile
    {
        public EditBugProfile()
        {
            CreateMap<EditBugDto,Bug>()
                .ForMember(dest => dest.bugSeverity, src => src.MapFrom(x => x.bugSeverity))
                .ForMember(dest => dest.bugStatus, src => src.MapFrom(x => x.bugStatus));
        }
    }
}
