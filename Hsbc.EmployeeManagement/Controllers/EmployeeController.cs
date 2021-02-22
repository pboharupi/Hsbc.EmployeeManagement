using Hsbc.EmployeeManagement.BusinessEntities;
using Hsbc.EmployeeManagement.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hsbc.EmployeeManagement.Filters;
namespace Hsbc.EmployeeManagement.Controllers
{
    [Authorize]
    [RoutePrefix("api")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("v1/employee/login")]
        public IHttpActionResult Authenticate(string username,string password)
        {
            var token = _employeeManager.Authenticate(username, password);
            return Ok(token);
        }
        [HttpPost]
        [Route("v1/employee")]
        [Authorize(Roles = Role.Admin)]
        public IHttpActionResult Post(Employee employee)
        {
            var result = _employeeManager.Create(employee);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles ="Admin,Employee")]
        [Route("v1/employee/{employee.Id}")]
        public IHttpActionResult Put(Employee employee)
        {
            var result = _employeeManager.Update(employee);
            return Ok(result);
        }

        [HttpDelete]
        [Route("v1/employee/{id}")]
        [Authorize(Roles = "Admin,Employee")]
        public IHttpActionResult Delete(int id)
        {
            var result = _employeeManager.Delete(id);
            return Ok(result);
        }
        [HttpGet]
        [Route("v1/employee")]
        //[Authorize(Roles = Role.Admin)]
        //[Authorize(Roles = Role.Employee)]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var result = _employeeManager.GetAll();
            return Ok(result);
        }
    }
}
