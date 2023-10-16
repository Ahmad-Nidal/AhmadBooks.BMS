using AhmadBooks.BMS.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AhmadBooks.BMS.BooksPublisher
{
    public interface IBooksPublisherManager
    {
        Task AssignBookToGroup(Guid bookId, Guid groupId);
        Task RemoveBookFromGroup(Guid bookId, Guid groupId);
        Task<ICollection<Book>> GetOwnerBooksInGroup(Guid ownerId ,Guid groupId);
        Task<ICollection<Book>> GetGroupBooks(Guid groupId);
    }
}
