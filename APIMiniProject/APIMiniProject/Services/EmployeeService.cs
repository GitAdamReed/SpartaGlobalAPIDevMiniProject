﻿using APIMiniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMiniProject.Services;

public class EmployeeService : IEmployeeService
{
    private readonly NorthwindContext _context;
    public EmployeeService() => _context = new NorthwindContext();
    public EmployeeService(NorthwindContext context) => _context = context;
    
    public void CreateEmployee(Employee employee) //Should be void or bool
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public async Task CreateEmployeeAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public void DeleteEmployee(int id)
    {
        _context.Employees.Remove(FindById(id));
        _context.SaveChanges();
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employeeToRemove = FindById(id);
        // Get all Territories that belong to the Employee to delete
        var employeeTerritories = employeeToRemove.Territories.ToList();
        // Loop through Territories list and access each Territories' Employee list
        // And remove the Employee from the list
        foreach (var item in employeeTerritories)
        {
            item.Employees.Remove(employeeToRemove);
        }
        _context.Employees.Remove(FindById(id));
        await _context.SaveChangesAsync();
    }

    public bool EmployeeExists(int id) => _context.Employees.Any(x => x.EmployeeId == id);
    
    public async Task<bool> EmployeeExistsAsync(int id)
    {
        var result = await _context.Employees.FindAsync(id);
        return result != null;
    }

    public Employee FindById(int id)
    {
        return _context.Employees.Find(id);
    }

    public async Task<Employee> FindByIdAsync(int id)
    {
        return await _context.Employees
                .Where(e => e.EmployeeId == id)
                .FirstOrDefaultAsync();
    }

    public List<Employee> GetAllEmployees()
    {
        return _context.Employees.ToList();
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public List<Territory> GetAllTerritoryFromOneEmployee(int id)
    {
        var emp = FindById(id);
        return emp.Territories.ToList();
    }

    public async Task<IEnumerable<Territory>> GetAllTerritoryFromOneEmployeeAsync(int id)
    {
        var emp = await FindByIdAsync(id);
        return emp.Territories.ToList();
    }

    public void SaveEmployeeChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveEmployeeChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void ModifyState(Employee employee)
    {
       _context.Entry(employee).State = EntityState.Modified;
    }
}