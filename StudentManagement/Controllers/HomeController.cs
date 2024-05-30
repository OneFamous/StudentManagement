using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            
            using (var db = new managerEntities())
            {
                var user = db.user.FirstOrDefault(u => u.id == userId);
                if (user != null)
                {
                    
                    ViewBag.UserName = user.username;
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}