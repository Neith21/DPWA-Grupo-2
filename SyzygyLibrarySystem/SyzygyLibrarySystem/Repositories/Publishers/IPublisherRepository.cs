using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.Publishers
{
    public interface IPublisherRepository
    {
        void Add(PublisherModel publisher);
        void Delete(int id);
        void Edit(PublisherModel publisher);
        IEnumerable<PublisherModel> GetAll();
        PublisherModel? GetById(int id);
    }
}
