using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using SyzygyLibrarySystem.Models;
using SyzygyLibrarySystem.Repositories.LoanDetails;
using SyzygyLibrarySystem.Repositories.Loans;

namespace SyzygyLibrarySystem.Controllers
{
	public class LoanController : Controller
	{
        private readonly ILoanRepository _loanRepository;
        private readonly ILoanDetailRepository _loanDetailRepository;

		public LoanController(ILoanRepository loanRepository, ILoanDetailRepository loanDetailRepository)
		{
			_loanRepository = loanRepository;
			_loanDetailRepository = loanDetailRepository;
		}

		// GET: LoanController
		public ActionResult Index()
        {
            return View(_loanRepository.GetAll());
        }

        public ActionResult GetAllLoanDetails(int id)
        {
			ViewBag.LoanId = id;
			return View(_loanDetailRepository.GetSpecificById(id));
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
            catch (SqlException ex) when (ex.Number == 547)
            {
                TempData["message"] = "Posiblemente el estudiante no esté registrado.";

                return View(loan);
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
