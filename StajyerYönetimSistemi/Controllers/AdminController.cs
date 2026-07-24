using Microsoft.AspNetCore.Mvc;

namespace StajyerYonetimSistemi.Controllers
{
    public class AdminController : Controller
    {
        // 1. STAJYERLERİN YÖNLENDİRMESİ
        public IActionResult Interns()
        {
            return View(); // Bizi Views/Admin/Interns.cshtml sayfasına götürür
        }

        // 2. MENTORLARIN YÖNLENDİRMESİ
        public IActionResult Mentors()
        {
            return View(); // Bizi Views/Admin/Mentors.cshtml sayfasına götürür
        }

        // 3. GÜNLÜK RAPOR YÖNLENDİRMESİ
        public IActionResult DailyReport()
        {
            return View(); // Bizi Views/Admin/DailyReport.cshtml sayfasına götürür
        }

        // 4. GÖREV YÖNETİMİ YÖNLENDİRMESİ (Yeni Ekledik!)
        public IActionResult Tasks()
        {
            return View(); // Bizi Views/Admin/Tasks.cshtml sayfasına götürür
        }
        // Tarayıcıdan /Admin/Skills isteği geldiğinde bu fonksiyon çalışacak
        public IActionResult Skills()
        {
            return View(); // Bizi Views/Admin/Skills.cshtml sayfasına götürür
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Files()
        {
            return View();
        }

        public IActionResult Announcements()
        {
            return View();
        }
    }
}