﻿using Dapper;
using System.Data;
using SyzygyLibrarySystem.Data;
using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.LoanDetails
{
    public class LoanDetailRepository : ILoanDetailRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public LoanDetailRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spDBooks_GetAll";

                return
                    connection.Query<BookModel>(
                        storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

		public IEnumerable<LoanDetailModel> GetSpecificById(int id)
		{
			using (var connection = _dataAccess.GetConnection())
			{
				string storedProcedure = "spLoanDetails_GetAllSpecific";

				var loanDetails = connection.Query<LoanDetailModel, BookModel, LoanDetailModel>(
					storedProcedure,
					(loanDetail, book) =>
					{
						loanDetail.Book = book;
						return loanDetail;
					},
					splitOn: "Title",
					commandType: CommandType.StoredProcedure,
					param: new { LoanId = id }
				);

				// Filtrar la colección de loanDetails para devolver solo los detalles de préstamo con el ID especificado
				return loanDetails.Where(detail => detail.LoanId == id);
			}
		}

		public IEnumerable<LoanDetailModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spLoanDetails_GetAll";

                var loanDetails = connection.Query<LoanDetailModel, BookModel, LoanDetailModel>
                    (storedProcedure, (loanDetail, book) => {
                        loanDetail.Book = book;

                        return loanDetail;
                    },
                    splitOn: "Title",
                    commandType: CommandType.StoredProcedure);

                return loanDetails;
            }
        }

        public LoanDetailModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spLoanDetails_GetById";

                return
                    connection.QueryFirstOrDefault<LoanDetailModel>(
                        storeProcedure,
                        new { DetailId = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(LoanDetailModel loanDetail)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spLoanDetails_Insert";

                connection.Execute(
                    storeProcedure,
                    new { loanDetail.LoanId, loanDetail.BookId, loanDetail.Quantity },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Edit(LoanDetailModel loanDetail)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spLoanDetails_Update";

                connection.Execute(
                    storeProcedure,
                    new { loanDetail.DetailId, loanDetail.LoanId, loanDetail.BookId, loanDetail.Quantity },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spLoanDetails_Delete";

                connection.Execute(
                    storeProcedure,
                    new { DetailId = id },
                    commandType: CommandType.StoredProcedure
                );
            }

        }
    }
}
