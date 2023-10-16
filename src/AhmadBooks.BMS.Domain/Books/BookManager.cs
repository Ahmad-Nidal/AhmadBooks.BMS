using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace AhmadBooks.BMS.Books
{
    public class BookManager : DomainService, IBookManager
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBookASync(Book book)
        {
            await _bookRepository.DeleteAsync(book);
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _bookRepository.GetAsync(id);
        }

        public async Task<ICollection<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetListAsync();
        }

        public async Task<Book> UpdateBookStatusAsync(Guid Id, BookStatus bookStatus)
        {
            var book = await _bookRepository.GetAsync(Id);
            throw new NotImplementedException();
        }
    }
}
