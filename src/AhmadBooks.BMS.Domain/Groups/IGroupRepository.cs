using AhmadBooks.BMS.Groups;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace AhmadBooks.BMS.Groups
{
	public interface IGroupRepository : IRepository<Group, Guid>
	{
        Task<Group> FindByNameAsync(string name);

        //Task<List<Group>> GetListAsync(
        //    int skipCount,
        //    int maxResultCount,
        //    string sorting,
        //    string? filter = null
        //);
    }
}
