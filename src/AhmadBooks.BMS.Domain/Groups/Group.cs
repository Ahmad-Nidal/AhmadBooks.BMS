using System;
using System.Collections.Generic;
using AhmadBooks.BMS.Books;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace AhmadBooks.BMS.Groups
{
    public class Group : FullAuditedAggregateRoot<Guid>
    {
        // TODO: OwnerId (the creator of the group)
        public string Name { get; protected set; }
        public GroupStatus Status { get; protected set; }
        public List<Book> Books { get; protected set; }
        public List<IdentityUser> Members { get; protected set; }


        private Group()
        {

        }
        public Group(
            Guid id,
            [NotNull] string name)
        {
            Id = id;
            SetName(name);
            Members = new List<IdentityUser>();
        }

        public Group SetName([NotNull] string name)
        {

            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: GroupConsts.MaxNameLength
            );
            return this;
        }
    }
}
