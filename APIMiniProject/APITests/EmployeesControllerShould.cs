using APIMiniProject.Controllers;
using APIMiniProject.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMiniProject.Models.DTOs;
using APIMiniProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace APITests
{
    public class EmployeesControllerShould
    {
        private EmployeesController? _sut;

        [Test]
        public void CanBeConstructed()
        {
            var mockService = new Mock<IEmployeeService>();
            _sut = new EmployeesController(mockService.Object);
            Assert.That(_sut, Is.InstanceOf<EmployeesController>());
        }

        [Test]
        public void GetEmployees_ReturnsExpected()
        {
            var mockService = new Mock<IEmployeeService>();
            IEnumerable<Employee> expected = new List<Employee>()
            {
                new Employee() { FirstName="Adam"}
            };

            mockService.Setup(ms => ms.GetAllEmployeesAsync()).Returns(Task.FromResult(expected));

            _sut = new EmployeesController(mockService.Object);
            var result = _sut.GetEmployees().Result.Value;

            Assert.That(_sut, Is.InstanceOf<EmployeesController>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Adam"));

            mockService.Verify(cs => cs.GetAllEmployeesAsync(), Times.Once);
        }

        [Test]
        public void WhenGivenValidId_GetEmployee_ReturnsExpected()
        {
            var mockService = new Mock<IEmployeeService>();
            var expected = new Employee()
            {
                FirstName = "Adam"
            };

            mockService.Setup(ms => ms.FindByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(expected));

            _sut = new EmployeesController(mockService.Object);
            var result = _sut.GetEmployee(It.IsAny<int>()).Result.Value;

            Assert.That(_sut, Is.InstanceOf<EmployeesController>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo("Adam"));

            mockService.Verify(cs => cs.FindByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void WhenGivenLastname_GetEmployeeByLastname_ReturnsExpected()
        {
            var mockService = new Mock<IEmployeeService>();
            IEnumerable<Employee> expected = new List<Employee>()
            {
                new Employee()
                {
                    LastName = "Reed"
                }
            };

            mockService.Setup(ms => ms.GetAllEmployeesAsync())
                .Returns(Task.FromResult(expected));

            _sut = new EmployeesController(mockService.Object);
            var result = _sut.GetEmployeesByLastName("Reed").Result.Value;

            Assert.That(_sut, Is.InstanceOf<EmployeesController>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().LastName, Is.EqualTo("Reed"));

            mockService.Verify(cs => cs.GetAllEmployeesAsync(), Times.Once);
        }

        [Test]
        public void WhenGivenFirstname_GetEmployeeByFirstname_ReturnsExpected()
        {
            var mockService = new Mock<IEmployeeService>();
            IEnumerable<Employee> expected = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "Adam"
                }
            };

            mockService.Setup(ms => ms.GetAllEmployeesAsync())
                .Returns(Task.FromResult(expected));

            _sut = new EmployeesController(mockService.Object);
            var result = _sut.GetEmployeesByFirstName("Adam").Result.Value;

            Assert.That(_sut, Is.InstanceOf<EmployeesController>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Adam"));

            mockService.Verify(cs => cs.GetAllEmployeesAsync(), Times.Once);
        }

        [Test]
        public void WhenGivenLastnameId_GetEmployeesByReportsTo_ReturnsExpected()
        {
            var mockService = new Mock<IEmployeeService>();
            IEnumerable<Employee> expected = new List<Employee>()
            {
                new Employee()
                {
                    ReportsTo = 1,
                    LastName = "Reed"
                }
            };

            mockService.Setup(ms => ms.GetAllEmployeesAsync())
                .Returns(Task.FromResult(expected));

            _sut = new EmployeesController(mockService.Object);
            var result = _sut.GetEmployeesByReportsTo(1).Result.Value;

            Assert.That(_sut, Is.InstanceOf<EmployeesController>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().LastName, Is.EqualTo("Reed"));

            mockService.Verify(cs => cs.GetAllEmployeesAsync(), Times.Once);
        }

        [Test]
        public void PutEmployee_ReturnsCreatedAtActionRequest()
        {
            var mockService = new Mock<IEmployeeService>();
            var newEmp = new Employee()
            {
                EmployeeId = 11,
                LastName = "Reed"
            };

            var newEmpDTO = new EmployeeDTO()
            {
                EmployeeId = 11,
                LastName = "Adam"
            };

            mockService.Setup(e => e.FindByIdAsync(newEmp.EmployeeId).Result).Returns(newEmp);
            mockService.Setup(e => e.EmployeeExists(11)).Returns(true);

            _sut = new EmployeesController(mockService.Object);
            var result = _sut.PutEmployee(11, newEmpDTO).Result;

            Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());

            mockService.Verify(e => e.ModifyState(It.IsAny<Employee>()), Times.Once);
            mockService.Verify(e => e.SaveEmployeeChangesAsync(), Times.Once);

        }

        [Test]
        public void PostEmployee_ReturnsCreatedAt_WithValidEmployee()
        {
            var mockService = new Mock<IEmployeeService>();
            var newEmpDTO = new EmployeeDTO()
            {          
                LastName = "Reed"
            };
            var newEmp = new Employee()
            {
                LastName = "Reed"
            };
         
            _sut = new EmployeesController(mockService.Object);
            var result = _sut.PostEmployee(newEmpDTO).Result;

            Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
        }
    }
}
