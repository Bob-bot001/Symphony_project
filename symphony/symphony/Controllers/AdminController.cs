using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using symphony.Models;

namespace symphony.Controllers;

public class AdminController : Controller
{

  
    public IActionResult Index()
        {
            return View();
        }



        public IActionResult admindashboard()
        {
        if (HttpContext.Session.GetString("UserRole") != "Admin")
            return RedirectToAction("Login", "Account");

        return View();
        
        }

        
    
}
