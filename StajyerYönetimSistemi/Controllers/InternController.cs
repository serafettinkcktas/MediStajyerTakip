using Microsoft.AspNetCore.Mvc;

public class InternController : Controller
{
    public IActionResult InternDashboard()
    {
        return View();
    }
}