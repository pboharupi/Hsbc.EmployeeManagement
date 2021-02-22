using Hsbc.EmployeeManagement.BusinessEntities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hsbc.EmployeeManagement.DatabaseContext
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Department="HR",
                Designation="HR Manager",
                Email="HRManager@hsbc.com",
                FirstName="Admin",
                Id=101,
                IsDeleted=false,
                LastName="User",
                Password="admin@123",
                Role="Admin",
                UserName="admin"
            },
            new Employee
            {
                Department="IT",
                Designation="IT Manager",
                Email="ITManager@hsbc.com",
                FirstName="Employee",
                Id=102,
                IsDeleted=false,
                LastName="User",
                Password="User@123",
                Role="Employee",
                UserName="user"
            },
            new Employee
            {
                Department="IT",
                Designation="IT worker",
                Email="ITUser@hsbc.com",
                FirstName="Employee",
                Id=103,
                IsDeleted=false,
                LastName="worker",
                Password="Worker@123",
                Role="Worker",
                UserName="worker"
            }
        };
        public string Authenticate(string username, string password)
        {
            var employee = Get(username);
            if (employee == null)
            {
                return null;
            }
            if (employee.Password.Equals(password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwxyz");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject=new ClaimsIdentity(new Claim[] { 
                        new Claim(ClaimTypes.Name,employee.Id.ToString()),
                        new Claim(ClaimTypes.Role,employee.Role)
                    }),
                    Expires=DateTime.Now.AddDays(1),
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                employee.Token = tokenHandler.WriteToken(token);
                return employee.Token;
            }
            else
            {
                return null;
            }
        }

        public int CreateEmployee(Employee employee)
        {
            var emp = employees.OrderByDescending(a => a.Id).FirstOrDefault();
            if (emp == null)
            {
                employee.Id = 101;
                employees.Add(employee);
            }
            else
            {
                employee.Id = emp.Id + 1;
                employees.Add(employee);
            }
            return employee.Id;
        }

        public bool DeleteEmployee(int id)
        {
            var emp = GetEmployee(id);
            if (emp == null)
            {
                return false;
            }
            emp.IsDeleted = true;
            return UpdateEmployee(emp);
        }

        public Employee Get(string username)
        {
            return employees.SingleOrDefault(a => a.UserName == username);
        }

        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(a => a.Id == id);
        }


        public bool UpdateEmployee(Employee employee)
        {
            var emp = GetEmployee(employee.Id);
            if(emp==null)
            {
                return false;
            }
            employees.Remove(emp);
            employees.Add(employee);
            return false;
        }
    }
}
