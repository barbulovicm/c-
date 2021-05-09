use DotNetKurs

create table ispitanici(
	id int primary key identity(1,1),
	ime nvarchar(50),
	prezime nvarchar(50),
	broj_pregleda float NOT NULL,
	pol char(1),
	starost int,
	grad nvarchar(50));
