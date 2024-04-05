using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.LoanDetails
{
	public interface ILoanDetailRepository
	{
		void Add(LoanDetailModel loanDetail);
		void Delete(int id);
		void Edit(LoanDetailModel loanDetail);
		IEnumerable<LoanDetailModel> GetAll();
		IEnumerable<BookModel> GetAllBooks();
		LoanDetailModel? GetById(int id);
	}
}
