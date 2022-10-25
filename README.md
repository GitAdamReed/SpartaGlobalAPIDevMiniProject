# SpartaGlobalAPIDevMiniProject


>### Root Application Url: https://localhost:7056/
>### Swagger View Url: https://localhost:7056/swagger/index.html

<br>

### This API exposes useful information and functionality around the 'Employees' table from the 'Northwind' database. We have conducted Unit tests of the controller methods as well as the Service layer.
### ```Who worked on this project?```
### Jai
```

```
### Michael
```
Working on this project helped me to understand the praxis of API development and how powerful a tool Entity Framework can be when databasing. I tried to approach this project with a user's persepctive in mind, always developing and ideating against our end user's desires and requirements. In our case, our end user is the HR Manager of a company that was recently the subject of a scathing exposé, revealing a bully workplace culture connected to multiple underground corporate Fight Clubs. As part of an image rehabilitation campaign, they are very keen to make employees feel welcomed and appreciated, especially as it pertains to birthday celebrations. This is the purpose of our GetBirthdays request method. 

I contributed to the formation of get requests, including the requests that return collections of employees by FirstName or LastName etc. I also helped to form and repair the put request for employees and pared down our data objects to correspond to the data that a HR Manager would need--removing photopath strings etc. 

One thing I struggled with was implementing HATEOAS, which was part of our AC and DOD for many of our user stories. I added an employee Navigation request that yields a string with our bespoke API methods to help our end user as a substitute, but this is not hypermedia. I would have liked to successfully implement HATEOAS. I also had planned to include an array of type TerritoryDTO as part of our EmployeeDTO but I struggled to retrieve these successfully on GetRequests.
```
### Adam R
```

```
### Sahil
```
While working on this project, many things have been made clear about the topics that we covered over the past week or so. I was unsure why we performed an 'Dsependency Injection' but now I have a clear understanding of it. I was also unsure about how we implimented a 'Service Layer' however, after working with my team a lot of questions were answered and now I have a clear understanding of a service layer and I feel confident in my ability to create one for myself.

Overall, working with my group allowed me to learn a lot and I would love to do this again.
```
### Tudor
```

```
### Robert
```

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
