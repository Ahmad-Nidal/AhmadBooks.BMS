using AhmadBooks.BMS.Groups;
using AutoMapper;
using Volo.Abp.Identity;

namespace AhmadBooks.BMS;

public class BMSApplicationAutoMapperProfile : Profile
{
    public BMSApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Group, GroupDto>();
        //.ForMember(dest => dest.MembersCount, opt => opt.MapFrom(src => src.Members.Count));
        //TODO: add event on group enrollment to update members count instead of using this method
        //CreateMap<List<Group>, List<GroupDto>>();

        CreateMap<IdentityUser, Members.MemberDto>();
        CreateMap<Group, Members.GroupDto>();
        CreateMap<Members.GroupDto, Group>();
    }
}
