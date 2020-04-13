using Microsoft.EntityFrameworkCore;
using SystemBibloteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemBibloteka.Data.EFCore
{
    public class BookRepository : EfCoreRepository<Book, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Book> GetBooksForLibarary(int id)
        {
            return _context.Books.Include(x => x.Library).Where(x => x.LibraryId == id).ToList();
        }

        public new async Task<Book> Get(int id)
        {
            var book = await _context.Books.Include(x => x.Library).Where(x => x.Id == id).FirstOrDefaultAsync();
            return book;
        }

        public new async Task<List<Book>> GetAll()
        {
            var books = await _context.Books.Include(x => x.Library).ToListAsync();
            return books;
        }
    }
}
