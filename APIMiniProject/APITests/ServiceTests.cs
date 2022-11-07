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

        [Category("FindById")]
        [Category("Happy Path")]
        [Test]
        public async Task GivenAValidId_FindById_ReturnsCorrectEmployeeAsync()
        {
            var result = _sut.FindByIdAsync(1).Result;

            Assert.That(result, Is.TypeOf<Employee>());
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
            Assert.That(result.City, Is.EqualTo("Liverpool"));
        }

        [Category("FindById")]
        [Category("Sad Path")]
        [Test]
        public async Task GivenAnInvalidId_FindById_ReturnsNullAsync()
        {
            var result = _sut.FindByIdAsync(-1).Result;

            Assert.That(result, Is.Null);
        }

        [Category("GetAllEmployees")]
        [Test]
        public void GetAllEmployees_ReturnsCorrectNumberOfEmployees()
        {
            var supplierListLength = _context.Employees.Count();

            var result = _sut.GetAllEmployees();

            Assert.That(result, Is.TypeOf<List<Employee>>());
            Assert.That(result.Count, Is.EqualTo(supplierListLength));
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

        [Category("CreateEmployee")]
        [Test]
        public async Task GivenAValidSupplierObject_CreateEmployee_AddsTheSupplierToTheDatabase()
        {
            var newSupplier = new Employee
            {
                EmployeeId = 3,
                FirstName = "Rob",
                LastName = "Green",
                City = "Manchester"
            };

            await _sut.CreateEmployeeAsync(newSupplier);
            var supplier = _context.Employees.Where(s => s.EmployeeId == newSupplier.EmployeeId).FirstOrDefault();

            Assert.That(supplier, Is.TypeOf<Employee>());
            Assert.That(supplier.FirstName, Is.EqualTo("Rob"));
            Assert.That(supplier.LastName, Is.EqualTo("Green"));
            Assert.That(supplier.City, Is.EqualTo("Manchester"));
        }

        //[Category("CreateEmployee")]
        //[Test]
        //public async Task GivenAValidSupplierObject_CreateEmployee_ReturnsCorrectSupplierId()
        //{
        //    var newSupplier = new Supplier
        //    {
        //        SupplierId = 33,
        //        CompanyName = "Sparta Global",
        //        ContactName = "Another Supplier",
        //        ContactTitle = "Mr",
        //        City = "Manchester"
        //    };

        //    var result = _sut.CreateSupplier(newSupplier).Result;

        //    Assert.That(result, Is.EqualTo(newSupplier.SupplierId));
        //}

        [Category("RemoveSupplier")]
        [Test]
        public async Task GivenAVaildId_DeleteEmployeeAsync_RemovesCorrectSupplier()
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
        }

        [Category("SupplierExists")]
        [Test]
        public void GivenAValidId_EmployeeExistsAsync_ReturnsTrue()
        {
            var result = _sut.EmployeeExistsAsync(1).Result;

            Assert.That(result, Is.True);
        }

        [Category("SupplierExists")]
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