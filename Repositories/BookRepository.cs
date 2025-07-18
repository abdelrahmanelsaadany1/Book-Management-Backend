using AutoMapper;
using Book_Management_Backend.Dtos;
using Book_Management_Backend.Entities;
using Book_Management_Backend.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book_Management_Backend.Repositories
{
    public class BookRepository : IbookInterface
    {
        private readonly BookDbContext bookDbContext;
        private readonly IMapper MappingProfile;

        public BookRepository(BookDbContext bookDbContext , IMapper mappingProfile) {
            this.bookDbContext = bookDbContext;
           this.MappingProfile = mappingProfile;
        }
        public async Task<Book> CreateBook(BookDto bookDto)
        {
         Book book =  MappingProfile.Map<Book>(bookDto);   
            await bookDbContext.Books.AddAsync(book);
            await SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var book = await GetBookBYId(id);
            if (book == null)
                return null;

            bookDbContext.Books.Remove(book);
            await SaveChangesAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await bookDbContext.Books.ToListAsync();
            
        }

        public async Task<Book?> GetBookBYId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid book ID");

            return await bookDbContext.Books.FindAsync(id);
        }

        public async Task<Book> GetBookByTitle(string title)
        {
            var book = await bookDbContext.Books.FirstOrDefaultAsync(b => b.Title == title);
            if (book == null)
            {
                throw new Exception($"Book with title '{title}' not found.");
            }

            return book;
        }


        public async Task SaveChangesAsync()
        {
            await bookDbContext.SaveChangesAsync();
        }

        public async Task<Book> UpdateBook(int id, BookDto updatedBook)
        {
            var existingBook = await GetBookBYId(id);
            if (existingBook == null)
                throw new Exception("Book not found");


            MappingProfile.Map(updatedBook, existingBook);


            await SaveChangesAsync();
            return existingBook;
        }

       
    }
}
