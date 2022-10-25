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

    public static BirthdayDTO EmployeeToBirthdayDTO(Employee employee) =>
       new BirthdayDTO
       {
           FirstName = employee.FirstName,
           LastName = employee.LastName,
           BirthDate = employee.BirthDate,
           UpcomingBirthday = GetUpcomingBirthday(employee),
           Age = GetAge(employee)
       };

    private static DateTime GetUpcomingBirthday(Employee e)
    {
        DateTime today = DateTime.Today;
        var diff = today.Year - e.BirthDate.Value.Year;
        var birthday = e.BirthDate.Value.AddYears(diff);
        if (birthday < today) birthday = birthday.AddYears(1);
        return birthday;
    }

    private static int GetAge(Employee e)
    {
        var today = DateTime.Today;
        var age = today.Year - e.BirthDate.Value.Year;
        if (e.BirthDate.Value.Date > today.AddYears(-age)) age--;
        return age;
    }
}