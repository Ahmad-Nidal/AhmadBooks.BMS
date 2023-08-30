using AhmadBooks.BMS.Groups;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace AhmadBooks.BMS.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public List<Group> Groups { get; set; }
    }
}
