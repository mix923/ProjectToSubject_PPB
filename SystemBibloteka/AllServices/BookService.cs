using Microsoft.AspNetCore.Mvc;
using SystemBibloteka.Controllers.Request;
using SystemBibloteka.Controllers.Response;
using SystemBibloteka.Data.EFCore;
using SystemBibloteka.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystemBibloteka.Services
{
    public class BookService : IBookService
    {
        private readonly BookRepository _bookRepository;

        private readonly ILibraryService _libraryService;

        public BookService(BookRepository bookRepository, ILibraryService libraryService)
        {
            _bookRepository = bookRepository;
            _libraryService = libraryService;
        }

        public async Task<ActionResult<BookResponse>> Create(BookRequest bookRequest)
        {
            var book = MapRequestToModel(bookRequest);

            book = await _bookRepository.Add(book);

            var bookResponse = MapModelToResponse(book);
            return bookResponse;
        }

        public async Task<ActionResult<BookResponse>> DeleteBook(int id)
        {
            var book = await _bookRepository.Delete(id);

            var bookResponse = MapModelToResponse(book);
            return bookResponse;
        }

        public async Task<ActionResult<BookResponse>> GetBook(int id)
        {
            var book = await _bookRepository.Get(id);

            var bookResponse = MapModelToResponse(book);
            return bookResponse;
        }

        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooks()
        {
            var boooks = await _bookRepository.GetAll();

            var bookResponses = MapModelToResponse(boooks);
            return bookResponses;
        }

        public async Task<ActionResult<BookResponse>> Update(BookRequest bookRequest)
        {
            var book = MapRequestToModel(bookRequest);

            book = await _bookRepository.Update(book);

            var bookResponse = MapModelToResponse(book);
            return bookResponse;
        }

        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooksForLibrary(int id)
        {
            var boooks =  _bookRepository.GetBooksForLibarary(id);

            var bookResponses = MapModelToResponse(boooks);
            return bookResponses;
        }

        public Book MapRequestToModel(BookRequest bookRequest)
        {
            if (bookRequest == null)
            {
                return null;
            }

            var book = new Book
            {
                Id = bookRequest.Id,
                Name = bookRequest.Name,
                Date = bookRequest.Date,
                Author = bookRequest.Author,
                Side = bookRequest.Side,
                LibraryId = bookRequest.LibraryId
            };

            return book;
        }

        public List<Book> MapRequestToModel(List<BookRequest> bookRequests)
        {
            if (bookRequests == null)
            {
                return null;
            }

            var boooks = new List<Book>();
            foreach (var bookRequest in bookRequests)
            {
                var book = MapRequestToModel(bookRequest);
                boooks.Add(book);
            }

            return boooks;
        }

        public BookResponse MapModelToResponse(Book book)
        {
            if (book == null)
            {
                return null;
            }

            var bookResponse = new BookResponse
            {
                Id = book.Id,
                Name = book.Name,
                Date = book.Date,
                Author = book.Author,
                Side =book.Side,
                LibararyResponse = _libraryService.MapModelToResponse(book.Library)
            };

            return bookResponse;
        }

        public List<BookResponse> MapModelToResponse(List<Book> boooks)
        {
            if (boooks == null)
            {
                return null;
            }

            var bookResponses = new List<BookResponse>();
            foreach (var book in boooks)
            {
                var bookResponse = MapModelToResponse(book);
                bookResponses.Add(bookResponse);
            }

            return bookResponses;
        }
    }
}
