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
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        private readonly ILibraryService _libraryService;

        public SchoolsController(ISchoolService schoolService, ILibraryService library)
        {
            _schoolService = schoolService;
            _libraryService = library;
        }

        /// <summary>
        /// Pobierz wszystkie szkoły
        /// </summary>
        /// <returns>Wysztkie szkoły</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolRespone>>> GetSchools()
        {
            var schools = await _schoolService.GetSchools();
            return Ok(schools);
        }

        /// <summary>
        /// Pobierz szkołe po Id
        /// </summary>
        /// <param name="id">Szkoła Id.</param>
        /// <returns>Szkoła po Id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolRespone>> GetSchool(int id)
        {
            var school = await _schoolService.GetSchool(id);

            if (school.Value == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        /// <summary>
        /// Aktualizacja szkoły po Id.
        /// </summary>
        /// <param name="id">Szkoła Id.</param>
        /// <param name="libiaratRequest">Szkoła Dane.</param>
        /// <returns>Pusta Odpowiedz.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchool(long id, SchoolRequest libiaratRequest)
        {
            if (id != libiaratRequest.Id)
            {
                return BadRequest();
            }

            await _schoolService.Update(libiaratRequest);

            return NoContent();
        }

        /// <summary>
        /// Stówrz nową szkołe.
        /// </summary>
        /// <param name="schoolRequest">Szkoła Dane.</param>
        /// <returns>Stworzona Szkoła.</returns>
        [HttpPost]
        public async Task<ActionResult<LibraryResponse>> PostSchool(SchoolRequest schoolRequest)
        {
            var schoolsrespone = await _schoolService.Create(schoolRequest);

            return CreatedAtAction("GetSchool", new { id = schoolsrespone.Value.Id }, schoolsrespone.Value);
        }

        /// <summary>
        /// Usun szkołe po Id.
        /// </summary>
        /// <param name="id">Szkoła Id.</param>
        /// <returns>Usunieta szkoła.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<LibraryResponse>> DeleteSchool(int id)
        {
            var school= await _schoolService.DeleteSchool(id);
            if (school.Value == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        /// <summary>
        /// Pobierz bibloteki należace do danej szkoły/uczelni.
        /// </summary>
        /// <param name="id">Szkoła Id.</param>
        /// <returns>Zwracanie wszystkich biblotek które należą nalezą do danej szkoły</returns>
        [HttpGet("{id}/libraries")]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetLibrariesForSchool(int id)
        {
            var libraries = await _libraryService.GetLibrariesForSchool(id);
            return Ok(libraries);
        }
    }
}
