using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serijska_komunikacija
{
    public class Narudzba
    {
        public string Jelo { get; set; }
        public byte Pager { get; set; }
        public Narudzba(string jelo, byte pager)
        {
            Jelo = jelo;
            Pager = pager;
        }
        public override string ToString()
        {
            return Pager + " - " + Jelo;
        }
    }
}
