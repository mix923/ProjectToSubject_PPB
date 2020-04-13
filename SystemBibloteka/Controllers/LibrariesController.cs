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
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryService _libarartService;

        private readonly IBookService _bookService;

        public LibrariesController(ILibraryService libarartService, IBookService bookService)
        {
            _libarartService = libarartService;
            _bookService = bookService;
        }

        /// <summary>
        /// Pobierz wszystkie bibloteki
        /// </summary>
        /// <returns>Wysztkie biboloteki</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryResponse>>> GetLibraries()
        {
            var libraries = await _libarartService.GetLibraries();
            return Ok(libraries);
        }

        /// <summary>
        /// Pobierz bibloteke po Id
        /// </summary>
        /// <param name="id">Bibloteka Id.</param>
        /// <returns>Bibloteka pod Id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryResponse>> GetLibrary(int id)
        {
            var Library = await _libarartService.GetLibrary(id);

            if (Library.Value == null)
            {
                return NotFound();
            }

            return Ok(Library);
        }

        /// <summary>
        /// Aktualizacja bibloteki po Id.
        /// </summary>
        /// <param name="id">Bibloteka Id.</param>
        /// <param name="libiaratRequest">Bibloteka Dane.</param>
        /// <returns>Pusta Odpowiedz.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrary(long id, LibraryRequest libiaratRequest)
        {
            if (id != libiaratRequest.Id)
            {
                return BadRequest();
            }

            await _libarartService.Update(libiaratRequest);

            return NoContent();
        }

        /// <summary>
        /// Stówrz nową biblotekę.
        /// </summary>
        /// <param name="libiaratRequest">Bibloteka Dane.</param>
        /// <returns>Stworzona bibloteka.</returns>
        [HttpPost]
        public async Task<ActionResult<LibraryResponse>> PostLibrary(LibraryRequest libiaratRequest)
        {
            var libiarayResponse = await _libarartService.Create(libiaratRequest);

            return CreatedAtAction("GetLibrary", new { id = libiarayResponse.Value.Id }, libiarayResponse.Value);
        }

        /// <summary>
        /// Usun biblotetke po Id.
        /// </summary>
        /// <param name="id">Bibloteka Id.</param>
        /// <returns>Usunieta bibloteka.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<LibraryResponse>> DeleteLibrary(int id)
        {
            var libiaray= await _libarartService.DeleteLibrary(id);
            if (libiaray.Value == null)
            {
                return NotFound();
            }

            return Ok(libiaray);
        }

        /// <summary>
        /// Pobierz ksiazki które nalezą do bibloteki.
        /// </summary>
        /// <param name="id">Bibloteka Id.</param>
        /// <returns>Zwracanie ksiązek które nalezą do bibloteki.</returns>
        [HttpGet("{id}/books")]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooksForBibrary(int id)
        {
            var books = await _bookService.GetBooksForLibrary(id);
            return Ok(books);
        }
    }
}
