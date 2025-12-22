using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using symphony.Models;
using System.Linq;

namespace symphony.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyContext _context;

        public AccountController(MyContext context)
        {
            _context = context;
        }

        // ================= LOGIN =================

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users
                .FirstOrDefault(x =>
                    x.user_email == email &&
                    x.user_password == password &&
                    x.IsActive == true);

            if (user == null)
            {
                ViewBag.Error = "Invalid Email or Password";
                return View();
            }

            // 🔥 SESSION SET
            HttpContext.Session.SetString("UserEmail", user.user_email);
            HttpContext.Session.SetString("UserRole", user.user_role);
            HttpContext.Session.SetString("UserName", user.user_name); // ⭐ IMPORTANT

            // 🔁 ROLE BASED REDIRECT
            if (user.user_role == "Admin")
                return RedirectToAction("Dashboard", "Admin");

            if (user.user_role == "Teacher")
                return RedirectToAction("Dashboard", "Teacher");

            return RedirectToAction("Dashboard", "User");
        }

        // ================= REGISTER =================

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges();

                // 🔥 AUTO LOGIN AFTER REGISTER
                HttpContext.Session.SetString("UserEmail", model.user_email);
                HttpContext.Session.SetString("UserRole", model.user_role);
                HttpContext.Session.SetString("UserName", model.user_name);

                // 🔁 DIRECT DASHBOARD
                if (model.user_role == "Admin")
                    return RedirectToAction("Dashboard", "Admin");

                if (model.user_role == "Teacher")
                    return RedirectToAction("Dashboard", "Teacher");

                return RedirectToAction("Dashboard", "User");
            }

            return View(model);
        }

        // ================= LOGOUT =================

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
