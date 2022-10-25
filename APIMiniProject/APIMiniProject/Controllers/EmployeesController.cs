using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIMiniProject.Services;
using APIMiniProject.Models.DTOs;
using NuGet.Protocol;

namespace APIMiniProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService supplierService)
    {
        _employeeService = supplierService;
    }

    // GET: api/Employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        var employeesDto = employees.Select(s => Utils.EmployeeToEmployeeDTO(s)).ToList();
        return employeesDto;
    }

    // GET: api/Employees
    [HttpGet("Navigation")]
    public ActionResult<string> GetNavigation()
    {
        return Utils.DisplayWelcome();
    }

    // GET: api/Employees/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
    {
        var employee = await _employeeService.FindByIdAsync(id);
        if (employee == null) return NotFound();
        return Utils.EmployeeToEmployeeDTO(employee);
    }

    // GET: api/Employees/5
    //You MUST have LastName/ Here otherwise it will 
    //Request multiple endpoints and break
    [HttpGet("LastName/{lastName}")]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByLastName(string lastName)
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        var employeesByName = employees
            .Where(e => e.LastName == lastName)
            .Select(e => Utils.EmployeeToEmployeeDTO(e))
            .ToList();
        return employeesByName;
    }

    // GET: api/Employees/5
    [HttpGet("FirstName/{firstName}")]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByFirstName(string firstName)
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        var employeesByName = employees
            .Where(e => e.FirstName == firstName)
            .Select(e => Utils.EmployeeToEmployeeDTO(e))
            .ToList();
        return employeesByName;
    }

    // GET: api/Employees/5
    [HttpGet("ReportsTo/{id}")]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByReportsTo(int id)
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        var employeesByBoss = employees
            .Where(e => e.ReportsTo == id)
            .Select(e => Utils.EmployeeToEmployeeDTO(e))
            .ToList();
        return employeesByBoss;
    }

    // PUT: api/Employees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee(int id, EmployeeDTO employee)
    {
        if (id != employee.EmployeeId) return BadRequest();
        if (!EmployeeExists(id)) return NotFound();

        var employeeToChange = await _employeeService.FindByIdAsync(id);
        _employeeService.ModifyState(employeeToChange);

        //I had to add these because we weren't actually changing anything
        employeeToChange.LastName = employee.LastName ?? employeeToChange.LastName;
        employeeToChange.FirstName = employee.FirstName ?? employeeToChange.FirstName;
        employeeToChange.Title = employee.Title ?? employeeToChange.Title;
        employeeToChange.TitleOfCourtesy = employee.TitleOfCourtesy ?? employeeToChange.TitleOfCourtesy;
        employeeToChange.BirthDate = employee.BirthDate ?? employeeToChange.BirthDate;
        employeeToChange.HireDate = employee.HireDate ?? employeeToChange.HireDate;
        employeeToChange.Address = employee.Address ?? employeeToChange.Address;
        employeeToChange.City = employee.City ?? employeeToChange.City;
        employeeToChange.Region = employee.Region ?? employeeToChange.Region;
        employeeToChange.PostalCode = employee.PostalCode ?? employeeToChange.PostalCode;
        employeeToChange.Country = employee.Country ?? employeeToChange.Country;
        employeeToChange.HomePhone = employee.HomePhone ?? employeeToChange.HomePhone;
        employeeToChange.Extension = employee.Extension ?? employeeToChange.Extension;
        employeeToChange.Notes = employee.Notes ?? employeeToChange.Notes;
        employeeToChange.ReportsTo = employee.ReportsTo ?? employeeToChange.ReportsTo;

        try
        {
            await _employeeService.SaveEmployeeChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeExists(id)) return NotFound();
            else throw;
        }
        return CreatedAtAction(
                nameof(GetEmployee),
                new { id = employee.EmployeeId },
                Utils.EmployeeToEmployeeDTO(await _employeeService.FindByIdAsync(id)));
    }

    // POST: api/Employees
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<EmployeeDTO>> PostEmployee(EmployeeDTO employeeDTO)
    {
        //Try to throw an error if User
        //enters primary key in DTO?
        //(proscribed)
        if (employeeDTO.ToJson().Contains("employeeId")) return BadRequest("Do not provide Primary Key employeeID; it will be generated for you");

        var employee = Utils.EmployeeDTOToEmployee(employeeDTO);

        await _employeeService.CreateEmployeeAsync(employee);
        return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
    }

    // DELETE: api/Employees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _employeeService.FindByIdAsync(id);
        if (employee == null) return NotFound();

        await _employeeService.DeleteEmployeeAsync(id);
        return NoContent();
    }

    private bool EmployeeExists(int id) => _employeeService.EmployeeExists(id);

    [HttpGet("Birthdays")]
    public async Task<ActionResult<IEnumerable<BirthdayDTO>>> GetBirthdays()
    {
        DateTime today = DateTime.Today;

        var birthdaysList = new List<DateTime>();
        var allEmps = _employeeService.GetAllEmployeesAsync().Result.ToList();
        var empsBirthday = allEmps.Select(s => Utils.EmployeeToBirthdayDTO(s)).ToList();
        var ordered = empsBirthday.OrderBy(e => e.UpcomingBirthday).ToList();
        return ordered;
    }
}