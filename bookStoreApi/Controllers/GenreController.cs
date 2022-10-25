using bookStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly bookStoreContext _dbContext;
        public GenreController(bookStoreContext booksContext)
        {
            _dbContext = booksContext;
        }


     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre()
        {
           if(_dbContext.Genres == null)
            {
                return NotFound();
            }
            return await _dbContext.Genres.ToListAsync();
        }

    }
}
