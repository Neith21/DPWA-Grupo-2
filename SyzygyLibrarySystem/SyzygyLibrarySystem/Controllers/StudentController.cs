using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SyzygyLibrarySystem.Models;
using SyzygyLibrarySystem.Repositories.Students;

namespace SyzygyLibrarySystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(_studentRepository.GetAll());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
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
        public ActionResult Create(StudentModel student)
        {
            try
            {
                _studentRepository.Add(student);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(student);
            }
        }

        // GET: StudentController/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var student = _studentRepository.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentModel student)
        {
            try
            {
                _studentRepository.Edit(student);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(student);
            }
        }

        // GET: StudentController/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var student = _studentRepository.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(StudentModel student)
        {
            try
            {
                _studentRepository.Delete(student.Code);

                TempData["message"] = "Dato eliminado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(student);
            }
        }
    }
}
