using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SyzygyLibrarySystem.Models;
using SyzygyLibrarySystem.Repositories.Books;
using SyzygyLibrarySystem.Repositories.LoanDetails;

namespace SyzygyLibrarySystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        private SelectList _authorsList;
        private SelectList _publisherList;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _authorsList = new SelectList(
                _bookRepository.GetAllAuthors(),
                nameof(AuthorModel.AuthorId),
                nameof(AuthorModel.AuthorName)
            );
            _publisherList = new SelectList(
                _bookRepository.GetAllPublishers(),
                nameof(PublisherModel.PublisherId),
                nameof(PublisherModel.PublisherName)
            );
        }

        // GET: BookController
        public ActionResult Index()
        {
            return View(_bookRepository.GetAll());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewBag.Authors = _authorsList;
            ViewBag.Publishers = _publisherList;

            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookModel book)
        {
            try
            {
                _bookRepository.Add(book);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Authors = _authorsList;
                ViewBag.Publishers = _publisherList;

                return View(book);
            }
        }

        // GET: BookController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            _authorsList = new SelectList(
                _bookRepository.GetAllAuthors(),
                nameof(AuthorModel.AuthorId),
                nameof(AuthorModel.AuthorName),
                book?.Author?.AuthorId
            );
            _publisherList = new SelectList(
                _bookRepository.GetAllPublishers(),
                nameof(PublisherModel.PublisherId),
                nameof(PublisherModel.PublisherName),
                book?.Publisher?.PublisherId
            );

            ViewBag.Authors = _authorsList;
            ViewBag.Publishers = _publisherList;

            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookModel book)
        {
            try
            {
                _bookRepository.Edit(book);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Authors = _authorsList;
                ViewBag.Publishers = _publisherList;

                return View(book);
            }
        }

        // GET: BookController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BookModel book)
        {
            try
            {
                _bookRepository.Delete(book.BookId);

                TempData["message"] = "Dato eliminado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(book);
            }
        }
    }
}
