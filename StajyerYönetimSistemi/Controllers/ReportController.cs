using Microsoft.AspNetCore.Mvc;

namespace StajyerYonetimSistemi.Controllers
{
    public class ReportController : Controller
    {
        // Tarayıcıdan /Report/DailyReport isteği gelince bu sayfa çalışacak
        public IActionResult DailyReport()
        {
            return View(); // Bizi Views/Report/DailyReport.cshtml sayfasına götürür
        }
    }
}