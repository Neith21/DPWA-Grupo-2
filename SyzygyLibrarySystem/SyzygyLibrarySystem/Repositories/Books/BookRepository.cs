using Dapper;
using System.Data;
using SyzygyLibrarySystem.Data;
using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public BookRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<AuthorModel> GetAllAuthors()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spAuthors_GetAll";

                return
                    connection.Query<AuthorModel>(
                        storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public IEnumerable<PublisherModel> GetAllPublishers()
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

		public IEnumerable<BookModel> GetAll()
		{
			using (var connection = _dataAccess.GetConnection())
			{
				string storedProcedure = "spBooks_GetAll";

				var books = connection.Query<BookModel, AuthorModel, PublisherModel, BookModel>
					(storedProcedure, (book, author, publisher) => {
						book.Author = author;
						book.Publisher = publisher;

						return book;
					},
					splitOn: "AuthorName,PublisherName",
					commandType: CommandType.StoredProcedure);

				return books;
			}
		}


		public BookModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spBooks_GetById";

                return
                    connection.QueryFirstOrDefault<BookModel>(
                        storeProcedure,
                        new { BookId = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(BookModel book)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spBooks_Insert";

                connection.Execute(
                    storeProcedure,
                    new { book.Title, book.AuthorId, book.PublisherId, book.PublicationYear, book.Genre, book.Quantity },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Edit(BookModel book)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spBooks_Update";

                connection.Execute(
                    storeProcedure,
                    new { book.BookId, book.Title, book.AuthorId, book.PublisherId, book.PublicationYear, book.Genre, book.Quantity },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spBooks_Delete";

                connection.Execute(
                    storeProcedure,
                    new { BookId = id },
                    commandType: CommandType.StoredProcedure
                );
            }

        }
    }
}
