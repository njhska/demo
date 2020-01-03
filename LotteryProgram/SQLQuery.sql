create database lottery
go
use lottery
go
create table Persons
(
	Id nvarchar(50) primary key not null,
	IdCard nvarchar(50),
	[Name] nvarchar(50),
	PhoneNumber nvarchar(50),
	[Level] int default 0,
	SelectedTime datetime
)
go