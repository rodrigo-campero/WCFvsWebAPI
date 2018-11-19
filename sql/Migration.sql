PRINT N'Using master...';
GO
USE MASTER
GO
PRINT N'Creating CRUD...'; 
CREATE DATABASE CRUD
GO
PRINT N'Using CRUD...'; 
USE CRUD
GO
PRINT N'Creating table Employee...'; 
CREATE TABLE Employee
(
        EmployeeId int not null identity(1,1),

        Name varchar(60) not null,

        Email varchar(60) not null,

        Phone varchar(16) not null,

        Gender int not null
)
GO  
PRINT N'Alter table CRUD.PK_Employee_EmployeeId...';  
GO  
ALTER TABLE Employee  
    ADD CONSTRAINT [PK_Employee_EmployeeId] PRIMARY KEY CLUSTERED ([EmployeeId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);  
GO