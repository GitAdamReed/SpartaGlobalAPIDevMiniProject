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
            ReportsTo = employee.ReportsTo
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
            ReportsTo = employee.ReportsTo
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