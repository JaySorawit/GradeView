using GradeView.Data;
using GradeView.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using Microsoft.VisualBasic;

namespace GradeView.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        public StudentController(AppDbContext db) => _db = db;

        public IActionResult Index()
        {
            IEnumerable<Student> allStudent = _db.Students.ToList();

            return View(allStudent);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student newStudent, string confirmPassword)
        {
            if (ModelState.IsValid && newStudent.Password == confirmPassword)
            {
                _db.Students.Add(newStudent);
                _db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }
            else if (newStudent.Password != confirmPassword) ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");

            return View(newStudent);
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var student = _db.Students.Find(id);
            if (student == null) return NotFound();

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var student = _db.Students.Find(id);
            if (student == null) return NotFound();
            _db.Students.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}