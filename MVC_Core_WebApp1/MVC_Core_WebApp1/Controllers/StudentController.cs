using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Core_WebApp1.Models;

namespace MVC_Core_WebApp1.Controllers
{
    public class StudentController : Controller
    {
        StudentRepo sRepo = null;
        public StudentController()
        {
            sRepo = new StudentRepo();
        }

        [HttpGet]
        public string[] GetAllCities()
        {
            return new string[] { "Pune", "Mumbai", "Delhi", "Bangalore", "Hyderabad" };
        }

        // GET: StudentController
        public ActionResult Index()
        {
            List<Student> sList = sRepo.ShowAllData();
            return View(sList);

                    //OR

            //return View(sRepo.ShowAllData());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            Student s = sRepo.ShowDetailsByID(id);
            return View(s);
        }

        // GET: StudentController/Details/5
        public ActionResult StudentDetailsByName(string name)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s1)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    sRepo.AddData(s1);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            Student s = sRepo.ShowDetailsByID(id);
            if(s == null)
            {
                return NotFound();
            }
            return View(s);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sRepo.UpdateData(id, student);
                    return RedirectToAction(nameof(Index));
                }
                return View(student);
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            Student s = sRepo.ShowDetailsByID(id);
            if(s == null)
            {
                return NotFound();
            }
            return View(s);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                sRepo.DeleteData(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
