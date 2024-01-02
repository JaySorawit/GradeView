using GradeView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using Microsoft.VisualBasic;

namespace GradeView.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var s1 = new Student();
            s1.Id = 1;
            s1.Name = "John";
            s1.Score = 90;

            return View(s1);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}