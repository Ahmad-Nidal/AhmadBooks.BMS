using System;
using System.Collections.Generic;
using AhmadBooks.BMS.Books;
using AhmadBooks.BMS.Users;
using Volo.Abp.Domain.Entities.Auditing;

namespace AhmadBooks.BMS.Groups
{
    public class Group : FullAuditedAggregateRoot<Guid>
	{
		public string Name { get; set; }
        public List<Book> Books { get; set; }
        public List<Owner> Members { get; set; }
    }
}
