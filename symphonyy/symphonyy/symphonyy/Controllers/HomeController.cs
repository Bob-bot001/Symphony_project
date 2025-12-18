using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using symphony.Models;

namespace symphony.Controllers
{
    public class HomeController : Controller

    {
        public IActionResult Admindashboard()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();


        }

        public IActionResult About()
        {
            return View();


        }

        public IActionResult Courses()
        {
            return View();


        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult EntranceExam()
        {
            return View();
        }
        public IActionResult FAQ()
        {

            return View();

        }
   

        public IActionResult Result()
        {
            return View();
        }

        public IActionResult log()
        {
            return View();
        }


        public IActionResult register()
        {
            return View();
        }




    }

}
