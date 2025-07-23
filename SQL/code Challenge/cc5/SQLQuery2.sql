--Code Challenge 5




--1.	Write a query to display your birthday( day of week)
select datename(weekday,'2001-05-10') 

--2. Write a query to display your age in days
select datediff(day,'2001-05-10' ,getdate())

--3.	Write a query to display all employees information those who joined before 5 years in the current month
select * from emp where 5<DATEDIFF(year,hire_date,getdate())

--4.  Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
	--a. First insert 3 rows 
create table employ(
empno int primary key,
ename varchar(20),
sal decimal,
dateOfJoin date
);
begin 
transaction
insert into employ values
(100,'ram',5000,'2023-10-25'),
(101,'shyam',6000,'2023-11-25'),
(102,'ramesh',7000,'2024-10-25');
update employ
set sal=sal+sal*0.15
where empno=102
SELECT * FROM Employ;
save transaction t1
delete  employ  where empno=102
rollback transaction t1
COMMIT;
SELECT * FROM Employ;

select * from emp
---5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
	--a.     For Deptno 10 employees 15% of sal as bonus.
	--b.     For Deptno 20 employees  20% of sal as bonus
	--c      For Others employees 5%of sal as bonus

create or alter function fn_displayDetail(@m int,@sal int)
returns varchar(100)
as 
begin
declare @res varchar(10)
if(@m=10)
begin
set @res=@sal*0.15
end
if(@m=20)
begin
set @res=@sal*0.20
end
else
begin
set @res=@sal*0.05
end
return @res
end
select e.empno,e.ename,e.mgr_id,e.hire_date,e.salary,dbo.fn_displayDetail(e.deptno,e.salary) as 'bonus' from emp e
select * from emp

--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)

 create or alter proc sp_updates 
as
begin
update emp
    SET salary = salary + 500
    where deptno = (
        select deptno from dept where dname = 'Sales') and salary<1500
end
exec sp_updates

