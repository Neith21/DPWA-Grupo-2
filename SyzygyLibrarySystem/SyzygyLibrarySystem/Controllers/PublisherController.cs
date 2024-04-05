using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SyzygyLibrarySystem.Models;
using SyzygyLibrarySystem.Repositories.Publishers;

namespace SyzygyLibrarySystem.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        // GET: PublisherController
        public ActionResult Index()
        {
            return View(_publisherRepository.GetAll());
        }

        // GET: PublisherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublisherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublisherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherModel publisher)
        {
            try
            {
                _publisherRepository.Add(publisher);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(publisher);
            }
        }

        // GET: PublisherController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var publisher = _publisherRepository.GetById(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PublisherModel publisher)
        {
            try
            {
                _publisherRepository.Edit(publisher);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(publisher);
            }
        }

        // GET: PublisherController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var publisher = _publisherRepository.GetById(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: PublisherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PublisherModel publisher)
        {
            try
            {
                _publisherRepository.Delete(publisher.PublisherId);

                TempData["message"] = "Dato eliminado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(publisher);
            }
        }
    }
}
