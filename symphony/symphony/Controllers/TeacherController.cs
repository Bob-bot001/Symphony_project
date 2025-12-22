using Microsoft.AspNetCore.Mvc;

public class TeacherController : Controller
{
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("UserRole") != "Teacher")
            return RedirectToAction("Login", "Account");

        return View();
    }
}
