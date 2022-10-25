using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIMiniProject.Models;
using APIMiniProject.Services;
using APIMiniProject.Models.DTOs;

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

    // GET: api/Employees/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
    {
        var employee = await _employeeService.FindByIdAsync(id);
        if (employee == null) return NotFound();
        return Utils.EmployeeToEmployeeDTO(employee);
    }

    // PUT: api/Employees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee(int id, Employee employee)
    {
        if (id != employee.EmployeeId) return BadRequest();
        if (!EmployeeExists(id)) return NotFound();

        var emp = await _employeeService.FindByIdAsync(id);

        _employeeService.ModifyState(employee);

        try
        {
            await _employeeService.SaveEmployeeChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Employees
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<EmployeeDTO>> PostEmployee(Employee employee)
    {
        await _employeeService.CreateEmployeeAsync(employee);
        return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
    }

    // DELETE: api/Employees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _employeeService.FindByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        await _employeeService.DeleteEmployeeAsync(id);
        return NoContent();
    }

    private bool EmployeeExists(int id)
    {
        return _employeeService.EmployeeExists(id);
    }

    [HttpGet("GetTheNearestBirthday")]
    public ActionResult<object> GetTheNearestBirthday()
    {
        //Get all the employees.
        var allEmps = _employeeService.GetAllEmployeesAsync().Result.ToList();
        //Get their birthdays.
        var birthdaysList = new List<int>();
        foreach (var e in allEmps)
        {
            var birthday = (DateTime)e.BirthDate;
            birthdaysList.Add(birthday.DayOfYear); //100, 56, 88, 251, ...
        }
        //Get the date today.
        var today = DateTime.Today;
        var todayInt = today.DayOfYear; //250
        //Get the difference in date(in days)
        int index = 0;
        int smallestNumber = 365;
        for (int i = 0; i < birthdaysList.Count; i++) 
        {
            birthdaysList[i] -= todayInt;
            if (birthdaysList[i] > 0)
                if (birthdaysList[i] < smallestNumber)
                {
                    smallestNumber = birthdaysList[i];
                    index = i;
                }
        }
        //find the smallest.
        var date = (DateTime)allEmps[index].BirthDate;
        return new { name = "nish", dob = date };
    }
}