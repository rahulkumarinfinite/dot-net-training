select * from emp
select * from dept
--1. Retrieve a list of MANAGERS. 
select * from emp
where job ='manager'

--2. employees earning more than 1000/month
select ename , salary from emp where salary > 1000

--3.employees name and salary except james
select * from emp where ename not in(select ename from  emp where ename='JAMES')

--4.Employees list whose name begins with 's'
select * from emp where ename like 's%'

--5.Emplyees name that contains a
select * from emp where ename like '%A%'

--6.Emplyees name that contains L as third character---
select * from emp where ename like '__[L]%'

--7.daily salary of JONES
select ename , (salary/30) as 'Daily Salary' from emp where ename='JONES'

--8. Total monthly salary of all employees
select   sum(salary ) as 'Total Monthly Salary'from emp

--9.Print the average annual salary
select avg(salary) as 'Annual Salary' from emp 

--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 
Select  ename, job, salary, deptno from emp where job not in(select job from emp where job='SALESMAN')

--11. List unique departments of the EMP table. 
select distinct e1.deptno ,d1.dname  from emp e1 , dept d1 where e1.deptno=d1.deptno

--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename as 'Employee Name', salary as 'Monthly Salary' from emp where salary > 1500 and deptno in (10, 30)

--13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000. 
select ename, job, salary from emp where job in ('manager', 'analyst') and salary not in (select salary from emp where salary=1000 or salary=3000 or salary= 5000)

--14. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 
select ename, salary, comm from emp where comm > (salary + (salary * 0.1))

--15. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782. 
select ename from emp where ename like ('%l%l%') and deptno = 30 or mgr_id = 7782

--16.Display the names of employees with experience of over 30 years and under 40 yrs. Count the total number of employees. 
select count(*)  from emp  where  DATEDIFF(year,hire_date,getdate()) between 30 and 40
  

--17.Retrieve the names of departments in ascending order and their employees in descending order. 
select d1.dname, e1.ename from dept d1 , emp e1 where e1.deptno = d1.deptno order by d1.dname , e1.ename desc 

--18. Find out experience of MILLER. 
select ename, datediff(year, hire_date, getdate())  from emp where ename = 'MILLER'