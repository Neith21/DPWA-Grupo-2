using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.Loans
{
    public interface ILoanRepository
    {
        void Add(LoanModel loan);
        void Delete(int id);
        void Edit(LoanModel loan);
        IEnumerable<LoanModel> GetAll();
        LoanModel? GetById(int id);
    }
}
