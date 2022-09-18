# Employee-Management-System

**Description**

This is an employee management system. Departments, positions, and employees can be added to the system. The program consists of an Angular frontend and an ASP.NET Core Web API backend.  Data that has been added to the system can also be viewed, searched, updated, and deleted. It should be noted that the first four Positions are unable to be deleted. This is to ensure that the structure of the organization remains intact. A navbar with the major functions of the system is present at the top of the page.

A hierarchical view of the data is shown on the landing page. The employees are shown under their respective positions. Each tab can be clicked to view the employees who belong to that position. Clicking on an employee will redirect the user to an update page for that particular employee.

Departments consist of DepartmentId, DepartmentName, and DepartmentDescription. Positions consist of PositionId, PositionName, and PositionDescription. A user can add an employee with the following properties: EmployeeId, EmployeeNumber, Name, Surname, BirthDate, Salary, PositionId, DepartmentId and ReportingLineManagerId. DepartmentId and ReportingLineManagerId may not be added for the positions CEO or COO. ReportingLineManagerId may not be added for the positions Head of Department and Reporting Line Manager. Any other position created through the system must have a reporting line manager and a department.

The user can use the search bars above the tables to search for a specific employee, department or position. The page must be refreshed if the user wants to view the unfiltered data. Clicking on the table headings for the Employee table will sort the data according to that heading. Clicking on the pencil icon in any of the tables will redirect the user to an update page for the selected item. Clicking the trash can icon will prompt the user to confirm if they want to delete the selected item. Upon confirmation, the item will be deleted from the system. Due to referential integrity constraints, some positions or roles may not be deleted until there are no employees that belong to them.

**Coding Techniques**
The API is an ASP.NET Core Web API created in Visual Studio and coded in C#. It was designed using 3 tier architecture. The data layer was made using an external SQL database. The data layer was made using a repository and an interface. The presentation layer is the Angular frontend.
