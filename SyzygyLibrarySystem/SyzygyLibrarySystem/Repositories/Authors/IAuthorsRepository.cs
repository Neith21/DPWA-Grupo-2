using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.Authors
{
    public interface IAuthorsRepository
    {
        void Add(AuthorModel author);
        void Delete(int id);
        void Edit(AuthorModel author);
        IEnumerable<AuthorModel> GetAll();
        AuthorModel? GetById(int id);
    }
}
