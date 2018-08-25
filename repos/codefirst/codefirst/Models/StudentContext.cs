using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace codefirst.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext() : base("name=dbcon") { }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Teacher> Teachers { get; set; }

    }
}