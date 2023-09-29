using AhmadBooks.BMS.Groups;
using AutoMapper;
using System.Collections.Generic;

namespace AhmadBooks.BMS;

public class BMSApplicationAutoMapperProfile : Profile
{
    public BMSApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Group, GroupDto>();
        //CreateMap<List<Group>, List<GroupDto>>();
    }
}
