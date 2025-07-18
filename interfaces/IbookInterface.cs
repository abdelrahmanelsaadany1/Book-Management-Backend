using Book_Management_Backend.Dtos;
using Book_Management_Backend.Entities;

namespace Book_Management_Backend.interfaces
{
    public interface IbookInterface
    {
       
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetBookBYId(int id);

        Task<Book?> GetBookByTitle(string title);

        Task<Book> CreateBook(BookDto bookDto);
        Task<Book> DeleteBook(int id);
        Task<Book> UpdateBook(int id,BookDto bookDto);

        Task SaveChangesAsync();
    }
}
