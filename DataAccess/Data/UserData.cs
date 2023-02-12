using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Threading;

namespace DataAccess.Data {
    public class UserData {
        private readonly string _connectionString;
        private ISqlDataAccess db = new SqlDataAccess();
        public UserData(string connectionString) {
            this._connectionString = connectionString;
        }

        public Task<IEnumerable<User>> GetUsers() {
            return db.Load<User, dynamic>("dbo.spPeople_GetAll", new { }, _connectionString);
        }

        public async Task<User> GetUserById(int id) {
            var output = await db.Load<User, dynamic>("dbo.spGet_People_By_Id", new { CustomerId = id }, _connectionString);
            return output.FirstOrDefault();
        }

        public Task InsertUser(User user) {
            return db.Save("dbo.spInsert_User", new { FirstName = user.First_Name, LastName = user.Last_Name, user.Phone, user.Email, user.Street, user.City, user.State, ZipCode = user.Zip_Code }, _connectionString);
        }

        public Task UpdateUser(User user) {
            return db.Save("dbo.spUpdate_User_By_Id", new { FirstName = user.First_Name, LastName = user.Last_Name, user.Phone, user.Email, user.Street, user.City, user.State, ZipCode = user.Zip_Code }, _connectionString);
        }

        public Task DeleteUser(int id) {
            return db.Save("dbo.spDelete_User_By_Id", new { CustomerId = id }, _connectionString);
        } 
    }
}
