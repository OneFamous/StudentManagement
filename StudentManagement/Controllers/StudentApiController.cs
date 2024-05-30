using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class StudentApiController : Controller
    {
        // GET: StudentApi
        public ActionResult Index()
        {
            IEnumerable<Student> students = GetStudent();
            return View(students);
        }

        public ActionResult Get(int id) 
        {
            Student student = GetStudentByID(id);
            List<Student> students = new List<Student>();
            students.Add(student);
            return View("Index",students);
        }

         Student GetStudentByID(int id) 
        {
            Student student = null;
            using (HttpClient client = new HttpClient())
            {

                string url = "http://localhost:50308/api/student?id=" + id;
                System.Threading.Tasks.Task<HttpResponseMessage> result = client.GetAsync(url);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<String> serializedResult = result.Result.Content.ReadAsStringAsync();
                    student = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(serializedResult.Result);
                }
            }
            return student;
         }



        IEnumerable<Student> GetStudent() 
        {
            IEnumerable<Student> students = null;

            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:50308/api/student";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = client.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<String> response = result.Result.Content.ReadAsStringAsync();
                    students = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Student>>(response.Result);
                }
            }
            return students;
        }
    }
}