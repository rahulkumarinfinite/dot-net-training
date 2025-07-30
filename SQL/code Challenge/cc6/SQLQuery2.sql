CREATE PROCEDURE UpdateEmployeeSalary
    @EmpId INT,
    @UpdatedSalary DECIMAL(10,2) OUTPUT,
    @Name NVARCHAR(100) OUTPUT,
    @Gender NVARCHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

  
    UPDATE Employee_Details
    SET Salary = Salary + 100
    WHERE EmpId = @EmpId;

 
    SELECT 
        @UpdatedSalary = Salary,
        @Name = Name,
        @Gender = Gender
    FROM Employee_Details
    WHERE EmpId = @EmpId;
END
