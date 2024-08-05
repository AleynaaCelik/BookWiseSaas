using BookWiseSaas.Application.Common.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task AddBookAsync(BookDto bookDto);
        Task UpdateBookAsync(BookDto bookDto);
        Task DeleteBookAsync(int id);
    }
}
