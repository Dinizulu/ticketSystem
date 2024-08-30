using AutoMapper;
using ticketSystem.DTOs.Feature;
using ticketSystem.Models;

namespace ticketSystem.Profiles
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature,FeatureDto>()
                .ForMember(dest => dest.featureId, src => src.MapFrom(x => x.featureId))
                .ForMember(dest => dest.featureName, src => src.MapFrom(x => x.featureName))
                .ForMember(dest => dest.featureDescription, src => src.MapFrom(x => x.featureDescription))
                .ForMember(dest => dest.featureSummery, src => src.MapFrom(x => x.featureSummery))
                .ForMember(dest => dest.featureStatus, src => src.MapFrom(x => x.featureStatus));
        }
    }
    public class CreateFeatureProfile : Profile
    {
        public CreateFeatureProfile()
        {
            CreateMap<CreateFeatureDto,Feature>()
                .ForMember(dest => dest.featureName, src => src.MapFrom(x => x.featureName))
                .ForMember(dest => dest.featureDescription, src => src.MapFrom(x => x.featureDescription))
                .ForMember(dest => dest.featureSummery, src => src.MapFrom(x => x.featureSummery))
                .ForMember(dest => dest.featureStatus, src => src.MapFrom(x => x.featureStatus));
        }
    }
    public class EditFeatureProfile : Profile
    {
        public EditFeatureProfile()
        {
            CreateMap<EditFeatureDto, Feature>()
                .ForMember(dest => dest.featureStatus, src => src.MapFrom(x => x.featureStatus));
        }
    }
}
