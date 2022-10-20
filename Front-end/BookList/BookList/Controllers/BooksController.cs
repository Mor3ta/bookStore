using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookList.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        public IActionResult Books()
        {
            return View();
        }
        [Route("Books/Book/{id}")]
        public IActionResult Book(int id)
        {
            return View();
        }


    }
}