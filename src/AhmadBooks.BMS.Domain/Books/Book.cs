using AhmadBooks.BMS.Groups;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AhmadBooks.BMS.Books
{
    public class Book : AggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Guid OwnerId { get; set; }
        public List<Group> Groups { get; set; }
    }
}
