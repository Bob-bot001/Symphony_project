using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace symphony.Controllers
{
    public class Admin : Controller
    {

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult admindashboard()
        {
            return View();
        }




    }
}
