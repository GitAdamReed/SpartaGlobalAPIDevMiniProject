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

    public static string DisplayWelcome()
    {
        return @"
    __  ______     __  ___                                     __  __     __               
   / / / / __ \   /  |/  /___ _____  ____ _____ ____  _____   / / / /__  / /___  ___  _____
  / /_/ / /_/ /  / /|_/ / __ `/ __ \/ __ `/ __ `/ _ \/ ___/  / /_/ / _ \/ / __ \/ _ \/ ___/
 / __  / _, _/  / /  / / /_/ / / / / /_/ / /_/ /  __/ /     / __  /  __/ / /_/ /  __/ /    
/_/ /_/_/ |_|  /_/  /_/\__,_/_/ /_/\__,_/\__, /\___/_/     /_/ /_/\___/_/ .___/\___/_/     
                                        /____/                         /_/                 

GUIDE:

GET /Employees

POST /Employees

GET /Employees/{id}

PUT /Employees/{id}

DELETE /Employees/{id}

GET /Employees/LastName/{lastName}

GET /Employees/FirstName/{firstName}

GET /Employees/ReportsTo/{id}

GET /Employees/GetBirthdaysNearest

";
    }
}