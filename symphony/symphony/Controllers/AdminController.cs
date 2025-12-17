using Microsoft.AspNetCore.Mvc;


public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("UserRole") != "Admin")
            return RedirectToAction("Login", "Account");

        return View();
    }
}
