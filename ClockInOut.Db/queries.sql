--1. Ask for the name
--2. Show at which time he clocked in
--3. Ask for the name again
--4a. When a different name is input -> 2
--4b. When clocked in name is given -> 5
--4c. When no name is supplied -> 6
--5. Show date clocked out
--6. Show message that name has to be given -> 1
--7. After clocking in or out, show who's still clocked in
--8. (Bonus) show the clock duration when clocking out

create database ClockInOut
go

use ClockInOut
go

create table ClockEvent (
	Id int identity not null primary key,
	Name varchar(255) not null,
	InAt datetime2 not null,
	OutAt datetime2 null
)
go

select *
from ClockEvent
go

insert into ClockEvent (Name, InAt)
values
('Jean-Paul', GETDATE())
go

update ClockEvent
set OutAt = GETDATE()
where Id = 2
go

select *
from ClockEvent
where Id = 2
go

delete from ClockEvent
where Id = 3
go

create table Employee (
	Id int identity primary key not null,
	Name varchar(255)
	)
	go

insert into Employee (Name)
select distinct Name
from ClockEvent
go

select *
from Employee
go

alter table ClockEvent
add EmployeeId int null
go

update ce
set ce.EmployeeId = e.Id
from ClockEvent ce
inner join Employee e
	on e.Name = ce.Name
go

select *
from ClockEvent
go

alter table ClockEvent
add foreign key (EmployeeId) references Employee (Id)
go

insert into Employee (Name)
values
('Loes')
go

insert into ClockEvent (Name, EmployeeId, InAt)
values
('die moet weg', 3, GETDATE())

select EmployeeId, InAt, e.Name
from ClockEvent ce
inner join Employee e
	on e.Id = ce.EmployeeId

