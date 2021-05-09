use SportskiCentar

--create table ljudi(
--jmbg nvarchar(20) primary key,
--ime nvarchar(20),
--prezime nvarchar(20)
--);

--create table tereni(
--oznaka nvarchar(20) primary key,
--sport nvarchar(20)
--);


create table rezervacije(
rezervacije_id int primary key identity(1,1),
klijent nvarchar(20),
teren nvarchar(20),
termin nvarchar(20)
foreign key (klijent) references ljudi(jmbg),
foreign key (teren) references tereni(oznaka)
);

insert into ljudi(jmbg,ime,prezime)
values
--('0001','mika','mikic'),
--('0002','zika','zikic'),
--('0003','lika','likic')
('0004','tika','tikic')

insert into tereni(oznaka,sport)
values
--('ter1','fudbal'),
--('ter2','bejzbol'),
--('ter3','ragbi')
('ter4','golf')

insert into rezervacije(klijent,teren,termin)
values
('0001','ter1','01.01.2020'),
('0001','ter2','02.01.2020'),
('0002','ter3','01.03.2020'),
('0003','ter1','01.01.2020')