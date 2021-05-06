using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvioSaobracaj.modeli
{
    class Let
    {
        public int letId { get; }
        public string imeLeta { get; set; }
        public string avion { get; set; }

        public string polazniAerodrom { get; set; }

        public string dolazniAerodrom { get; set; }

        public Let(int letId, string imeLeta, string avion, string polazniAerodrom, string dolazniAerodrom)
        {
            this.letId = letId;
            this.imeLeta = imeLeta;
            this.avion = avion;
            this.polazniAerodrom = polazniAerodrom;
            this.dolazniAerodrom = dolazniAerodrom;
        }

        public Let(string imeLeta, string avion, string polazniAerodrom, string dolazniAerodrom)
        {
            this.imeLeta = imeLeta;
            this.avion = avion;
            this.polazniAerodrom = polazniAerodrom;
            this.dolazniAerodrom = dolazniAerodrom;
        }

        public Let()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Ime leta : " + imeLeta + "\n");
            sb.Append("Vrsta aviona : " + avion + "\n");
            sb.Append("polazak sa " + polazniAerodrom  +"\n");
            sb.Append("sletanje na " + dolazniAerodrom + "\n");

            return sb.ToString();
        }
    }
}
