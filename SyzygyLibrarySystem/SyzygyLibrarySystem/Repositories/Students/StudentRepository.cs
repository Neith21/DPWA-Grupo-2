using Dapper;
using System.Data;
using SyzygyLibrarySystem.Data;
using SyzygyLibrarySystem.Models;

namespace SyzygyLibrarySystem.Repositories.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public StudentRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<StudentModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spStudents_GetAll";

                return
                    connection.Query<StudentModel>(
                        storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public StudentModel? GetById(string id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spStudents_GetById";

                return
                    connection.QueryFirstOrDefault<StudentModel>(
                        storeProcedure,
                        new { Code = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(StudentModel student)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spStudents_Insert";

                connection.Execute(
                    storeProcedure,
                    new { student.Code, student.StudentName, student.LastName, student.Address, student.Email, student.Phone },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Edit(StudentModel student)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spStudents_Update";

                connection.Execute(
                    storeProcedure,
                    student,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        public void Delete(string id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spStudents_Delete";

                connection.Execute(
                    storeProcedure,
                    new { Code = id },
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
