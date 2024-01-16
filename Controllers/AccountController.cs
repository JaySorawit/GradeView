using GradeView.Data;
using GradeView.Models;
using Microsoft.AspNetCore.Mvc;

namespace GradeView.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;
        public AccountController(AppDbContext db) => _db = db;

        public IActionResult Index()
        {
            return View();
        }
    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(String Email, String Password)
        {
            if (ModelState.IsValid)
            {
                var student = _db.Students.FirstOrDefault(s => s.Email == Email);
                if (student != null && student.Password == Password)
                {
                    int studentId = student.Id;
                    HttpContext.Session.SetInt32("studentId", studentId);
                    Console.WriteLine(HttpContext.Session.GetInt32("studentId"));
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ModelState.AddModelError("Password", "The Email or password is incorrect.");
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}