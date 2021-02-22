using Hsbc.EmployeeManagement.BusinessEntities;
using Hsbc.EmployeeManagement.DatabaseContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Hsbc.EmployeeManagement.BusinessLogic.Tests
{
    [TestClass]
   public class EmployeeManagerTest
    {
        [TestMethod]
        public void CreateTest()
        {
            var request = new Employee
            {
                Department = "Test",
                Designation = "Test",
                Email = "test@test.com",
                FirstName = "test",
                IsDeleted = false,
                LastName = "test",
                Password = "test",
                Role = "Employee",
                UserName = "test"
            };
            int expectedResult = 104;
            Mock<IEmployeeRepository> mockManager = new Mock<IEmployeeRepository>();
            EmployeeManager manager = new EmployeeManager(mockManager.Object);
            mockManager.Setup(a => a.CreateEmployee(request)).Returns(104);
            mockManager.Verify();
            var managerResponse = manager.Create(request);
            Assert.AreEqual(expectedResult, managerResponse);
        }
        [TestMethod]
        public void UpdateTest()
        {
            var request = new Employee
            {
                Department = "Test",
                Designation = "Test",
                Email = "test@test.com",
                FirstName = "test",
                IsDeleted = false,
                LastName = "test",
                Password = "test",
                Role = "Employee",
                UserName = "test",
                Id=103
            };
            Mock<IEmployeeRepository> mockManager = new Mock<IEmployeeRepository>();
            EmployeeManager manager = new EmployeeManager(mockManager.Object);
            mockManager.Setup(a => a.UpdateEmployee(request)).Returns(true);
            mockManager.Verify();
            var managerResponse = manager.Update(request);
            Assert.IsTrue(managerResponse);
        }
        [TestMethod]
        public void DeleteTest()
        {
            var id = 103;
            Mock<IEmployeeRepository> mockManager = new Mock<IEmployeeRepository>();
            EmployeeManager manager = new EmployeeManager(mockManager.Object);
            mockManager.Setup(a => a.DeleteEmployee(id)).Returns(true);
            mockManager.Verify();
            var managerResponse = manager.Delete(id);
            Assert.IsTrue(managerResponse);
        }
        [TestMethod]
        public void AuthenticateTest()
        {
            var username = "admin";
            var password = "admin@123";
            Mock<IEmployeeRepository> mockManager = new Mock<IEmployeeRepository>();
            EmployeeManager manager = new EmployeeManager(mockManager.Object);
            mockManager.Setup(a => a.Authenticate(username,password)).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEwMSIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTYxMzk3MzkyOCwiZXhwIjoxNjE0MDYwMzI4LCJpYXQiOjE2MTM5NzM5Mjh9.aU8MyZPm-VdAE8KeqMwFHUzDFrF52kr8vC-WcRVtlOY");
            mockManager.Verify();
            var managerResponse = manager.Authenticate(username, password);
            Assert.IsNotNull(managerResponse);
        }
    }
}
