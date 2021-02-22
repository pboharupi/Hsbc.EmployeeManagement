using Hsbc.EmployeeManagement.BusinessEntities;
using Hsbc.EmployeeManagement.BusinessLogic;
using Hsbc.EmployeeManagement.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Hsbc.EmployeeManagement.Tests.Controllers
{
    [TestClass]
   public class EmployeeControllerTest
    {
        [TestMethod]
        public void PostTest()
        {
            var request = new Employee
            {
                Department="Test",
                Designation="Test",
                Email="test@test.com",
                FirstName="test",
                IsDeleted=false,
                LastName="test",
                Password="test",
                Role="Employee",
                UserName="test"
            };
            int expectedResult = 104;
            Mock<IEmployeeManager> mockManager = new Mock<IEmployeeManager>();
            EmployeeController controller = new EmployeeController(mockManager.Object);
            mockManager.Setup(a => a.Create(request)).Returns(104);
            mockManager.Verify();
            var controllerResponse = controller.Post(request) as OkNegotiatedContentResult<int>;
            Assert.AreEqual(expectedResult, controllerResponse.Content);
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
            Mock<IEmployeeManager> mockManager = new Mock<IEmployeeManager>();
            EmployeeController controller = new EmployeeController(mockManager.Object);
            mockManager.Setup(a => a.Update(request)).Returns(true);
            mockManager.Verify();
            var controllerResponse = controller.Put(request.Id,request) as OkNegotiatedContentResult<bool>;
            Assert.IsTrue(controllerResponse.Content);
        }
        [TestMethod]
        public void DeleteTest()
        {
            var id = 103;
            Mock<IEmployeeManager> mockManager = new Mock<IEmployeeManager>();
            EmployeeController controller = new EmployeeController(mockManager.Object);
            mockManager.Setup(a => a.Delete(id)).Returns(true);
            mockManager.Verify();
            var controllerResponse = controller.Delete(id) as OkNegotiatedContentResult<bool>;
            Assert.IsTrue(controllerResponse.Content);
        }
        [TestMethod]
        public void TokenTest()
        {
            var id = 103;
            var username = "admin";
            var password = "admin@123";
            Mock<IEmployeeManager> mockManager = new Mock<IEmployeeManager>();
            EmployeeController controller = new EmployeeController(mockManager.Object);
            mockManager.Setup(a => a.Authenticate(username,password)).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEwMSIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTYxMzk3MzkyOCwiZXhwIjoxNjE0MDYwMzI4LCJpYXQiOjE2MTM5NzM5Mjh9.aU8MyZPm-VdAE8KeqMwFHUzDFrF52kr8vC-WcRVtlOY");
            mockManager.Verify();
            var controllerResponse = controller.Authenticate(username, password) as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(controllerResponse.Content);
        }
    }
}
