--use Zadatak02

--select pol,avg(broj_pregleda) as rezultat from ispitanici group by pol;

--select grad,avg(broj_pregleda) as rezultat from ispitanici group by grad;

--select grad,max(broj_pregleda) as rezultat from ispitanici group by grad;

--select grad,avg(starost) as rezultat from ispitanici group by grad;

--select avg(broj_pregleda) as rezultat from ispitanici where starost > 50 ;

--select pol,min(starost) as rezultat from ispitanici group by pol;

--select grad,count(id) from ispitanici group by grad;

--select grad,count(id) from ispitanici where pol = 'z' group by grad;--ZA ZAPAMTITI

--select grad,count(broj_pregleda) as result from ispitanici group by grad order by result asc;

--select id,ime,prezime,broj_pregleda ,grad from ispitanici join
--(select max(broj_pregleda) as result from ispitanici) dodatna
--on
--ispitanici.broj_pregleda = dodatna.result


--select top 1 grad,count(id) as result from ispitanici group by grad order by result desc 



