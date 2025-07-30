
CREATE TABLE Employee_Details (
    EmpId INT IDENTITY(1,1) PRIMARY KEY,  
    Name NVARCHAR(100) NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    Gender NVARCHAR(10) NOT NULL
);

CREATE or alter PROCEDURE InsertEmployeeDetails
    @Name NVARCHAR(100),
    @GivenSalary DECIMAL(10,2),
    @Gender NVARCHAR(10),
    @EmpId INT OUTPUT,
    @CalculatedSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

   
    SET @CalculatedSalary = @GivenSalary - (@GivenSalary * 0.10);
    INSERT INTO Employee_Details (Name, Salary, Gender)
    VALUES (@Name, @CalculatedSalary, @Gender);
    SET @EmpId = SCOPE_IDENTITY();
END
select *from Employee_Details