using DataAccess.Data;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalAPIProject {
    class Program {
        static string cs = GetConnectionString();
        static UserData userData = new UserData(cs);
        static void Main(string[] args) {
            
            //GetAllUsers();

            //int Id = 10;
            //GetUserById(Id);

            User us = new User();
            us.First_Name = "Shaun";
            us.Last_Name = "Khan";
            us.Email = "shaun.khan@abc.com";
            us.City = "Poloski";
            us.Phone = "";
            us.State = "PO";
            us.Street = "vc green road";
            us.Zip_Code = "";
            InsertUserToDB(us);
            

            Console.ReadLine();
        }

        private static void InsertUserToDB(User us) {
            userData.InsertUser(us);
        }

        private static void GetUserById(int id) {
            var user = userData.GetUserById(id).Result;
            Console.WriteLine($"{user.First_Name} {user.Last_Name}");
        }

        private static void GetAllUsers() {
            var users = userData.GetUsers().Result;
            foreach (var user in users) {
                Console.WriteLine($"{user.First_Name} {user.Last_Name}");
            }
        }

        private static string GetConnectionString(string connectionStringName = "default") {
            string output = "";
            output = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            return output;
        }
    }
}
