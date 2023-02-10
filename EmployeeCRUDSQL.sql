create table tblEmployee(
id int primary key identity(1,1),
Name varchar(40),
Mobile varchar(20),
Email varchar(40),
City varchar(40),
Gender varchar(10),
Salary numeric(10,2),
IsActive int)