using System.Data;

namespace SyzygyLibrarySystem.Data
{
    public interface ISqlDataAccess
    {
        IDbConnection GetConnection();
    }
}
