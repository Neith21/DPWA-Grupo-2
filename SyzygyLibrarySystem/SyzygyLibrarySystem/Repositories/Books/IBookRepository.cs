using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.Books
{
    public interface IBookRepository
    {
        void Add(BookModel book);
        void Delete(int id);
        void Edit(BookModel book);
        IEnumerable<BookModel> GetAll();
        IEnumerable<AuthorModel> GetAllAuthors();
        IEnumerable<PublisherModel> GetAllPublishers();
        BookModel? GetById(int id);
    }
}
