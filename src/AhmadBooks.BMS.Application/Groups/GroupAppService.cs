using AhmadBooks.BMS.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace AhmadBooks.BMS.Groups
{
    [Authorize(BMSPermissions.Groups.Default)]
    public class GroupAppService : BMSAppService, IGroupAppService
    {
        private readonly GroupManager _groupManager;
        private readonly IGroupRepository _groupRepository;

        public GroupAppService(
            GroupManager groupManager,
            IGroupRepository groupRepository)
        {
            _groupManager = groupManager;
            _groupRepository = groupRepository;
        }

        [Authorize(BMSPermissions.Groups.Create)]
        public async Task<GroupDto> CreateAsync(CreateUpdateGroupDto input)
        {
            var group = await _groupManager.CreateAsync(
                input.Name
            );

            await _groupRepository.InsertAsync(group);

            return ObjectMapper.Map<Group, GroupDto>(group);
        }

        public async Task<GroupDto> GetAsync(Guid id)
        {
            var group = await _groupRepository.GetAsync(id);
            return ObjectMapper.Map<Group, GroupDto>(group);
        }

        public async Task<PagedResultDto<GroupDto>> GetListAsync(GetGroupListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Group.Name);
            }

            var groups = await _groupRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter is null
                ? await _groupRepository.CountAsync()
                : await _groupRepository.CountAsync(
                    group => group.Name.Contains(input.Filter)
            );

            return new PagedResultDto<GroupDto>(
                totalCount,
                ObjectMapper.Map<List<Group>, List<GroupDto>>(groups)
            );
        }

        [Authorize(BMSPermissions.Groups.Edit)]
        public async Task<GroupDto> UpdateAsync(Guid id, CreateUpdateGroupDto input)
        {
            var group = await _groupRepository.GetAsync(id) 
                ?? throw new EntityNotFoundException(typeof(Group), id);

            if (group.Name != input.Name)
            {
                await _groupManager.ChangeNameAsync(group, input.Name);
            }

            await _groupRepository.UpdateAsync(group);
            return ObjectMapper.Map<Group, GroupDto>(group);
        }

        [Authorize(BMSPermissions.Groups.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            var group = await _groupRepository.GetAsync(id)
                ?? throw new EntityNotFoundException(typeof(Group), id);

            await _groupRepository.DeleteAsync(group);
        }
    }
}
