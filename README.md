# SpartaGlobalAPIDevMiniProject

>### Root Application Url: https://localhost:7056/
>### Swagger View Url: https://localhost:7056/swagger/index.html

<br>

### This API exposes useful information and functionality around the 'Employees' table from the 'Northwind' database. We have conducted Unit tests of the controller methods as well as the Service layer.
### ```Who worked on this project?```
### Jai
```
This has been my first project where I have worked with an API. This means a lot of new concepts have been learnt and with the help of my team, I have been able to understand the concepts fully. 
Learning about service layers, LINQ and Entity Framework has been a challenge but one I have been happy to deal with and have finally fully understood. As SCRUM master, I have been able to guide my team and keep the development cycle fast, efficient and everyone happy.
```
### Michael
```

```
### Adam R
```
While working on this project, I, alongside Tudor, created the service layer tests and controller tests. To accomplish this we used Moq and Entity Framework. This project helped deepen my understanding of mocking and testing different layers.
```
### Sahil
```
While working on this project, many things have been made clear about the topics that we covered over the past week or so. I was unsure why we performed an 'Dependency Injection' but now I have a clear understanding of it. I was also unsure about how we implimented a 'Service Layer' however, after working with my team a lot of questions were answered and now I have a clear understanding of a service layer and I feel confident in my ability to create one for myself.

Overall, working with my group allowed me to learn a lot and I would love to do this again.
```
### Tudor
```
While working on this project, I, alongside Adam, created the service layer tests and controller tests. To accomplish this we used Moq and Entity Framework. This project helped deepen my understanding of mocking and testing different layers.
```
### Robert
```
This project helped to solidify my knowledge of APIs and LINQ methods. I helped to implement the birthday requst by creating a BirthdayDTO with only fields relating to employees age and thier birthday.
```

<br>

# Different requests that you can make...

<br>

>POST

```html
<POST> /api/Employees - Creates the given employees passed via the body of the <POST> request, in the 'Employees' Table.
 ```

>GET

```html
<GET> /api/Employees/Navigation - Displays all the URL's and methods that have been implimented.
<GET> /api/Employees - Retrieves all employees from the 'Employees' Table.
<GET> /api/Employees/{<id>} - Retrieves employee associated with the <id>.
<GET> /api/Employees/LastName/{<LastName>} - Get all employees with the specified <LastName>.
<GET> /api/Employees/FirstName/{<FirstName>} - Get all employees with the specified <FirstName>.
<GET> /api/Employees/ReportsTo/{<id>} - Retrieves the employees who report to <id>.
<GET> /api/Employees/Birthdays - Retrieves a List of upcomming birthdays. 
 ```

>PUT

 ```html
 <PUT> /api/Employees/{<id>} - Updates the employee associated with the <id>.
 ```

>DELETE

```html
 <DELETE> /api/Employees/{<id>} - Deletes the employee associated with the <id>.
 ```

| Status Code |	Description: |
| --- | --- |
| 200 | `'OK'` |
| 201 | `'CREATED'` |
| 400 | `'BAD REQUEST'` |
| 404 | `'NOT FOUND'` |
| 500 | `'INTERNAL SERVER ERROR'` |
