using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhmadBooks.BMS.Groups;
using Volo.Abp.Identity;

namespace AhmadBooks.BMS.Enrollment
{
    public interface IEnrollmentManager
    {
        Task EnrollUserToGroup(Guid userId, Guid groupId);
        Task UnenrollUserToGroup(Guid userId, Guid groupId);
        Task<ICollection<IdentityUser>> GetGroupMembers(Guid groupId);
        Task<ICollection<Group>> GetUserGroups(Guid userId);
    }
}
