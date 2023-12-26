using Microsoft.AspNetCore.Mvc;

namespace GradeView.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return Content("score detail");
        }
    }
}