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

>GET

```html
<GET> /api/Employees - Retrieves all employees from the 'Employees' Table.
<GET> /api/Employees/{<id>} - Retrieves employee associated with the <id>.
<GET> /api/Employees/GetTheNearestBirthday - Retrieves a List of upcomming birthdays. 
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
