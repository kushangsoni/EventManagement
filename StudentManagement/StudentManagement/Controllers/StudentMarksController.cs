using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModel;
namespace StudentManagement.Controllers
{
    public class StudentMarksController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Posteventinfo(StudentMarkDTO student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(StudentMarkDTO.AddStudentMarks(student));
            
        }
    }
}
