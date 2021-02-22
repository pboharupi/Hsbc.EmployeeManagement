using Hsbc.EmployeeManagement.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsbc.EmployeeManagement.BusinessLogic
{
   public interface IEmployeeManager
    {
        string Authenticate(string username, string password);
        int Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);
        
    }
}
