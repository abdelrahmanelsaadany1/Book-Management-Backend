using Book_Management_Backend.Dtos;
using Book_Management_Backend.Entities;
using Book_Management_Backend.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Management_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IbookInterface _bookRepository;

        public BooksController(IbookInterface bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books = await _bookRepository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _bookRepository.GetBookBYId(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("title/{title}")]
        public async Task<ActionResult<Book>> GetByTitle(string title)
        {
            try
            {
                var book = await _bookRepository.GetBookByTitle(title);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> Create([FromBody] BookDto bookDto)
        {
            var createdBook = await _bookRepository.CreateBook(bookDto); 

            return CreatedAtAction(nameof(GetById),
                new { id = createdBook.Id }, 
                bookDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> Update(int id, [FromBody] BookDto bookDto)
        {
            try
            {
                var updatedBook = await _bookRepository.UpdateBook(id, bookDto);
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var deletedBook = await _bookRepository.DeleteBook(id);
            if (deletedBook == null)
                return NotFound();

            return Ok(deletedBook);
        }


    }
}
