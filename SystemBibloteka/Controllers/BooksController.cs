using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SystemBibloteka.Controllers.Request;
using SystemBibloteka.Controllers.Response;
using SystemBibloteka.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystemBibloteka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Pobierz wszystkie ksiazki.
        /// </summary>
        /// <returns>Wszystkie Ksiazki.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooks()
        {
            var books = await _bookService.GetBooks();
            return Ok(books);
        }

        /// <summary>
        /// Pobierz ksiazke po Id.
        /// </summary>
        /// <param name="id">Ksiazka Id.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> GetBook(int id)
        {
            var book = await _bookService.GetBook(id);

            if (book.Value == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Aktualizacja ksiazki po Id.
        /// </summary>
        /// <param name="id">Ksiazka Id.</param>
        /// <param name="bookRequest">Dane Ksiazka.</param>
        /// <returns>Pusta odpowiedz.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, BookRequest bookRequest)
        {
            if (id != bookRequest.Id)
            {
                return BadRequest();
            }

            await _bookService.Update(bookRequest);

            return NoContent();
        }

        /// <summary>
        /// Tworzenie nowej ksiazki.
        /// </summary>
        /// <param name="bookRequest">Ksiazka dane.</param>
        /// <returns>Stworzona ksiazka.</returns>
        [HttpPost]
        public async Task<ActionResult<BookResponse>> PostBook(BookRequest bookRequest)
        {
            var bookResponse = await _bookService.Create(bookRequest);

            return CreatedAtAction("GetBook", new { id = bookResponse.Value.Id }, bookResponse.Value);
        }

        /// <summary>
        /// Usuwanie ksiazki po ID.
        /// </summary>
        /// <param name="id">Ksiazka Id.</param>
        /// <returns>Usunieta ksiazka.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookResponse>> DeleteBook(int id)
        {
            var book = await _bookService.DeleteBook(id);
            if (book.Value == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
