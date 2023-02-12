using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DbAccess {
    public interface ISqlDataAccess {
        Task<IEnumerable<T>> Load<T, U>(string sqlStatement, U parameters, string connectionString);
        Task Save<T>(string storedProcedure, T parameter, string connectionString);
    }
}