using AhmadBooks.BMS.Groups;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AhmadBooks.BMS.Books
{
    public class Book : AggregateRoot<Guid>
    {
        public string Title { get; protected set; }
        public string Author { get; protected set; }
        public BookStatus Status { get; protected set; }
        public Guid OwnerId { get; protected set; }
        public List<Group> AssignedGroups { get; protected set; }
    }
}
