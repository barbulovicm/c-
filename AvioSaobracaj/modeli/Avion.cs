using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvioSaobracaj.modeli
{
    class Avion
    {
        public int avionId { get; }
        public string imeAviona { get; set; }
        public int kapacitet { get; set; }
        public string model_aviona { get; set; }

        public Avion(int avionId, string imeAviona, int kapacitet, string model_aviona)
        {
            this.avionId = avionId;
            this.imeAviona = imeAviona;
            this.kapacitet = kapacitet;
            this.model_aviona = model_aviona;
        }

        public Avion(string imeAviona, int kapacitet, string model_aviona)
        {
            this.imeAviona = imeAviona;
            this.kapacitet = kapacitet;
            this.model_aviona = model_aviona;
        }

        public Avion()
        {
        }

        public override string ToString()
        {
            return avionId.ToString().PadRight(4) +  imeAviona.PadRight(10) +  kapacitet.ToString().PadRight(13) +  model_aviona;
        }
    }
}
