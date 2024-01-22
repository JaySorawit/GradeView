using Microsoft.AspNetCore.Mvc;
using GradeView.Data;
using GradeView.Models;

namespace GradeView.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        public CourseController(AppDbContext db) => _db = db;

        public IActionResult Index()
        {
            return View();
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
        public IActionResult Create(Course newCourse)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(newCourse);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newCourse);
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