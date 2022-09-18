# Employee-Management-System

**Description**

This is an employee management system. Departments, positions, and employees can be added to the system. Data that has been added to the system can also be viewed, searched, updated, and deleted. It should be noted that the first four Positions are unable to be deleted. This is to ensure that the structure of the organization remains intact. A navbar with the major functions of the system is present at the top of the page.

A hierarchical view of the data is shown on the landing page. The employees are shown under their respective positions. Each tab can be clicked to view the employees who belong to that position. Clicking on an employee will redirect the user to an update page for that particular employee.



Departments consist of DepartmentId, DepartmentName, and DepartmentDescription. Positions consist of PositionId, PositionName, and PositionDescription. A user can add an employee with the following properties: EmployeeId, EmployeeNumber, Name, Surname, BirthDate, Salary, PositionId, DepartmentId and ReportingLineManagerId.The program consists of an Angular frontend and an ASP.NET Core Web API backend. 
