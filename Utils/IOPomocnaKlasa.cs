using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin05.Primer4.Utils
{
    class IOPomocnaKlasa
    {
        //citanje promenljive string
        public static string OcitajTekst()
        {
            string tekst = "";
            while (tekst == null || tekst.Equals("")) //stringovi se mogu porediti i sa preklopljenim operatorom ==
            { 
                tekst = Console.ReadLine();
            }
            return tekst;
        }

        //citanje promenljive Int32
        public static int OcitajCeoBroj()
        {
            int broj;
            while (Int32.TryParse(Console.ReadLine(), out broj) == false)
            {
                Console.Write("GRESKA - Pogresno unsesena vrednost, pokusajte ponovo: ");
            }
            return broj;
        }

        //citanje promenljive float
        public static float ocitajRealanBroj()
        {
            float broj;
            while (Single.TryParse(Console.ReadLine(), out broj) == false)
            {
                Console.Write("GRESKA - Pogresno unsesena vrednost, pokusajte ponovo: ");
            }
            return broj;
        }

        //citanje promenljive char
        public static char OcitajKarakter()
        {
            char broj;
            while (Char.TryParse(Console.ReadLine(), out broj) == false)
            {
                Console.Write("GRESKA - Pogresno unsesena vrednost, pokusajte ponovo: ");
            }
            return broj;
        }

        //odluka + tekst - da ili ne
        public static bool Potvrdi(string tekst)
        {
            Console.WriteLine("Da li zelite " + tekst + " [d/n]:");
            char odluka = ' ';
            while (!(odluka == 'd' || odluka == 'n'))
            {
                odluka = Char.ToLower(OcitajKarakter());
                if (!(odluka == 'd' || odluka == 'n'))
                {
                    Console.WriteLine("Opcije su d ili n");
                }
            }
            return odluka == 'd' ? true : false;
        }

        static bool IsInt(string s)
        {
            int broj;
            if (Int32.TryParse(s, out broj))
            {
                return true;
            }
            return false;
        }

        static bool IsLong(string s)
        {
            long broj;
            if (Int64.TryParse(s, out broj))
            {
                return true;
            }
            return false;
        }

        static bool IsFloat(string s)
        {
            float broj;
            if (Single.TryParse(s, out broj))
            {
                return true;
            }
            return false;
        }

        static bool IsDouble(string s)
        {
            double broj;
            if (Double.TryParse(s, out broj))
            {
                return true;
            }
            return false;
        }

        static bool isBoolean(string s)
        {
            bool broj;
            if (Boolean.TryParse(s, out broj))
            {
                return true;
            }
            return false;
        }
    }
}
