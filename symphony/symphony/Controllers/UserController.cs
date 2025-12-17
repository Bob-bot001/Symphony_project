using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("UserRole") != "User")
            return RedirectToAction("Login", "Account");

        return View();
    }
}
