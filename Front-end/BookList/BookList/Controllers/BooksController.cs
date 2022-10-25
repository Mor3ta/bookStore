
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookList.Models;
using static BookList.Models.Books;
using System.Text.Json;
using System.IO;

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
            var author_response = await cliente.GetAsync("/api/Author");
            var genre_response = await cliente.GetAsync("/api/Genre");


            if (response.IsSuccessStatusCode)
            {
                
                var json_response = await response.Content.ReadAsStringAsync();
                var json_author_response = await author_response.Content.ReadAsStringAsync();
                var json_genre_response = await genre_response.Content.ReadAsStringAsync();
                ViewBag.book_list = JsonSerializer.Deserialize<Books[]>(json_response);
                ViewBag.author = JsonSerializer.Deserialize<Author[]>(json_author_response);
                ViewBag.genre = JsonSerializer.Deserialize<Genre[]>(json_genre_response);

                return View();
            }
            return View();
        }


        public async Task<IActionResult>newBook()
        {
            var cliente = new HttpClient();
            
            cliente.BaseAddress = new Uri("https://localhost:7264");
            var author_response = await cliente.GetAsync("/api/Author");
            var genre_response = await cliente.GetAsync("/api/Genre");
            if (author_response.IsSuccessStatusCode && genre_response.IsSuccessStatusCode) 
            {
                var json_author_response = await author_response.Content.ReadAsStringAsync();
                var json_genre_response = await genre_response.Content.ReadAsStringAsync();
                ViewBag.author = JsonSerializer.Deserialize<Author[]>(json_author_response);
                ViewBag.genre = JsonSerializer.Deserialize<Genre[]>(json_genre_response);


                return View();
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult>newBook(string title, string description, string sinopsis, string idiom, int pages, int idAuthor, int idGenre)
        {


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://localhost:7264");

            var book = new Books()
            {
                title = title,
                description = description,
                sinopsis = sinopsis,
                idiom = idiom,
                pages = pages,
                idAuthor = idAuthor,
                idGenre = idGenre
            };
            var response = await cliente.PostAsJsonAsync("/api/books", book);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Books");
            }

            return View();
        }





    }
}