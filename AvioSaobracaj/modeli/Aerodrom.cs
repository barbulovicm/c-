using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvioSaobracaj.modeli
{
    class Aerodrom
    {
        public int aerodromId { get; }
        public string ime { get; set; }
        public string grad { get; set; }
        public string drzava { get; set; }

        public Aerodrom(int aerodrom_id, string ime, string grad, string drzava)
        {
            this.aerodromId = aerodrom_id;
            this.ime = ime;
            this.grad = grad;
            this.drzava = drzava;
        }

        public Aerodrom(string ime, string grad, string drzava)
        {
            this.ime = ime;
            this.grad = grad;
            this.drzava = drzava;
        }

        public Aerodrom()
        {
        }

        public override string ToString()
        {
            return aerodromId + " " + ime + " " + grad + " " + drzava;
        }
    }
}
