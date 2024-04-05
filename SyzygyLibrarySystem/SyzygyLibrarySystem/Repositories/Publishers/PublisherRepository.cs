using Dapper;
using System.Data;
using SyzygyLibrarySystem.Data;
using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.Publishers
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public PublisherRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<PublisherModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spPublishers_GetAll";

                return
                    connection.Query<PublisherModel>(
                        storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public PublisherModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spPublishers_GetId";

                return
                    connection.QueryFirstOrDefault<PublisherModel>(
                        storeProcedure,
                        new { Id = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(PublisherModel publisher)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spPublishers_Insert";

                connection.Execute(
                    storeProcedure,
                    new { publisher.PublisherName, publisher.Country },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Edit(PublisherModel publisher)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spPublishers_Update";

                connection.Execute(
                    storeProcedure,
                    publisher,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spPublishers_Delete";

                connection.Execute(
                    storeProcedure,
					new { Id = id },
					commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
