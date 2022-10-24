using APIMiniProject.Models;

namespace APIMiniProject.Services;

public class EmployeeService : IEmployeeService
{
    private readonly NorthwindContext _context;
    public EmployeeService() => _context = new NorthwindContext();
    public EmployeeService(NorthwindContext context) => _context = context;
    
    public int CreateEmployee(Employee employeeDTO)
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateEmployeeAsync(Employee employeeDTO)
    {
        throw new NotImplementedException();
    }

    public void DeleteEmployee(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public bool EmployeeExists(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EmployeeExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Employee FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public List<Employee> GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public List<Territory> GetAllTerritoryFromOneEmployee(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Territory>> GetAllTerritoryFromOneEmployeeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Employee ReportsTo(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> ReportsToAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void SaveEmployeeChanges()
    {
        throw new NotImplementedException();
    }

    public Task SaveEmployeeChangesAsync()
    {
        throw new NotImplementedException();
    }
}