using AhmadBooks.BMS.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace AhmadBooks.BMS.Groups
{
    public class PublicGroupAppService : BMSAppService, IPublicGroupAppService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IIdentityUserRepository _userRepository;

        public PublicGroupAppService(
            IGroupRepository groupRepository, 
            IIdentityUserRepository userRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }

        public async Task EnrollToGroup(Guid id)
        {
            var userId = CurrentUser.GetId();

            var groupDto = await GetGroupAsync(id);
            if (groupDto.Members.Any(m => m.Id == userId))
            {
                throw new UserFriendlyException("Member already exists");
            }

            var group = await _groupRepository.GetAsync(id);
            var user = await _userRepository.GetAsync(userId);
            group.Members.Add(user);

            await _groupRepository.UpdateAsync(group);
        }

        public async Task<Members.GroupDto> GetGroupAsync(Guid id)
        {
            var group = await _groupRepository.GetInculdeMembersAsync(id);
            // TODO: Check if not exists
            var groupDto = ObjectMapper.Map<Group, Members.GroupDto>(group);
            return groupDto;
        }

        public async Task<List<MemberDto>> GetGroupMembers(Guid id)
        {
            var group = await GetGroupAsync(id);
            return group.Members;
        }

        public async Task UnenrollFromGroup(Guid id)
        {
            var userId = CurrentUser.GetId();

            var groupDto = await GetGroupAsync(id);
            if (!groupDto.Members.Any(m => m.Id == userId))
            {
                throw new UserFriendlyException("Member is not enrolled to the group");
            }

            var group = await _groupRepository.GetAsync(id);
            var user = await _userRepository.GetAsync(userId);
            group.Members.Remove(user);

            await _groupRepository.UpdateAsync(group);
        }

        public async Task<bool> IsEnrolled(Guid groupId, Guid userId = default)
        {
            if (userId == default)
            {
                userId = CurrentUser.GetId();
            }

            var groupDto = await GetGroupAsync(groupId);
            
            return groupDto.Members.Any(m => m.Id == userId);
        }
    }
}
