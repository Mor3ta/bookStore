
using bookStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace books_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly bookStoreContext _dbContext;
        public AuthorController(bookStoreContext booksContext)
        {
            _dbContext = booksContext;
        }


        //GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>>GetAuthor()
        {
            if (_dbContext.Authors == null)
            {
                return NotFound();
            }
            return await _dbContext.Authors.ToListAsync();

        }

        //GET: api/Books/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            if (_dbContext.Authors == null)
            {
                return NotFound();
            }
            var author = await _dbContext.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        [HttpPost]
        public async Task<ActionResult<Book>>Author(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAuthor), new { idAuthor = author.IdAuthor, }, author);

        }
        [HttpPut]
        public async Task<ActionResult>PutAuthor(int id, Author author)
        {
            if (id != author.IdAuthor)
            {
                return BadRequest();
            }
            _dbContext.Entry(author).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool AuthorExist(int id)
        {
            return (_dbContext.Authors?.Any(b => b.IdAuthor == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteAuthor(int id)
        {
            if (_dbContext.Books == null)
            {
                return NotFound();
            }
            var author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            _dbContext.Remove(author);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }


    }
}