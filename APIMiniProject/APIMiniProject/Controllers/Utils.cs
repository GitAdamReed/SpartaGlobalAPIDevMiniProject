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
            Territories = employee.Territories
        };

    public static BirthdayDTO EmployeeToBirthdayDTO(Employee employee) =>
       new BirthdayDTO
       {
           FirstName = employee.FirstName,
           LastName = employee.LastName,
           BirthDate = employee.BirthDate,
           UpcomingBirthdate = GetUpcomingBirthdate(employee)
       };

    private static DateTime GetUpcomingBirthdate(Employee e)
    {
        DateTime today = DateTime.Today;
        var diff = today.Year - e.BirthDate.Value.Year;
        var birthday = e.BirthDate.Value.AddYears(diff);
        if (birthday < today) birthday = birthday.AddYears(1);
        return birthday;
    }
}