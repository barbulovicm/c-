using System;
using AvioSaobracaj.modeli;
using System.Data.SqlClient;

namespace AvioSaobracaj
{
    static class RukovanjeEntitetima
    {
        public static string putanja = "Data Source=.\\SQLEXPRESS;Initial Catalog=avio_saobracaj; Integrated Security = True; MultipleActiveResultSets=True";
        public static SqlConnection con = new SqlConnection(putanja);
        /*
         * U ovu datoteku smo stavili sve funkcionalnosti koje se odnose na rukovanje
         * entitetima, ukljucujuci i sam meni za rukovanje entitetima. Liste u kojima
         * se nalaze podaci kojima rukujemo se ne nalaze u ovoj datoteci, vec u datoteci
         * Program.cs. U ovoj datoteci ima najvise koda, i to koda koji je dosta
         * repetitivan. Funkcije u ovoj datoteci bi se mogle reorganizovati i 
         * 'pametnije' napisati, ali nam to u ovom trenutku nije cilj posto bi
         * bile manje razumljive pocetnicima.
         */

        private static void DodavanjeAviona()
        {
            con.Open();
            Console.Write("Unesite ime aviona: ");
            string ime = Console.ReadLine();
            Console.Write("Unesite kapacitet aviona: ");

            int kapacitet;
            while (!int.TryParse(Console.ReadLine(), out kapacitet))
            {
                Console.Write("Unos nije validan, unesi ponovo : ");
            }

            Console.Write("Unesite model aviona: ");
            string model = Console.ReadLine();

            SqlCommand cmd = new SqlCommand("insert into avioni(ime_aviona,kapacitet,marka_aviona) values (@ime_aviona,@kapacitet,@marka_aviona)", con);
            cmd.Parameters.AddWithValue("@ime_aviona", ime);
            cmd.Parameters.AddWithValue("@kapacitet", kapacitet);
            cmd.Parameters.AddWithValue("@marka_aviona", model);

            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Unos uspesno izveden");
            }
            else
            {
                Console.WriteLine("Unos nije uspesno izveden");
            }

            Ucitavanje.UcitavanjeAviona(con);

        }

        private static void DodavanjeAerodroma()
        {
            con.Open();
            Console.Write("Unesite ime aerodroma: ");
            string ime = Console.ReadLine();

            Console.Write("Unesite grad u  kome se nalazi aerodrom: ");
            string grad = Console.ReadLine();

            Console.Write("Unesite drzavu gde se nalazi aerodrom: ");
            string drzava = Console.ReadLine();

            SqlCommand cmd = new SqlCommand("insert into aerodromi(ime,grad,drzava) values (@ime,@grad,@drzava)", con);
            cmd.Parameters.AddWithValue("@ime", ime);
            cmd.Parameters.AddWithValue("@grad", grad);
            cmd.Parameters.AddWithValue("@drzava", drzava);

            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Unos uspesno izveden");
            }
            else
            {
                Console.WriteLine("Unos nije uspesno izveden");
            }

            Ucitavanje.UcitavanjeAerodroma(con);
        }

        private static void DodavanjeLetova()
        {
            con.Open();
            Console.Write("Unesi ime leta : ");
            string ime = Console.ReadLine();
            Console.Write("Unesi avion : ");
            string avion = ProveraAviona(Console.ReadLine());
            Console.Write("Unesi aerodrom poletanja : ");
            string pol = ProveraAerodroma(Console.ReadLine());
            Console.Write("Unesi aerodrom sletanja : ");
            string dol = ProveraAerodroma(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("insert into letovi(avion,polazni_aerodrom,dolazni_aerodrom,ime_leta) values (@avion,@polazni_aerodrom,@dolazni_aerodrom,@ime_leta)", con);



            cmd.Parameters.AddWithValue("@avion", avion);
            cmd.Parameters.AddWithValue("@polazni_aerodrom", pol);
            cmd.Parameters.AddWithValue("@dolazni_aerodrom", dol);
            cmd.Parameters.AddWithValue("@ime_leta", ime);

            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Unos uspesno izveden");
            }
            else
            {
                Console.WriteLine("Unos nije uspesno izveden");
            }
            Ucitavanje.UcitavanjeLetova(con);
        }

        private static void BrisanjeAviona()
        {
            con.Open();
            Console.Write("Unesite ime aviona koju treba obrisati iz sistema: ");
            string ime = ProveraAviona(Console.ReadLine());
            string komanda = "delete from avioni where (ime_aviona like'%"+ime+"')";
            SqlCommand cmd = new SqlCommand(komanda, con);

            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Brisanje uspesno izvedeno");
            }
            else
            {
                Console.WriteLine("Brisanje nije uspesno izvedeno");
            }
            Ucitavanje.UcitavanjeAviona(con);
        }

       private static void PretragaPoImenuAviona()
        {
            bool flag = false;
            con.Open();
            Console.Write("Unesi ime aviona :");
            string s = Console.ReadLine();
            Console.WriteLine("id".PadRight(4)+"ime".PadRight(10)+"max putnika".PadRight(13)+"model"); 
            for (int i = 0; i < Podaci.avioni.Count; i++)
            {
                if (s.ToLower().Equals(Podaci.avioni[i].imeAviona.ToLower()))
                {
                    flag = true;
                    Console.WriteLine(Podaci.avioni[i]);
                }
            }
            if (!flag)
            {
                Console.WriteLine("Nema trazenog aviona u bazi!");
                con.Close();
                return;
            }
               

            
            flag = false;
            for (int i = 0; i < Podaci.letovi.Count; i++)
            {
                if (s.ToLower().Equals(Podaci.letovi[i].avion))
                {
                    flag = true;
                    Console.WriteLine(Podaci.letovi[i]);
                    
                }
            }
            if (!flag)
            {
                Console.WriteLine("Nema trazenog aviona u bazi letova!");
                con.Close();
            }
                
        }
        
        //private static void BrisanjeAerodroma()
        //{
        //    Console.Write("Unesite id dogadjaja koji treba obrisati iz sistema: ");
        //    string idString = Console.ReadLine();
        //    int id = int.Parse(idString);
        //    Dogadjaj d = PronadjiDogadjajPoId(id);
        //    Podaci.listaDogadjaja.Remove(d);
        //}

        //private static void BrisanjeLetova()
        //{
        //    Console.Write("Unesite id ulaznice koju treba obrisati iz sistema: ");
        //    string idString = Console.ReadLine();
        //    int id = int.Parse(idString);
        //    Ulaznica u = PronadjiUlaznicuPoId(id);
        //    Podaci.listaUlaznica.Remove(u);
        //}

        //private static int GenerisiNoviIdUlaznice()
        //{
        //    int najveciId = -1;
        //    foreach (Ulaznica u in Podaci.listaUlaznica)
        //    {
        //        if (u.Id > najveciId)
        //        {
        //            najveciId = u.Id;
        //        }
        //    }
        //    return najveciId + 1;
        //}

        //private static int GenerisiNoviIdDogadjaja()
        //{
        //    int najveciId = -1;
        //    foreach (Dogadjaj d in Podaci.listaDogadjaja)
        //    {
        //        if (d.Id > najveciId)
        //        {
        //            najveciId = d.Id;
        //        }
        //    }
        //    return najveciId + 1;
        //}

        public static void MeniRukovanje()
        {
            Meni m = new Meni();
            m.DodajOpciju(DodavanjeAviona, "Dodavanja aviona");
            m.DodajOpciju(DodavanjeAerodroma, "Dodavanje aerodroma");
            m.DodajOpciju(DodavanjeLetova, "Dodavanje letova");
            m.DodajOpciju(BrisanjeAviona, "Brisanje aviona");
            m.DodajOpciju(PretragaPoImenuAviona, "Pretraga po imenu aviona");
            //m.DodajOpciju(BrisanjeUlaznica, "Brisanje ulaznica");

            m.Pokreni();
        }

        //public static Dogadjaj PronadjiDogadjajPoId(int idDogadjaja)
        //{
        //    foreach (Dogadjaj d in Podaci.listaDogadjaja)
        //    {
        //        if (d.Id == idDogadjaja)
        //        {
        //            return d;
        //        }
        //    }
        //    return null;
        //}

        //public static Osoba PronadjiOsobuPoJMBG(string jmbg)
        //{
        //    foreach (Osoba o in Podaci.listaOsoba)
        //    {
        //        if (o.JMBG.Equals(jmbg))
        //        {
        //            return o;
        //        }
        //    }
        //    return null;
        //}

        //public static Ulaznica PronadjiUlaznicuPoId(int id)
        //{
        //    foreach (Ulaznica u in Podaci.listaUlaznica)
        //    {
        //        if (u.Id == id)
        //        {
        //            return u;
        //        }
        //    }
        //    return null;
        //}
        //public static string ProveraAerodroma(string a)
        //{
        //    for (int i = 0; i < Podaci.aerodromi.Count; i++)
        //    {
        //        if (Podaci.aerodromi[i].ime.Contains(a))
        //        {
        //            return a;
        //            break;
        //        }
        //    }
        //    return null;
        //}
        //public static string ProveraAviona(string a)
        //{
        //    for (int i = 0; i < Podaci.avioni.Count; i++)
        //    {
        //        if (Podaci.avioni[i].ime.Contains(a))
        //        {
        //            return a;
        //            break;
        //        }
        //    }
        //    return null;
        //}

        private static string ProveraAviona(string s)
        {
            bool flag = false;

            for (int i = 0; i < Podaci.avioni.Count; i++)
            {
                if (Podaci.avioni[i].imeAviona.ToLower().Equals(s.ToLower()))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Trazeni avion ne postoji u listi!");
                return null;
            }

            else
                return s;
        }
        private static string ProveraAerodroma(string s)
        {
            bool flag = false;

            for (int i = 0; i < Podaci.avioni.Count; i++)
            {
                if (Podaci.aerodromi[i].ime.ToLower().Equals(s.ToLower()))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Trazeni aerodrom ne postoji u listi!");
                return null;
            }

            else
                return s;
        }

    }
}



