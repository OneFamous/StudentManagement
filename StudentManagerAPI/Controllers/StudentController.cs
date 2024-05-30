using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentManagerAPI.Controllers
{
    public class StudentController : ApiController
    {
        List<Student> students;

        public StudentController() 
        {
            students = new List<Student>();
            students.Add(new Student { id = 1,firstname= "Fatihh", lastname= "Atess", password="123", username="FatihhAtess"});
            students.Add(new Student { id = 2,firstname= "Salihh", lastname= "Atess", password="1234", username= "SalihhAtess" });
            students.Add(new Student { id = 3,firstname= "Asshh", lastname= "Atess", password="1235", username= "AsshhAtess" });
        }

        public IEnumerable<Student> Get()
        {
            return students;
        }

        public Student Get(int id) 
        {
            return students.FirstOrDefault(x => x.id == id);
        }

    }
}