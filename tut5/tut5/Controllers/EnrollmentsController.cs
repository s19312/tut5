using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using tut5.Models;
using tut5.Services;

namespace tut5.Controllers
{


    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentServiceDb _service;

        //Constructor injection (SOLID - D - Dependency Injection)
        public EnrollmentsController(IStudentServiceDb service)
        {
            _service = service;
        }

        [HttpPost("/promotions")]
        public IActionResult Promotion(Promotion promotion) {

           return  _service.Promote(promotion.Semester,promotion.Studies);
        }
        [HttpPost]
        public IActionResult Enrollment(Enrollment enrollment)
        {
            return _service.Enrollment(enrollment);
        }
    }
}
