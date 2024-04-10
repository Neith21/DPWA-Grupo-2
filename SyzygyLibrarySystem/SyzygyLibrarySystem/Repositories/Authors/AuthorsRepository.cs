using Dapper;
using System.Data;
using SyzygyLibrarySystem.Data;
using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.Authors
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public AuthorsRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<AuthorModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spAuthors_GetAll";

                return connection.Query<AuthorModel>(
                                        storedProcedure,
                                        commandType: CommandType.StoredProcedure);
            }
        }

        public AuthorModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spAuthors_GetById";

                return connection.QueryFirstOrDefault<AuthorModel>(
                                        storedProcedure,
                                        new { AuthorId = id },
                                        commandType: CommandType.StoredProcedure
                                        );
            }

        }

        public void Add(AuthorModel author)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spAuthors_Insert";

                connection.Execute(
                        storedProcedure,
                        new { author.AuthorName, author.Nationality, author.BirthDate },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(AuthorModel author)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spAuthors_Update";

                connection.Execute(
                        storedProcedure,
                        author,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "sp_AuthorsDelete";

                connection.Execute(
                        storedProcedure,
                        new { AuthorId = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

    }
}
