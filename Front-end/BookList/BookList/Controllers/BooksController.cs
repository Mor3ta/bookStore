
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using BookList.Models;
using static BookList.Models.Books;
using System.Text.Json;

namespace BookList.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;

   
        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

    
        public async Task<IActionResult>Books()
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://localhost:7264");
            var response = await cliente.GetAsync("/api/books");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                ViewBag.book_list = JsonSerializer.Deserialize<Books[]>(json_response);
                return View();
            }
            return View();
        }

       
        public async Task<IActionResult> newBook()
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://localhost:7264");

            //var book = new Books()


            // var response = await cliente.PostAsync("/api/books");

            return View();
        }





    }
}