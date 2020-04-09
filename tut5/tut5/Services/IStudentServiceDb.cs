using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut5.Models;

namespace tut5.Services
{
    public interface IStudentServiceDb
    {
        IActionResult Enrollment(Enrollment enrollment);
        IActionResult Promote(int semester, string studies);
    }
}
