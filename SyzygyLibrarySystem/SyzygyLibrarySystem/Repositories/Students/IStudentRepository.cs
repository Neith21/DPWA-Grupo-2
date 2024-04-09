using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.Students
{
    public interface IStudentRepository
    {
        void Add(StudentModel student);
        void Delete(string id);
        void Edit(StudentModel student);
        IEnumerable<StudentModel> GetAll();
        StudentModel? GetById(string id);
    }
}
