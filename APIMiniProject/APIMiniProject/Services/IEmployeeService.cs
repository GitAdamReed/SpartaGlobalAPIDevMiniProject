﻿using APIMiniProject.Models;

namespace APIMiniProject.Services;

public interface IEmployeeService
{
    //Get Employees List.
    List<Employee> GetAllEmployees();
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();

    //Get Employee by ID.
    Employee FindById(int id);
    Task<Employee> FindByIdAsync(int id);

    //Create Employees - Returns ID of Employee.
    void CreateEmployee(Employee employee); 
    Task CreateEmployeeAsync(Employee employee);

    //Delete Employee
    void DeleteEmployee(int id);
    Task DeleteEmployeeAsync(int id);

    //Employee Exists.
    bool EmployeeExists(int id);
    Task<bool> EmployeeExistsAsync(int id);

    //List of an Employee with all their terriories.
    List<Territory> GetAllTerritoryFromOneEmployee(int id);
    Task<IEnumerable<Territory>> GetAllTerritoryFromOneEmployeeAsync(int id);

    //Save Employee
    void SaveEmployeeChanges();
    Task SaveEmployeeChangesAsync();

    // Entry Method
    void ModifyState(Employee employee);
}