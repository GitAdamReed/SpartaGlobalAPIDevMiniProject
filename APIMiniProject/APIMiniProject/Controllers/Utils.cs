using APIMiniProject.Models;
using APIMiniProject.Models.DTOs;

namespace APIMiniProject.Controllers;

public class Utils
{
    public static EmployeeDTO EmployeeToEmployeeDTO(Employee employee) =>
        new EmployeeDTO
        {
            EmployeeId = employee.EmployeeId,
            LastName = employee.LastName,
            FirstName = employee.FirstName,
            Title = employee.Title,
            TitleOfCourtesy = employee.TitleOfCourtesy,
            BirthDate = employee.BirthDate,
            HireDate = employee.HireDate,
            Address = employee.Address,
            City = employee.City,
            Region = employee.Region,
            PostalCode = employee.PostalCode,
            Country = employee.Country,
            HomePhone = employee.HomePhone,
            Extension = employee.Extension,
            Notes = employee.Notes,
            ReportsTo = employee.ReportsTo,
            Territories = employee.Territories.Select(t => TerritoryToDTO(t)).ToList()
        };

    //We need this so that a user doesn't need 
    //to put an overwhelming amount of information in 
    //when using PUT
    public static TerritoryDTO TerritoryToDTO(Territory territory) =>
        new TerritoryDTO
        {
            TerritoryId = territory.TerritoryId,
            TerritoryDescription = territory.TerritoryDescription
        };

    public static Territory DTOToTerritory(TerritoryDTO territory) =>
        new Territory
        {
            TerritoryId = territory.TerritoryId,
            TerritoryDescription = territory.TerritoryDescription

        };

    public static Employee EmployeeDTOToEmployee(EmployeeDTO employee) =>
        new Employee
        {
            EmployeeId = employee.EmployeeId,
            LastName = employee.LastName,
            FirstName = employee.FirstName,
            Title = employee.Title,
            TitleOfCourtesy = employee.TitleOfCourtesy,
            BirthDate = employee.BirthDate,
            HireDate = employee.HireDate,
            Address = employee.Address,
            City = employee.City,
            Region = employee.Region,
            PostalCode = employee.PostalCode,
            Country = employee.Country,
            HomePhone = employee.HomePhone,
            Extension = employee.Extension,
            Notes = employee.Notes,
            ReportsTo = employee.ReportsTo,
            Territories = employee.Territories.Select(t => DTOToTerritory(t)).ToList()
        };
}