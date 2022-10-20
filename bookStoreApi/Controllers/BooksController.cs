
using bookStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace books_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly bookStoreContext _dbContext;
        public BooksController(bookStoreContext booksContext)
        {
            _dbContext = booksContext;
        }


        //GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {  if (_dbContext.Books == null)
            {
                return NotFound();
            }
            return await _dbContext.Books.ToListAsync();
          
        }

        //GET: api/Books/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            if (_dbContext.Books == null)
            {
                return NotFound();
            }
            var book = await _dbContext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Books(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBooks), new { idBook = book.IdBooks, }, book);

        }
        [HttpPut]
        public async Task<ActionResult>PutBook(int id, Book book)
        {
            if(id != book.IdBooks)
            {
                return BadRequest();
            }
            _dbContext.Entry(book).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExist(id)){
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool BookExist(int id)
        {
            return (_dbContext.Books?.Any(b => b.IdBooks == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBooks(int id)
        {
           if (_dbContext.Books == null)
            {
                return NotFound();
            }
            var book = await _dbContext.Books.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }
             _dbContext.Remove(book);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }


    }
}