using Microsoft.AspNetCore.Mvc;
using AttributeRoutingDemoInMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace AttributeRoutingDemoInMVC.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>()
        {
            new Student() {Id = 1, Name = "John"},
            new Student() {Id = 2, Name = "Arthur"},
            new Student() {Id = 3, Name = "Smith"},
            new Student() {Id = 4, Name = "Sara"}
        };

        [HttpGet]
        [Route("details/{studentID:int:min(1):max(4)}")]
        public IActionResult GetStudentDetails(int studentID)
        {
            Student studentDetails = students.FirstOrDefault(s => s.Id == studentID);
            return View(studentDetails);
        }

        [HttpGet]
        [Route("details/{studentName:alpha}")]
        public IActionResult GetStudentDetails(string studentName)
        {
            Student studentDetails = students.FirstOrDefault(s => s.Name == studentName);
            return View(studentDetails);
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllStudents()
        {
            return View(students);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudentById(int id)
        {
            Student studentDetails = students.FirstOrDefault(s => s.Id == id);

            return View(studentDetails);
        }

        [HttpGet]
        [Route("{studentID}/courses")]
        //This will translated to /students/2/courses
        public IActionResult GetStudentsByCourses(int studentID)
        {
            List<String> CourseList = new List<string>();

            if (studentID == 1)
                CourseList = new List<String>() { "ASP.NET", "C#.NET", "SQL Server" };
            else if (studentID == 2)
                CourseList = new List<String>() { "ASP.NET MVC", "C#.NET", "ADO.NET" };
            else if (studentID == 3)
                CourseList = new List<String>() { "ASP.NET Web API", "C#.NET", "Entity Framework" };
            else
                CourseList = new List<String>() { "JQUERY", "BootStrap", "Angular" };

            ViewBag.CourseList = CourseList;

            return View();
        }

        [Route("~/tech/teachers")]
        public IActionResult GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() { Id = 1, Name = "Mr. Will Smith"},
                new Teacher() {Id = 2, Name = "Ms. Sara Kumari"},
                new Teacher() {Id = 3, Name = "Mr. John Don"}
            };
            return View(teachers);
        }
    }
}
