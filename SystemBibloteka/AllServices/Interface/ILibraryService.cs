using Microsoft.AspNetCore.Mvc;
using SystemBibloteka.Controllers.Request;
using SystemBibloteka.Controllers.Response;
using SystemBibloteka.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystemBibloteka.Services
{
    public interface ILibraryService
    {
        Task<ActionResult<IEnumerable<LibraryResponse>>> GetLibraries();

        Task<ActionResult<LibraryResponse>> GetLibrary(int id);

        Task<ActionResult<LibraryResponse>> Update(LibraryRequest library);

        Task<ActionResult<LibraryResponse>> Create(LibraryRequest library);

        Task<ActionResult<LibraryResponse>> DeleteLibrary(int id);

        Task<ActionResult<IEnumerable<LibraryResponse>>> GetLibrariesForSchool(int id);

        Library MapRequestToModel(LibraryRequest library);

        List<Library> MapRequestToModel(List<LibraryRequest> library);

        LibraryResponse MapModelToResponse(Library library);

        List<LibraryResponse> MapModelToResponse(List<Library> libraries);
    }
}
