using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvioSaobracaj.modeli;


namespace AvioSaobracaj
{
    class Program
    {
        public static string putanja = "Data Source=.\\SQLEXPRESS;Initial Catalog=avio_saobracaj; Integrated Security = True; MultipleActiveResultSets=True";
        public static SqlConnection con = new SqlConnection(putanja);
       
        static void Main(string[] args)
        {
            con.Open();
            Ucitavanje.UcitavanjeAviona(con);
            Ucitavanje.UcitavanjeAerodroma(con);
            Ucitavanje.UcitavanjeLetova(con);

            Meni m = new Meni();
            m.DodajOpciju(PregledEntiteta.MeniPregled, "Pregled entiteta");
            m.DodajOpciju(RukovanjeEntitetima.MeniRukovanje, "Rad na entitetima ");
            m.Pokreni();

            con.Close();
        }

       
    }
}
