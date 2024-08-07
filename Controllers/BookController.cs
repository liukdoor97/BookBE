using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Book.Entities;
using Book.Services;
using Book.Repository;
using Book.Models.BookModel;

namespace Book.Controllers
{
    // Controller di Book che deriva dal ControllerBase
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // Chiamata del Servizio IBookService, ICategoryService, IAuthorService e IPublisherService

        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;
        private readonly IAuthorService authorService;
        private readonly IPublisherService publisherService;

        public BookController(IBookService bookService, ICategoryService categoryService, IAuthorService authorService, IPublisherService publisherService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
            this.authorService = authorService;
            this.publisherService = publisherService;
        }

        // Operazioni di Lettura
        [HttpGet] // Metodo GetAll che restituisce una lista di Libri
        public async Task<ActionResult<List<Books>>> GetAll()
        {
            List<Books> result = bookService.GetAll();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("GetBooksByCategoryId/{categoryId}")] // Metodo GetBooksByCategoryId che restituisce una lista di Libri con uno specifico categoryId
        public async Task<ActionResult<List<Books>>> GetBooksByCategoryId(int categoryId)
        {
            if (categoryId <= 0)
            {
                return BadRequest("ID categoria non valido.");
            }

            // Logica per recuperare i libri per l'ID della categoria
            var books = bookService.GetBooksByCategoryId(categoryId);

            return Ok(books);
        }
        [HttpGet("GetBooksByAuthorId/{authorId}")] // Metodo GetBooksByAuthorId che restituisce una lista di Libri con uno specifico authorId
        public async Task<ActionResult<List<Books>>> GetBooksByAuthorId(int authorId)
        {
            Author author = this.authorService.GetById(authorId);
            List<Books> result = bookService.GetBooksByAuthorId(author.Id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("GetBooksByPublisherId/{publisherId}")] // Metodo GetBooksByPublisherId che restituisce una lista di Libri con uno specifico publisherId
        public async Task<ActionResult<List<Books>>> GetBooksByPublisherId(int publisherId)
        {
            Publisher publisher = this.publisherService.GetById(publisherId);
            List<Books> result = bookService.GetBooksByPublisherId(publisher.Id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{Id}")] // Metodo GetById che restituisce un Libro con uno specifico Id
        public async Task<IActionResult> GetById(int Id)
        {
            Books result = bookService.GetById(Id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        // Operazioni di scrittura

        [HttpPost] // Metodo Insert che inserisce un nuovo Libro da un BookModel
        public async Task<IActionResult> Insert([FromBody] BookModel bookModel)
        {
            Categories category = this.categoryService.GetById(bookModel.categoryId);
            Author author = this.authorService.GetById(bookModel.authorId);
            Publisher publisher = this.publisherService.GetById(bookModel.publisherId);

            var book = new Books
            {
                title = bookModel.title,
                year = bookModel.year,
                Category = category,
                CategoryId = category.Id,
                Author = author,
                AuthorId = author.Id,
                Publisher = publisher,
                PublisherId = publisher.Id,
            };

            if (book == null)
            {
                return BadRequest();
            }
            bookService.Insert(book);
            return Ok(book);

        }

        [HttpPut("{Id}")] // Metodo Update che Modifica un Libro da un BookModel con uno specifico Id

        public async Task<IActionResult> Update(int Id, [FromBody] BookModel bookModel)
        {
            var book = bookService.GetById(Id);
            if (book == null)
            {
                return BadRequest();
            }
            book.title = bookModel.title;
            book.year = bookModel.year;
            bookService.Update(book);
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(book);
        }

        [HttpDelete("{Id}")] // Metodo Delete che Elimina un Libro con uno specifico Id

        public async Task<IActionResult> Delete(int Id)
        {
            var book = bookService.Delete(Id);
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(book);
        }
    }
}