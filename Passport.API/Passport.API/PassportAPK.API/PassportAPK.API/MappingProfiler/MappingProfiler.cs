using AutoMapper;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;

namespace PassportAPK.API.MappingProfiler
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            // CreateMap(Source, Destination);
            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            CreateMap<ServiceRequired, ServiceRequiredDTO>().ReverseMap();
            CreateMap<ApplicantDetails,ApplicantDetailsDTO>().ReverseMap();
            CreateMap<FamilyDetails,FamilyDetailsDTO>().ReverseMap();
            CreateMap<ResidentailDetails,ResidentailDetailsDTO>().ReverseMap();
            CreateMap<EmergencyContactDetails,EmergencyContactDetailsDTO>().ReverseMap();
            CreateMap<OtherDetails,OtherDetailsDTO>().ReverseMap();
            CreateMap<SelfDeclaration,SelfDeclarationDTO>().ReverseMap();
            CreateMap<MasterDetailsTable,MasterDetailsTableDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
            CreateMap<MasterDetailsTable, UpdatePassportDataDTO>();
        }
    }
}
