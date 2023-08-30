using System;
using Volo.Abp.Domain.Repositories;

namespace AhmadBooks.BMS.Books
{
	public interface IBookRepository : IRepository<Book, Guid>
	{
	}
}

