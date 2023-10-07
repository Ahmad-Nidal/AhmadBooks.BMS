using AhmadBooks.BMS.Members;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AhmadBooks.BMS.Groups
{
    public interface IPublicGroupAppService
    {
        Task<Members.GroupDto> GetGroupAsync(Guid id);
        Task EnrollToGroup(Guid id);
        Task UnenrollFromGroup(Guid id);
        Task<List<MemberDto>> GetGroupMembers(Guid id);
    }
}