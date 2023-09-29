using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AhmadBooks.BMS.Groups
{
    public interface IGroupAppService : IApplicationService
    {        
        Task<GroupDto> GetAsync(Guid id);
        Task<PagedResultDto<GroupDto>> GetListAsync(GetGroupListDto input);
        Task<GroupDto> CreateAsync(CreateGroupDto input);
        Task<GroupDto> UpdateAsync(Guid id, UpdateGroupDto input);
        Task DeleteAsync(Guid id);
    }
}
