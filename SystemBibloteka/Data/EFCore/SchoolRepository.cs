using Microsoft.EntityFrameworkCore;
using SystemBibloteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemBibloteka.Data.EFCore
{
    public class SchoolRepository : EfCoreRepository<School, ApplicationDbContext>
    {

        public SchoolRepository(ApplicationDbContext context) : base(context)
        {
           
        }

    }
}
