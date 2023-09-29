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
        public string Name { get; private set; }
        public List<Book> Books { get; set; }
        public List<IdentityUser> Members { get; set; }


        private Group()
        {

        }
        internal Group(
            Guid id,
            [NotNull] string name)
        {
            Id = id;
            SetName(name);
        }

        internal Group ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: GroupConsts.MaxNameLength
            );
        }
    }
}
