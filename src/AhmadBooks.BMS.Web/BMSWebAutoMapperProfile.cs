using AhmadBooks.BMS.Groups;
using AhmadBooks.BMS.Web.ViewModels.Groups;
using AutoMapper;

namespace AhmadBooks.BMS.Web;

public class BMSWebAutoMapperProfile : Profile
{
    public BMSWebAutoMapperProfile()
    {
        CreateMap<UpdateGroupViewModel, UpdateGroupDto>();
        CreateMap<GroupDto, UpdateGroupViewModel>();
        CreateMap<CreateGroupViewModel, CreateGroupDto>();
    }
}
