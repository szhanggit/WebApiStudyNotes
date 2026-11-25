using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class StudentsV1Controller : ApiController
    {
        static List<StudentV1> students = new List<StudentV1>()
        {
            new StudentV1() { Id = 1, Name = "Tom" },
            new StudentV1() { Id = 2, Name = "Sam" },
            new StudentV1() { Id = 3, Name = "John" }
        };

        //[Route("")]
        //public IEnumerable<Student> Get()
        //{
        //    return students;
        //}

        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse(students);
        //}

        public IHttpActionResult Get()
        {
            return Ok(students);
        }

        ////[Route("{id:int:min(1):max(3)}")]
        //[Route("{id:int:range(1,100)}", Name = "GetStudentById")]
        //public Student Get(int id)
        //{
        //    return students.FirstOrDefault(s => s.Id == id);
        //}

        //public HttpResponseMessage Get(int id)
        //{
        //    var student = students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
        //            "Student not found");
        //    }

        //    return Request.CreateResponse(student);
        //}

        public IHttpActionResult Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Student not found");
            }

            return Ok(student);
        }

        public StudentV1 Get(string name)
        {
            return students.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        public IEnumerable<string> GetStudentCourses(int id)
        {
            if (id == 1)
                return new List<string>() { "C#", "ASP.NET", "SQL Server" };
            else if (id == 2)
                return new List<string>() { "ASP.NET Web API", "C#", "SQL Server" };
            else
                return new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
        }

        public HttpResponseMessage Post(StudentV1 student)
        {
            students.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            var a = Url.Link("GetStudentById", new { id = student.Id });
            //response.Headers.Location = new Uri(Request.RequestUri + student.Id.ToString());
            response.Headers.Location = new Uri(Url.Link("GetStudentById", new { id = student.Id }));
            return response;
        }
    }
}
