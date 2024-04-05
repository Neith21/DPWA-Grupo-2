using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SyzygyLibrarySystem.Models;
using SyzygyLibrarySystem.Repositories.LoanDetails;

namespace SyzygyLibrarySystem.Controllers
{
	public class LoanDetailController : Controller
	{
		private readonly ILoanDetailRepository _loanDetailRepository;

		private SelectList _booksList;

		public LoanDetailController(ILoanDetailRepository loanDetailRepository)
		{
			_loanDetailRepository = loanDetailRepository;
			_booksList = new SelectList(
				_loanDetailRepository.GetAllBooks(),
				nameof(BookModel.BookId),
				nameof(BookModel.Title)
			);
		}

		// GET: LoanDetailController
		public ActionResult Index()
		{
			return View(_loanDetailRepository.GetAll());
		}

		// GET: LoanDetailController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: LoanDetailController/Create
		public ActionResult Create()
		{
			ViewBag.Books = _booksList;

			return View();
		}

		// POST: LoanDetailController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(LoanDetailModel loanDetail)
		{
			try
			{
				_loanDetailRepository.Add(loanDetail);

				TempData["message"] = "Datos guardados correctamente.";

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["message"] = ex.Message;

				ViewBag.Books = _booksList;

				return View(loanDetail);
			}
		}

		// GET: LoanDetailController/Edit/5
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var loanDetail = _loanDetailRepository.GetById(id);

			if (loanDetail == null)
			{
				return NotFound();
			}

			_booksList = new SelectList(
				_loanDetailRepository.GetAllBooks(),
				nameof(BookModel.BookId),
				nameof(BookModel.Title),
				loanDetail?.Book?.BookId
			);

			ViewBag.Books = _booksList;

			return View(loanDetail);
		}

		// POST: LoanDetailController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(LoanDetailModel loanDetail)
		{
			try
			{
				_loanDetailRepository.Edit(loanDetail);

				TempData["message"] = "Datos editados correctamente.";

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["message"] = ex.Message;

				ViewBag.Books = _booksList;

				return View(loanDetail);
			}
		}

		// GET: LoanDetailController/Delete/5
		[HttpGet]
		public ActionResult Delete(int id)
		{
			var loanDetail = _loanDetailRepository.GetById(id);

			if (loanDetail == null)
			{
				return NotFound();
			}

			return View(loanDetail);
		}

		// POST: LoanDetailController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(LoanDetailModel loanDetail)
		{
			try
			{
				_loanDetailRepository.Delete(loanDetail.DetailId);

				TempData["message"] = "Dato eliminado correctamente.";

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["message"] = ex.Message;

				return View(loanDetail);
			}
		}
	}
}
