using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SyzygyLibrarySystem.Models;
using SyzygyLibrarySystem.Repositories.LoanDetails;
using SyzygyLibrarySystem.Repositories.Loans;

namespace SyzygyLibrarySystem.Controllers
{
	public class LoanController : Controller
	{
		private readonly ILoanRepository _loanRepository;

		public LoanController(ILoanRepository loanRepository)
		{
			_loanRepository = loanRepository;
		}

		// GET: LoanController
		public ActionResult Index()
		{
			return View(_loanRepository.GetAll());
		}

		// GET: LoanController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: LoanController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: LoanController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(LoanModel loan)
		{
			try
			{
				_loanRepository.Add(loan);

				TempData["message"] = "Datos guardados correctamente.";

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["message"] = ex.Message;

				return View(loan);
			}
		}

		// GET: LoanController/Edit/5
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var loan = _loanRepository.GetById(id);

			if (loan == null)
			{
				return NotFound();
			}

			return View(loan);
		}

		// POST: LoanController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(LoanModel loan)
		{
			try
			{
				_loanRepository.Edit(loan);

				TempData["message"] = "Datos editados correctamente.";

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["message"] = ex.Message;

				return View(loan);
			}
		}

		// GET: LoanController/Delete/5
		[HttpGet]
		public ActionResult Delete(int id)
		{
			var loan = _loanRepository.GetById(id);

			if (loan == null)
			{
				return NotFound();
			}

			return View(loan);
		}

		// POST: LoanController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(LoanModel loan)
		{
			try
			{
				_loanRepository.Delete(loan.LoanId);

				TempData["message"] = "Dato eliminado correctamente.";

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["message"] = ex.Message;

				return View(loan);
			}
		}
	}
}
