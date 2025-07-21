--1.	Write a T-SQL Program to find the factorial of a given number.
begin 
declare @a int=10,@b int =1,@res int=1
if @a<0
begin
print 'number is negative '
end
if @a=0
begin
print 'Factorial of 0 is 1'
end
else
begin
while @b<=@a
begin
set @res=@res*@b;
set @b=@b+1;
end
print 'Factorial of ' + cast(@a as varchar) + ' is ' + cast(@res as varchar)
end
end

--2.Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 
create or alter proc sp_multiplications  @a int,@b int 
as
begin
declare @res int,@c int=1
if(@a<=0 or @b<=0)
begin
print'Invalid numbers'
end
else
begin
while(@a>=@c)
begin
set @res=@c*@b
set @c=@c+1
print cast(@b as varchar)+ ' * '+cast(@a as varchar)+' is '+cast(@res as varchar)
end
end
end
exec sp_multiplications 10,4

/*3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

student table

Sid       Sname   
1         Jack
2         Rithvik
3         Jaspreeth
4         Praveen
5         Bisa
6         Suraj

Marks table

Mid      Sid     Score
1        1        23
2        6        95
3        4        98
4        2        17
5        3        53
6        5        13


*/
create table student(
Sid int primary key,
Sname varchar(20)
)
create table marks(
mid int primary key ,
Sid int 
foreign key references student,
score int
)
insert into student values
(1,'Jack'),
(2 , 'Rithvik'),
(3  , 'Jaspreeth'),
(4   , 'Praveen'),
(5   , 'Bisa'),
(6  , 'Suraj')

 insert into marks values
 (1      ,  1,        23),
(2       , 6  ,      95),
(3      ,  4   ,     98),
(4        ,2    ,    17),
(5       , 3     ,   53),
(6  ,      5 ,       13)

select *from student
select *from marks
create or alter function fn_displayDetails(@m int)
returns varchar(100)
as 
begin
declare @res varchar(10)
if(@m>=50)
begin
set @res='Pass'
end
else
begin
set @res='Fail'
end
return @res
end

select s.sid,s.sname,m.score,m.mid,dbo.fn_displayDetails(m.score) as 'status of student' from student s,marks m where s.Sid=m.Sid order by s.sid
