using AhmadBooks.BMS.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AhmadBooks.BMS.Groups
{
    public class EfCoreGroupRepository
        : EfCoreRepository<BMSDbContext, Group, Guid>,
            IGroupRepository
    {
        public EfCoreGroupRepository(
            IDbContextProvider<BMSDbContext>  dbContextProvider)
            : base(dbContextProvider)
        {
            
        }

        public async Task<Group> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(group => group.Name == name);
        }

        public async Task<List<Group>> GetListAsync(
            int skipCount, 
            int maxResultCount, 
            string sorting, 
            string? filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    group => group.Name.Contains(filter)
                    )
                .Skip(skipCount)
                .Take(maxResultCount)
                .OrderBy(sorting)
                .ToListAsync();
        }
    }
}
