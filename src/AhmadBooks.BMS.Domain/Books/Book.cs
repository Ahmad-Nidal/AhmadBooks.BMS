using AhmadBooks.BMS.Groups;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Volo.Abp;
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
    
        protected Book()
        {
            AssignedGroups = new List<Group>();
        }

        public Book(
            [NotNull] string title, 
            [CanBeNull] string author, 
            BookStatus status, 
            [NotNull] Guid ownerId)
        {
            Check.NotNullOrWhiteSpace(title, nameof(title));
            Check.NotDefaultOrNull<Guid>(ownerId, nameof(ownerId));

            SetTitle(title);
            Author = author;
            Status = status;
            OwnerId = ownerId;
        }

        public Book SetTitle(string title)
        {
            Check.NotNullOrWhiteSpace(title, nameof(title));

            Title = Check.NotNullOrWhiteSpace(
                title,
                nameof(title),
                maxLength: BookConsts.MaxNameLength
            );
            return this;
        }
    }
}
