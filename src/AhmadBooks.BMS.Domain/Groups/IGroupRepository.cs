using AhmadBooks.BMS.Groups;
using System;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace AhmadBooks.BMS.Users
{
	public interface IGroupRepository : IRepository<Group, Guid>
	{

	}
}
