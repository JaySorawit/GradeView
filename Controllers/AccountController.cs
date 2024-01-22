using GradeView.Data;
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
                var teacher = _db.Teachers.FirstOrDefault(s => s.Email == Email);
                if (teacher != null && teacher.Password == Password)
                {
                    int teacherId = teacher.Id;
                    HttpContext.Session.SetInt32("teacherId", teacherId);
                    HttpContext.Session.SetString("isTeacherLoggIn", "true");
                    HttpContext.Session.SetString("userType", "teacher");
                    Console.WriteLine(HttpContext.Session.GetInt32("teacherId"));
                    return RedirectToAction("Index", "Teacher");
                }
                else
                if (student != null && student.Password == Password)
                {
                    int studentId = student.Id;
                    HttpContext.Session.SetInt32("studentId", studentId);
                    HttpContext.Session.SetString("isStudentLoggIn", "true");
                    HttpContext.Session.SetString("userType", "student");
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