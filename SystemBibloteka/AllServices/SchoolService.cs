using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemBibloteka.Controllers.Request;
using SystemBibloteka.Controllers.Response;
using SystemBibloteka.Data.EFCore;
using SystemBibloteka.Models;

namespace SystemBibloteka.Services
{
    public class SchoolService : ISchoolService
    {

        private readonly SchoolRepository _schoolRepository;

        public SchoolService(SchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<ActionResult<SchoolRespone>> Create(SchoolRequest school)
        {
            var school1 = MapRequestToModel(school);

            school1 = await _schoolRepository.Add(school1);

            var schoolResponse = MapModelToResponse(school1);
            return schoolResponse;
        }

        public async Task<ActionResult<SchoolRespone>> DeleteSchool(int id)
        {
            var school1 = await _schoolRepository.Delete(id);

            var schoolResponse = MapModelToResponse(school1);
            return schoolResponse;
        }

        public async Task<ActionResult<SchoolRespone>> GetSchool(int id)
        {
            var school1 = await _schoolRepository.Get(id);

            var schoolResponse = MapModelToResponse(school1);
            return schoolResponse;
        }

        public async Task<ActionResult<IEnumerable<SchoolRespone>>> GetSchools()
        {
            var schools = await _schoolRepository.GetAll();

            var schoolResponse = MapModelToResponse(schools);
            return schoolResponse;
        }

        public SchoolRespone MapModelToResponse(School School1)
        {
            if (School1 == null)
            {
                return null;
            }

            var schoolRespone = new SchoolRespone
            {
                Id = School1.Id,
                Name = School1.Name,
            };

            return schoolRespone;
        }

        public List<SchoolRespone> MapModelToResponse(List<School> Schools)
        {
            if (Schools == null)
            {
                return null;
            }

            var allResponses = new List<SchoolRespone>();
            foreach (var school in Schools)
            {
                var schholResponse = MapModelToResponse(school);
                allResponses.Add(schholResponse);
            }

            return allResponses;
        }

        public School MapRequestToModel(SchoolRequest school1)
        {
            if (school1 == null)
            {
                return null;
            }

            var school = new School
            {
                Id = school1.Id,
                Name = school1.Name
            };

            return school;
        }

        public List<School> MapRequestToModel(List<SchoolRequest> school)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<SchoolRespone>> Update(SchoolRequest school)
        {
            var school1 = MapRequestToModel(school);

            school1 = await _schoolRepository.Update(school1);

            var schoolRespone = MapModelToResponse(school1);
            return schoolRespone;
        }
    }
}
