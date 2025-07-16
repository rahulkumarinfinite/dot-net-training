/*
Create a book table with id as primary key and provide the appropriate data type to other attributes .isbn no should be unique for each book

Write a query to fetch the details of the books written by author whose name ends with er.
*/
--Question 1
--Books
create table book(
id int primary key,
title varchar(30) not null,
author varchar(20) not null,
isbn varchar(15) not null,
published_date datetime
)
insert into book values
(1,'My First SQL Book','Mary Parker','981483029127','2012-02-22 12:08:17'),
(2,'My Second SQL Book','John Mayer','8573300923713','1972-07-03 12:08:17'),
(3,'My Third SQL Book','Cary Flint','981483029127','2015-10-18 12:08:17')

select * from book where author like '%er'


















--Question2
--reviews
Create table review(
id int primary key,
book_id int,
reviewer_name varchar(30) not null,
content varchar(30) not null,
rating int not null,
published_date datetime not null
)

insert into review values
(1,1,'John Smith','My first review',4,'2017-12-10 05:50:11'),
(2,2,'John Smith','My second review',5,'2017-10-13 05:50:11'),
(3,2,'Alice Walker','Another review',1,'2017-10-22 05:50:11')

--Display the reviewer name who reviewed more than one book
select reviewer_name,content from reviews group by reviewer_name having count(book_id)>1 


--Question 3
--customer 
create table customers(
id int primary key,
Name varchar(30),
age int,
address varchar(20),
salary float
)

insert into customers values(
1,'ramesh',32,'ahmedabad',20000),
(2,'khilan',25,'delhi',1500),
(3,'kaushik',23,'kota',2000),
(4,'chaitali',25,'mumbai',6500),
(5,'hardik',27,'bhopal',8500)

--Display the Name for the customer from above customer table who live in same address which has character o anywhere in address
select Name from customers where address like '%o%'


--Question 4
--orders
create table orders(
oid int primary key,
dateOf date ,
Cid int
foreign key references customers(id),
amount float
)
insert into orders values

(102,'2009-10-08',3,3000),
 (100,'2009-10-08',3,1500),
  (101,'2009-11-20',2,1560)

--Write a query to display the Date,Total no of customer placed order on same Date
select dateOf,count(Cid) from orders group by dateOf having count(Cid)>1


--Question 5
create table employee(
id int primary key,
Name varchar(30),
age int,
address varchar(20),
salary float
)

insert into employee values(
1,'ramesh',32,'ahmedabad',20000),
(2,'khilan',25,'delhi',1500),
(3,'kaushik',23,'kota',2000),
(4,'chaitali',25,'mumbai',6500),
(5,'hardik',27,'bhopal',8500),
(6,'komal',24,'indore',null)

select lower(Name) from Employee where Salary=null 