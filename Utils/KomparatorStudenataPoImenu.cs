using System;
using System.Collections.Generic;
using Modul1Termin05.Primer4.Model;

namespace Modul1Termin05.Primer4.Utils
{
    internal class KomparatorStudenataPoImenu : IComparer<Student>
    {
        private int smer;

        public KomparatorStudenataPoImenu(int smer)
        {
            if (Math.Abs(smer) != 1)
            {
                this.smer = 1;
            }
            this.smer = smer;
        }

        public int Compare(Student x, Student y)
        {
            int retVal = 0;
            if (x != null && y != null)
            {
                retVal = x.Ime.CompareTo(y.Ime);

                if (retVal == 0)
                {
                    retVal = x.Prezime.CompareTo(y.Prezime);
                }
            }
            return retVal * smer;
        }
    }
}