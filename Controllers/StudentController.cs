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

            var s2 = new Student();
            s2.Id = 2;
            s2.Name = "Jane";
            s2.Score = 50;

            var s3 = new Student();
            s3.Id = 3;
            s3.Name = "Jay";
            s3.Score = 70;

            List<Student> allStudent = new List<Student>();
            allStudent.Add(s1);
            allStudent.Add(s2);
            allStudent.Add(s3);

            return View(allStudent);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}