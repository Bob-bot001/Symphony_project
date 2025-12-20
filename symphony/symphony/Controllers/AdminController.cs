using Microsoft.AspNetCore.Mvc;


public class AdminController : Controller
{

    public class Admin : Controller
    {

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult admindashboard()
        {
            return View();
        }
        
    }
}
