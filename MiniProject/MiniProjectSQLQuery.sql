create database reservation
--Train 
create table Train(
TrainId int primary key identity(1,1),
TrainName varchar(100) not null,
Source varchar(100) not null,
Destination varchar(100),
TotalSeat int
);

--Customer

create table Customer(
CustomerId int Primary Key identity(1,1),
Name varchar(100) not null,
 Phone varchar(100) not null,
 MailId varchar(100) not null
 );

 --Reservation

 create table Reservation(
  BookingId int primary key identity(1,1),
 TrainId int foreign key references Train(TrainId),
 CustomerId int foreign key references Customer(CustomerId),
 DateOfTravel date not null,
 TotalCost float not null,
 DateOfBooking date default getdate(),
 );

 --Cancellation

 create table Cancellations( 
  BookingId int primary key foreign key references Reservation(BookingId),
  DateOfTravel date not null,
  AmtRefund int,
  DateOfCancellation date default getdate()
  );

  select * from Train
  select Count(*) from  Reservation where TrainId=3
 
  
  



