using System;
using AvioSaobracaj.modeli;

namespace AvioSaobracaj
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

        private static void PregledAviona()
        {
            Console.Clear();
            Console.WriteLine("id".PadRight(4)+"ime".PadRight(10)+"max putnika".PadRight(13)+"model");
            foreach (Avion a in Podaci.avioni)
            {
                Console.WriteLine(a);
            }
        }

        private static void PregledAeordroma()
        {
            foreach (Aerodrom a in Podaci.aerodromi)
            {
                Console.WriteLine(a);
            }
        }

        private static void PregledLetova()
        {
            foreach (Let l in Podaci.letovi)
            {
                Console.WriteLine(l);
            }
        }

        public static void MeniPregled()
        {
            Meni m = new Meni();
            m.DodajOpciju(PregledAviona, "Pregled svih aviona");
            m.DodajOpciju(PregledAeordroma, "Pregled svih aerodroma");
            m.DodajOpciju(PregledLetova, "Pregled svih letova");

            m.Pokreni();
        }
    }
}
