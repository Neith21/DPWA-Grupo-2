using Dapper;
using System.Data;
using SyzygyLibrarySystem.Data;
using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.Loans
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public LoanRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public int GetLast()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spLoans_GetLast";
                int lastLoanId;

                lastLoanId = connection.ExecuteScalar<int>(storeProcedure, commandType: CommandType.StoredProcedure);

                return lastLoanId;
            }
        }

        public IEnumerable<LoanModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spLoans_GetAll";

                return
                    connection.Query<LoanModel>(
                        storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public LoanModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spLoans_GetById";

                return
                    connection.QueryFirstOrDefault<LoanModel>(
                        storeProcedure,
                        new { LoanId = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(LoanModel loan)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spLoans_Insert";

                connection.Execute(
                    storeProcedure,
                    new { loan.StudentCode, loan.LoanDate, loan.ReturnDate, loan.LoanStatus },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Edit(LoanModel loan)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spLoans_Update";

                connection.Execute(
                    storeProcedure,
                    loan,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spLoans_Delete";

                connection.Execute(
                    storeProcedure,
					new { LoanId = id },
					commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
