using JetBrains.Annotations;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace AhmadBooks.BMS.Groups
{
    public class GroupManager : DomainService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupManager(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Group> CreateAsync(
            [NotNull] string name)
        {
            var existingGroup = await _groupRepository.FindByNameAsync(name);
            if (existingGroup != null)
            {
                throw new GroupAlreadyExistsException(name);
            }

            return new Group(
                GuidGenerator.Create(),
                name
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Group group,
            [NotNull] string name)
        {
            var existingGroup = await _groupRepository.FindByNameAsync(name);
            if (existingGroup is not null && existingGroup.Id != group.Id)
            {
                throw new GroupAlreadyExistsException(name);
            }

            group.ChangeName(name);
        }
    }
}
