using Microsoft.EntityFrameworkCore;
using APIMiniProject.Models;
using APIMiniProject.Services;
using NUnit.Framework;

namespace APITests
{
    public class ServiceTests
    {
        private NorthwindContext _context;
        private IEmployeeService _sut;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase(databaseName: "Northwind").Options;
            _context = new NorthwindContext(options);
            _sut = new EmployeeService(_context);

            _context.Employees.Add(new Employee()
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Doe",
                City = "Liverpool"
            });

            _context.Employees.Add(new Employee()
            {
                EmployeeId = 2,
                FirstName = "Jane",
                LastName = "Doe",
                City = "London"
            });

            _context.SaveChanges();
        }

        [Category("FindByIdAsync")]
        [Category("Happy Path")]
        [Test]
        public async Task GivenAValidId_FindByIdAsync_ReturnsCorrectEmployee()
        {
            var result = await _sut.FindByIdAsync(1);

            Assert.That(result, Is.TypeOf<Employee>());
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
            Assert.That(result.City, Is.EqualTo("Liverpool"));
        }

        [Category("FindByIdAsync")]
        [Category("Sad Path")]
        [Test]
        public async Task GivenAnInvalidId_FindByIdAsync_ReturnsNull()
        {
            var result = await _sut.FindByIdAsync(-1);

            Assert.That(result, Is.Null);
        }

        [Category("GetAllEmployees")]
        [Test]
        public void GetAllEmployees_ReturnsCorrectNumberOfEmployees()
        {
            var employeeListLength = _context.Employees.Count();

            var result = _sut.GetAllEmployees();

            Assert.That(result, Is.TypeOf<List<Employee>>());
            Assert.That(result.Count, Is.EqualTo(employeeListLength));
        }

        //[Category("GetProductList")]
        //[Test]
        //public void GivenAValidId_GetProductsList_ReturnsCorrectNumberOfProducts()
        //{
        //    var productsListLength = _context.Products
        //        .Where(p => p.SupplierId == 31)
        //        .Count();

        //    var result = _sut.GetProductList(31);

        //    Assert.That(result, Is.TypeOf<List<Product>>());
        //    Assert.That(result.Count, Is.EqualTo(productsListLength));
        //}

        [Category("CreateEmployeeAsync")]
        [Test]
        public async Task GivenAValidEmployeeObject_CreateEmployeeAsync_AddsTheEmployeeToTheDatabase()
        {
            var newEmployee = new Employee
            {
                EmployeeId = 3,
                FirstName = "Rob",
                LastName = "Green",
                City = "Manchester"
            };

            await _sut.CreateEmployeeAsync(newEmployee);
            var employee = _context.Employees.Where(s => s.EmployeeId == newEmployee.EmployeeId).FirstOrDefault();

            Assert.That(employee, Is.TypeOf<Employee>());
            Assert.That(employee.FirstName, Is.EqualTo("Rob"));
            Assert.That(employee.LastName, Is.EqualTo("Green"));
            Assert.That(employee.City, Is.EqualTo("Manchester"));
        }

        [Category("DeleteEmployeeAsync")]
        [Test]
        public async Task GivenAVaildId_DeleteEmployeeAsync_RemovesCorrectEmployee()
        {
            var employeeToRemove = _context.Employees.Where(s => s.EmployeeId == 1).FirstOrDefault().EmployeeId;

            await _sut.DeleteEmployeeAsync(employeeToRemove);

            var result = _context.Employees.Where(s => s.EmployeeId == 1).FirstOrDefault();

            Assert.That(result, Is.Null);

            // Clean Up
            _context.Employees.Add(new Employee()
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Doe",
                City = "Liverpool"
            });
            await _context.SaveChangesAsync();
        }

        [Category("EmployeeExistsAsync")]
        [Category("Happy Path")]
        [Test]
        public void GivenAValidId_EmployeeExistsAsync_ReturnsTrue()
        {
            var result = _sut.EmployeeExistsAsync(1).Result;

            Assert.That(result, Is.True);
        }

        [Category("EmployeeExistsAsync")]
        [Category("Sad Path")]
        [Test]
        public void GivenAnInvalidId_EmployeeExistsAsync_ReturnsFalse()
        {
            var result = _sut.EmployeeExistsAsync(-1).Result;

            Assert.That(result, Is.False);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            _context.Dispose();
        }
    }
}