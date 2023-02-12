using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.DbAccess {
    public class SqlDataAccess : ISqlDataAccess{
        public async Task<IEnumerable<T>> Load<T, U>(string sqlStatement, U parameters, string connectionString) {
            using (IDbConnection connection = new SqlConnection(connectionString)) {
                return await connection.QueryAsync<T>(sqlStatement, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Save<T>(string storedProcedure, T parameter, string connectionString) {
            using (IDbConnection connection = new SqlConnection(connectionString)) {
                await connection.ExecuteAsync(storedProcedure, parameter, commandType: CommandType.StoredProcedure);
            }
        } 
    }
}
