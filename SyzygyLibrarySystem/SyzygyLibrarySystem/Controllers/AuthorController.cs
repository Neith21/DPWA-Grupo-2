using Microsoft.AspNetCore.Mvc;
using SyzygyLibrarySystem.Models;
using SyzygyLibrarySystem.Repositories.Authors;

namespace SyzygyLibrarySystem.Controllers
{
	public class AuthorController : Controller
	{
		private readonly IAuthorsRepository _authorsRepository;

		public AuthorController(IAuthorsRepository authorsRepository)
		{
			_authorsRepository = authorsRepository;
		}

		public ActionResult Index()
		{
			return View(_authorsRepository.GetAll());
		}

		public ActionResult Details(int id)
		{
			return View();
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AuthorModel author)
		{
			try
			{
				_authorsRepository.Add(author);

				TempData["message"] = "Datos guardados exitsamente";

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["message"] = ex.Message;
				return View(author);
			}
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var author = _authorsRepository.GetById(id);

			if (author == null)
			{
				return NotFound();
			}

			return View(author);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(AuthorModel author)
		{
			try
			{
				_authorsRepository.Edit(author);

				TempData["message"] = "Datos editados correctamente";

				return RedirectToAction(nameof(Index));
			}

			catch (Exception ex)
			{
				return View(author);
			}
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var author = _authorsRepository.GetById(id);

			if (author == null)
			{
				return NotFound();
			}

			return View(author);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(AuthorModel author)
		{
			try
			{
				_authorsRepository.Delete(author.AuthorId);

				TempData["message"] = "Datos eliminados correctamente";

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
                TempData["message"] = ex.Message;

                return View(author);
			}
		}


	}
}
