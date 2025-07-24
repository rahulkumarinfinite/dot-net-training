--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

 --  a) HRA as 10% of Salary
 --  b) DA as 20% of Salary
 --  c) PF as 8% of Salary
  -- d) IT as 5% of Salary
  -- e) Deductions as sum of PF and IT
   --f) Gross Salary as sum of Salary, HRA, DA
  -- g) Net Salary as Gross Salary - Deductions
--Print the payslip neatly with all details
create or alter proc sp_payslip(@empid int)
as
begin
declare @HRA int,@DA int,@PF int,@IT int,@deductions int,@Gross int,@net int
if(@empid is null)
begin
raiserror('Employee ID should not be null',15,1)
end
else
begin
declare @sal int
select @sal=salary from emp where empno=@empid
if(@sal is null)
begin
raiserror('Salary must be positive and not null',16,1)
end
else
begin
set @HRA=@sal*0.1
set @DA=@sal*0.2
set @PF=@sal*0.05
set @IT=@sal*0.08
set @deductions=@PF+@IT
set @Gross=@HRA+@DA+@sal
set @net=@Gross-@deductions

print'HRA of employee is '+cast(@HRA as varchar)
print'DA of employee is '+cast(@DA as varchar)
print'PF of employee is '+cast(@PF as varchar)
print'IT of employee is '+cast(@IT as varchar)
print'Deductions of employee is '+cast(@deductions as varchar)
print'Gross total of employee is '+cast(@Gross as varchar)
print'Net salary of employee is '+cast(@net as varchar)
end
end
end

 exec sp_payslip @empid=108

 --2.  Create a trigger to restrict data manipulation on EMP table during General holidays. 
 --Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali",
 --you cannot manipulate" etc

--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details.
--try to match and stop manipulation 
create table holiday(
holiday_date date,
holiday_name varchar(20)
)

insert into holiday values
('2025-10-10','diwali'),
('2025-09-13','dashahara'),
('2025-08-15','independence day'),
('2026-03-20','holi')

select * from holiday

create or alter trigger tr_manipulate
on
emp
for update,insert,delete
as
begin
declare @a date,@b varchar(20)
select @a=holiday_date,@b=holiday_name from holiday where holiday_date=getdate()
if(@a is null)
begin
declare @e varchar(20)
set @e='Due to '+@b+' you cannot manipulate data'
raiserror(@e,15,1)
end
end







 

