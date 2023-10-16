using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AhmadBooks.BMS.Books
{
    public interface IBookManager
    {
        Task<Book> AddBookAsync(Book book);
        Task DeleteBookASync(Book book);
        Task<Book> GetBookAsync(Guid id);
        Task<ICollection<Book>> GetBooksAsync();
        Task<Book> UpdateBookStatusAsync(Guid Id, BookStatus bookStatus);
    }
}
