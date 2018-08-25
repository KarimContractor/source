using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
namespace WebApi.Controllers
{
    public class AptechController : ApiController
    {
        // GET api/<controller>
        List<Student> std = new List<Student>()
        {
            new Student() {id=101, Name="Ammar",Age=22 },
            new Student() { id=102, Name="Nadir",Age=23 },
            new Student() { id=103, Name="Haris",Age=24 },
            new Student() { id=104, Name="Kamran",Age=25 },

        };
        public IEnumerable<Student> Getlist()
        {
            return std;
        }
        public IHttpActionResult getlistbyid(int id)
        {
            var student = std.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }
        }
    }
}