using Hsbc.EmployeeManagement.BusinessEntities;
using Hsbc.EmployeeManagement.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsbc.EmployeeManagement.BusinessLogic
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string Authenticate(string username, string password)
        {
            return _employeeRepository.Authenticate(username, password);
        }

        public int Create(Employee employee)
        {
            return _employeeRepository.CreateEmployee(employee);
        }

        public bool Delete(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }
       
        public bool Update(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }
    }
}
