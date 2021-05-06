using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AvioSaobracaj.modeli;

namespace AvioSaobracaj
{
    
    public class Ucitavanje
    {
       
        public static void UcitavanjeAviona(SqlConnection con)
        {
            
            SqlCommand cmd = new SqlCommand("select * from avioni", con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                int id = (int)rd[0];
                string imeAviona = rd[1].ToString();
                int kapacitet = (int)rd[2];
                string markaAviona = rd[3].ToString();

                Avion avion = new Avion(id, imeAviona, kapacitet, markaAviona);
                Podaci.avioni.Add(avion);
            }
        }
        public static void UcitavanjeAerodroma(SqlConnection con)
        {
            
            SqlCommand cmd = new SqlCommand("select * from aerodromi", con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                int id = (int)rd[0];
                string imeAerodroma = rd[1].ToString();
                string grad = rd[2].ToString();
                string drzava = rd[3].ToString();


                Aerodrom aerodrom = new Aerodrom(id, imeAerodroma, grad, drzava);
                Podaci.aerodromi.Add(aerodrom);
            }
        }
        public static void UcitavanjeLetova(SqlConnection con)
        {
            
            SqlCommand cmd = new SqlCommand("select * from letovi", con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                int id = (int)rd[0];
                string avion = rd[1].ToString();
                string pol_aerodrom = rd[2].ToString();
                string dol_aerodrom = rd[3].ToString();
                string ime_leta = rd[4].ToString();


                Let let = new Let(id, ime_leta, avion, pol_aerodrom, dol_aerodrom);
                Podaci.letovi.Add(let);
            }
        }
    }
}
