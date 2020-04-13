using Microsoft.AspNetCore.Mvc;
using SystemBibloteka.Controllers.Request;
using SystemBibloteka.Controllers.Response;
using SystemBibloteka.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystemBibloteka.Services
{
    public interface IBookService
    {
        Task<ActionResult<IEnumerable<BookResponse>>> GetBooks();

        Task<ActionResult<BookResponse>> GetBook(int id);

        Task<ActionResult<BookResponse>> Update(BookRequest bookRequest);

        Task<ActionResult<BookResponse>> Create(BookRequest bookRequest);

        Task<ActionResult<BookResponse>> DeleteBook(int id);

        Task<ActionResult<IEnumerable<BookResponse>>> GetBooksForLibrary(int id);

        Book MapRequestToModel(BookRequest bookRequest);

        List<Book> MapRequestToModel(List<BookRequest> bookRequests);

        BookResponse MapModelToResponse(Book book);

        List<BookResponse> MapModelToResponse(List<Book> books);
    }
}
