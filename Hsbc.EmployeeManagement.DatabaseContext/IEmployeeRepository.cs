using Hsbc.EmployeeManagement.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsbc.EmployeeManagement.DatabaseContext
{
   public interface IEmployeeRepository
    {
        string Authenticate(string username, string password);
        int CreateEmployee(Employee employee);
        Employee GetEmployee(int id);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
        Employee Get(string username);
        IEnumerable<Employee> GetEmployees();
    }
}
