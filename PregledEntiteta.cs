using System;

namespace Biletarnica
{
    static class PregledEntiteta
    {
        /*
         * U ovu datoteku smo stavili sve funkcionalnosti koje se odnose da pregled 
         * entiteta, ukljucujuci i sam rad menija za pregled entiteta. Liste u kojima se 
         * nalaze podaci koji se ispisuju se ne nalaze u ovoj datoteci, vec u 
         * datoteci Podaci.cs.
         * 
         * Prirodno je da ova klasa bude staticka, posto sadrzi samo staticke metode i ne zelimo nikada da je nasledjujemo.
         */

        private static void PregledOsoba()
        {
            foreach (Osoba o in Podaci.listaOsoba)
            {
                Console.WriteLine(o);
            }
        }

        private static void PregledDogadjaja()
        {
            foreach (Dogadjaj d in Podaci.listaDogadjaja)
            {
                Console.WriteLine(d);
            }
        }

        private static void PregledUlaznica()
        {
            foreach (Ulaznica u in Podaci.listaUlaznica)
            {
                Console.WriteLine(u);
            }
        }

        public static void MeniPregled()
        {
            Meni m = new Meni();
            m.DodajOpciju(PregledDogadjaja, "Pregled svih dogadjaja");
            m.DodajOpciju(PregledOsoba, "Pregled svih osoba");
            m.DodajOpciju(PregledUlaznica, "Pregled svih ulaznica");

            m.Pokreni();
        }
    }
}
