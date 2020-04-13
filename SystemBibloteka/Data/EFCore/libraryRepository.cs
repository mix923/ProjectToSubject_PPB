using Microsoft.EntityFrameworkCore;
using SystemBibloteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemBibloteka.Data.EFCore
{
    public class libraryRepository : EfCoreRepository<Library, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;

        public libraryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Library> GetLibarariesForSchool(int id)
        {
            return _context.Libraries.Include(x => x.School).Where(x => x.SchoolId == id).ToList();
        }

        public new async Task<Library> Get(int id)
        {
            var libaray = await _context.Libraries.Include(x => x.School).Where(x => x.Id == id).FirstOrDefaultAsync();
            return libaray;
        }

        public new async Task<List<Library>> GetAll()
        {
            var libaraies = await _context.Libraries.Include(x => x.School).ToListAsync();
            return libaraies;
        }
    }
}
