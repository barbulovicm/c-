use SportskiCentar

--select * from ljudi;
--select * from tereni;
--select * from rezervacije;

--select * from ljudi inner join rezervacije on
--	ljudi.jmbg = rezervacije.klijent;

--select * from rezervacije inner join ljudi on
--	rezervacije.klijent = ljudi.jmbg ;

--select * from rezervacije inner join tereni on
--	rezervacije.teren = tereni.oznaka;

--select * from rezervacije inner join ljudi on
--	rezervacije.klijent = ljudi.jmbg inner join tereni on
--		rezervacije.teren = tereni.oznaka;


--select * from rezervacije inner join ljudi on
--	rezervacije.klijent = ljudi.jmbg where ljudi.ime like '%mik%' 

--select * from ljudi where ljudi.jmbg in (select rezervacije.klijent from rezervacije) order by ime asc;

--select * from tereni where tereni.oznaka not in (select rezervacije.teren from rezervacije);
