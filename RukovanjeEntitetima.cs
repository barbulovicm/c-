using System;

namespace Biletarnica
{
    static class RukovanjeEntitetima
    {
        /*
         * U ovu datoteku smo stavili sve funkcionalnosti koje se odnose na rukovanje
         * entitetima, ukljucujuci i sam meni za rukovanje entitetima. Liste u kojima
         * se nalaze podaci kojima rukujemo se ne nalaze u ovoj datoteci, vec u datoteci
         * Program.cs. U ovoj datoteci ima najvise koda, i to koda koji je dosta
         * repetitivan. Funkcije u ovoj datoteci bi se mogle reorganizovati i 
         * 'pametnije' napisati, ali nam to u ovom trenutku nije cilj posto bi
         * bile manje razumljive pocetnicima.
         */

        private static void DodavanjeOsoba()
        {
            Console.Write("Unesite ime osobe: ");
            string novoIme = Console.ReadLine();
            Console.Write("Unesite prezime osobe: ");
            string novoPrezime = Console.ReadLine();
            Console.Write("Unesite JMBG osobe: ");
            string noviJMBG = Console.ReadLine();

            Osoba novaOsoba = new Osoba(novoIme, novoPrezime, noviJMBG);
            Podaci.listaOsoba.Add(novaOsoba);
        }

        private static void DodavanjeDogadjaja()
        {
            Dogadjaj noviDogadjaj;

            int id = GenerisiNoviIdDogadjaja();
            Console.Write("Unesite tip dogadjaja (M za muzicki ili S za sportski: ");
            string tipDogadjaja = Console.ReadLine();

            Console.Write("Unesite naziv dogadjaja: ");
            string naziv = Console.ReadLine();
            Console.Write("Unesite mesto dogadjaja: ");
            string mesto = Console.ReadLine();
            Console.Write("Unesite vreme dogadjaja: ");
            string vreme = Console.ReadLine();

            if(tipDogadjaja == "M")
            {
                Console.Write("Unesite izvodjaca: ");
                string izvodjac = Console.ReadLine();
                Console.Write("Unesite zanr: ");
                string zanr = Console.ReadLine();

                noviDogadjaj = new MuzickiDogadjaj(id, naziv, mesto, vreme, izvodjac, zanr);
            }
            else
            {
                Console.Write("Unesite vrstu sporta: ");
                string vrstaSporta = Console.ReadLine();

                noviDogadjaj = new SportskiDogadjaj(id, naziv, mesto, vreme, vrstaSporta);
            }

            Podaci.listaDogadjaja.Add(noviDogadjaj);
        }

        private static void DodavanjeUlaznica()
        {
            Console.Write("Unesite cenu ulaznice: ");
            string cenaString = Console.ReadLine();
            double cena = double.Parse(cenaString);
            Console.Write("Unesite tip ulaznice (O ili V): ");
            string unosTipa = Console.ReadLine();
            TipUlaznice tip;
            if(unosTipa == "V")
            {
                tip = TipUlaznice.VIP;
            }
            else
            {
                tip = TipUlaznice.OBICNA;
            }
            Console.Write("Unesite id dogadjaja: ");
            string idDogadjajaString = Console.ReadLine();
            int idDogadjaja = int.Parse(idDogadjajaString);
            Dogadjaj dogadjaj = PronadjiDogadjajPoId(idDogadjaja);
            Console.Write("Unesite JMBG osobe: ");
            string jmbg = Console.ReadLine();
            Osoba osoba = PronadjiOsobuPoJMBG(jmbg);
            int id = GenerisiNoviIdUlaznice();
            Ulaznica novaUlaznica = new Ulaznica(id, cena, tip, dogadjaj, osoba);
            Podaci.listaUlaznica.Add(novaUlaznica);
        }

        private static void BrisanjeOsoba()
        {
            Console.Write("Unesite JMBG osobe koju treba obrisati iz sistema: ");
            string jmbg = Console.ReadLine();
            Osoba o = PronadjiOsobuPoJMBG(jmbg);
            Podaci.listaOsoba.Remove(o);
        }

        private static void BrisanjeDogadjaja()
        {
            Console.Write("Unesite id dogadjaja koji treba obrisati iz sistema: ");
            string idString = Console.ReadLine();
            int id = int.Parse(idString);
            Dogadjaj d = PronadjiDogadjajPoId(id);
            Podaci.listaDogadjaja.Remove(d);
        }

        private static void BrisanjeUlaznica()
        {
            Console.Write("Unesite id ulaznice koju treba obrisati iz sistema: ");
            string idString = Console.ReadLine();
            int id = int.Parse(idString);
            Ulaznica u = PronadjiUlaznicuPoId(id);
            Podaci.listaUlaznica.Remove(u);
        }

        private static int GenerisiNoviIdUlaznice()
        {
            int najveciId = -1;
            foreach(Ulaznica u in Podaci.listaUlaznica)
            {
                if(u.Id > najveciId)
                {
                    najveciId = u.Id;
                }
            }
            return najveciId + 1;
        }

        private static int GenerisiNoviIdDogadjaja()
        {
            int najveciId = -1;
            foreach(Dogadjaj d in Podaci.listaDogadjaja)
            {
                if(d.Id > najveciId)
                {
                    najveciId = d.Id;
                }
            }
            return najveciId + 1;
        }

        public static void MeniRukovanje()
        {
            Meni m = new Meni();
            m.DodajOpciju(DodavanjeOsoba, "Dodavanje nove osobe");
            m.DodajOpciju(DodavanjeDogadjaja, "Dodavanje novog dogadjaja");
            m.DodajOpciju(DodavanjeUlaznica, "Dodavanje nove ulaznice");
            m.DodajOpciju(BrisanjeOsoba, "Brisanje osobe");
            m.DodajOpciju(BrisanjeDogadjaja, "Brisanje dogadjaja");
            m.DodajOpciju(BrisanjeUlaznica, "Brisanje ulaznica");

            m.Pokreni();
        }

        public static Dogadjaj PronadjiDogadjajPoId(int idDogadjaja)
        {
            foreach (Dogadjaj d in Podaci.listaDogadjaja)
            {
                if (d.Id == idDogadjaja)
                {
                    return d;
                }
            }
            return null;
        }

        public static Osoba PronadjiOsobuPoJMBG(string jmbg)
        {
            foreach (Osoba o in Podaci.listaOsoba)
            {
                if (o.JMBG.Equals(jmbg))
                {
                    return o;
                }
            }
            return null;
        }

        public static Ulaznica PronadjiUlaznicuPoId(int id)
        {
            foreach(Ulaznica u in Podaci.listaUlaznica)
            {
                if(u.Id == id)
                {
                    return u;
                }
            }
            return null;
        }
    }
}