using Microsoft.AspNetCore.Mvc;
using SystemBibloteka.Controllers.Request;
using SystemBibloteka.Controllers.Response;
using SystemBibloteka.Data.EFCore;
using SystemBibloteka.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystemBibloteka.Services
{
    public class LibraryService : ILibraryService
    {

        private readonly libraryRepository _libraryRepository;

        private readonly ISchoolService _schoolService;

        public LibraryService(libraryRepository libraryRepository, ISchoolService _schoolService1)
        {
            _libraryRepository = libraryRepository;
            _schoolService = _schoolService1;
        }

        public async Task<ActionResult<IEnumerable<LibraryResponse>>> GetLibraries()
        {
            var libraries =  await _libraryRepository.GetAll();

            var librarieResponses = MapModelToResponse(libraries);
            return librarieResponses;
        }

        public async Task<ActionResult<LibraryResponse>> GetLibrary(int id)
        {
            var library = await _libraryRepository.Get(id);

            var libraryResponse = MapModelToResponse(library);
            return libraryResponse;
        }

        public async Task<ActionResult<LibraryResponse>> Update(LibraryRequest library)
        {
            var library1 = MapRequestToModel(library);

            library1 = await _libraryRepository.Update(library1);

            var libraryResponse = MapModelToResponse(library1);
            return libraryResponse;
        }

        public async Task<ActionResult<LibraryResponse>> Create(LibraryRequest library)
        {
            var library1 = MapRequestToModel(library);

            library1 = await _libraryRepository.Add(library1);

            var libraryResponse = MapModelToResponse(library1);
            return libraryResponse;
        }

        public async Task<ActionResult<LibraryResponse>> DeleteLibrary(int id)
        {
            var library = await _libraryRepository.Delete(id);

            var libraryResponse = MapModelToResponse(library);
            return libraryResponse;
        }

        public Library MapRequestToModel(LibraryRequest library)
        {
            if (library == null)
            {
                return null;
            }

            var library1 = new Library
            {
                Id = library.Id,
                Name = library.Name,
                City = library.City,
                SchoolId = library.SchoolId 
            };

            return library1;
        }

        public List<Library> MapRequestToModel(List<LibraryRequest> library)
        {
            if (library == null)
            {
                return null;
            }

            var libraries = new List<Library>();
            foreach (var tmpRequest in library)
            {
                var tmp = MapRequestToModel(tmpRequest);
                libraries.Add(tmp);
            }

            return libraries;
        }

        public LibraryResponse MapModelToResponse(Library library)
        {
            if (library == null)
            {
                return null;
            }

            var libraryResponse = new LibraryResponse
            {
                Id = library.Id,
                Name = library.Name,
                City = library.City,
                SchoolResponse = _schoolService.MapModelToResponse(library.School)

            };

            return libraryResponse;
        }

        public List<LibraryResponse> MapModelToResponse(List<Library> libraries)
        {
            if (libraries == null)
            {
                return null;
            }

            var tmpResponses = new List<LibraryResponse>();
            foreach (var tmp in libraries)
            {
                var tmpResponse = MapModelToResponse(tmp);
                tmpResponses.Add(tmpResponse);
            }

            return tmpResponses;
        }

        public async Task<ActionResult<IEnumerable<LibraryResponse>>> GetLibrariesForSchool(int id)
        {
            var schools =  _libraryRepository.GetLibarariesForSchool(id);

            var schholerespones = MapModelToResponse(schools);
            return schholerespones;
        }
    }
}
