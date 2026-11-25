using EmployeeDataAccess;
using System;
using System.Linq;

namespace WebAPIDemo.Infrastructure
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (EmployeeEntities entities = new EmployeeEntities())
            {
                return entities.Users.Any(user =>
                       user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.Password == password);
            }
        }
    }
}