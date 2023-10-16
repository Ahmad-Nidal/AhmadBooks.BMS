using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadBooks.BMS.Groups
{
    public interface IGroupManager
    {
        Task<Group> CreatAsync(Group group);
        Task DeleteAsync(Guid id);
        Task<Group> GetAsync(Guid id);
        Task<ICollection<Group>> GetAllAsync();
        Task CloseGroup(Guid id);
        Task OpenGroup(Guid id);
    }
}
