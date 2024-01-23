using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<Course> courses = _db.Courses.ToList();
            return View(courses);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            List<Teacher> teachers = _db.Teachers.ToList();
            var teacherList = teachers.Select(t => new { Id = t.Id, FullName = $"{t.Name} {t.Surname}" });
            ViewBag.TeacherId = new SelectList(teacherList, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course newCourse)
        {
            Console.WriteLine(newCourse);
            Console.WriteLine(newCourse.Id);
            Console.WriteLine(newCourse.Name);
            Console.WriteLine(newCourse.Credit);
            Console.WriteLine(newCourse.TeacherId);
            if (ModelState.IsValid)
            {
                _db.Courses.Add(newCourse);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine("Model state is not valid");
                foreach (var entry in ModelState.Values)
                {
                    foreach (var error in entry.Errors)
                    {
                        Console.WriteLine($"Validation error: {error.ErrorMessage}");
                    }
                }
            }
            List<Teacher> teachers = _db.Teachers.ToList();
            var teacherList = teachers.Select(t => new { Id = t.Id, FullName = $"{t.Name} {t.Surname}" });
            ViewBag.TeacherId = new SelectList(teacherList, "Id", "FullName");

            return View();
        }

        public IActionResult Edit(String? Id)
        {
            if (Id == null) return NotFound();
            var course = _db.Courses.SingleOrDefault(c => c.Id == Id);
            if (course == null) return NotFound();

            List<Teacher> teachers = _db.Teachers.ToList();
            var teacherList = teachers.Select(t => new { Id = t.Id, FullName = $"{t.Name} {t.Surname}" });
            ViewBag.TeacherId = new SelectList(teacherList, "Id", "FullName");

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Update(course);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Teacher> teachers = _db.Teachers.ToList();
            var teacherList = teachers.Select(t => new { Id = t.Id, FullName = $"{t.Name} {t.Surname}" });
            ViewBag.TeacherId = new SelectList(teacherList, "Id", "FullName");
            return View();
        }

        // public IActionResult Delete(string id)
        // {
        //     // Display confirmation or other logic for GET request
        //     // ...

        //     return View();
        // }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string  id)
        {
            if (id == null)
            {
                return NotFound("Course Id is null.");
            }

            var course = _db.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound("Course not found.");
            }

            _db.Courses.Remove(course);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}