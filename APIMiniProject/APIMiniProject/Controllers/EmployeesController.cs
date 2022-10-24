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
        return new(await _employeeService.GetAllEmployeesAsync());
    }

    // GET: api/Employees/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
    {
        var employee = await _employeeService.FindByIdAsync(id);
        if (employee == null) return NotFound();
        return employee;
    }

    // PUT: api/Employees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee(int id, Employee employee)
    {
        if (id != employee.EmployeeId)
        {
            return BadRequest();
        }

        _employeeService.Entry(employee).State = EntityState.Modified;

        try
        {
            await _employeeService.SaveChangesAsync();
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
        _employeeService.Employees.Add(employee);
        await _employeeService.SaveChangesAsync();

        return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
    }

    // DELETE: api/Employees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _employeeService.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        _employeeService.Employees.Remove(employee);
        await _employeeService.SaveChangesAsync();

        return NoContent();
    }

    private bool EmployeeExists(int id)
    {
        return _employeeService.Employees.Any(e => e.EmployeeId == id);
    }
}