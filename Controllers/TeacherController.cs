using Microsoft.AspNetCore.Mvc;
using GradeView.Data;
using GradeView.Models;

namespace GradeView.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        public TeacherController(AppDbContext db) => _db = db;

        public IActionResult Index()
        {
            int? teacherId = HttpContext.Session.GetInt32("teacherId");
            var teacher = _db.Teachers.Find(teacherId);
            return View(teacher);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher newTeacher)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Add(newTeacher);
                _db.SaveChanges();
                return View();
                // return RedirectToAction("Index");
            }
            return View(newTeacher);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}