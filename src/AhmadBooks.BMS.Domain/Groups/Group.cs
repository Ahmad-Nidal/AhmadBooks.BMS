using System;
using System.Collections.Generic;
using AhmadBooks.BMS.Books;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace AhmadBooks.BMS.Groups
{
    public class Group : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public List<IdentityUser> Members { get; set; }
    }
}
