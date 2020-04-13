using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBibloteka.Controllers.Request;
using SystemBibloteka.Controllers.Response;
using SystemBibloteka.Models;

namespace SystemBibloteka.Services
{
    public interface ISchoolService
    {
        Task<ActionResult<IEnumerable<SchoolRespone>>> GetSchools();

        Task<ActionResult<SchoolRespone>> GetSchool(int id);

        Task<ActionResult<SchoolRespone>> Update(SchoolRequest school);

        Task<ActionResult<SchoolRespone>> Create(SchoolRequest school);

        Task<ActionResult<SchoolRespone>> DeleteSchool(int id);


        School MapRequestToModel(SchoolRequest school);

        List<School> MapRequestToModel(List<SchoolRequest> school);

        SchoolRespone MapModelToResponse(School School);

        List<SchoolRespone> MapModelToResponse(List<School> Schools);
    }
}
