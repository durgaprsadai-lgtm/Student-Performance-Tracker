using Microsoft.AspNetCore.Mvc;
using StudentPerformanceWeb.Models;
using System.Collections.Generic;
using System.Text;

namespace StudentPerformanceWeb.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();
        private const int MaxMarks = 100;  //Constant variable

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var studentName = s.Name; //var keyword
                    dynamic extraInfo = "Top Performer"; //dynamic keyword

                    //Implicit casting
                    double avgDouble = s.CalculateAverage();

                    //Explicit casting
                    int rounded = (int)avgDouble;

                    //Boxing and Unboxing
                    object boxed = rounded;
                    int unboxed = (int)boxed;

                    students.Add(s);
                    return RedirectToAction("Index");
                }
                return View(s);
            }
            catch
            {
                throw; //Exception handling with throw
            }
        }
    }
}
