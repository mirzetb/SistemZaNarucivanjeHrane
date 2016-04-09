using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serijska_komunikacija
{
    public class Narudzba
    {
        public string Naziv { get; set; }
        public string Stanje { get; set; }
        public string Pager { get; set; }

        public Narudzba(string naziv, string stanje, string pager)
        {
            Naziv = naziv;
            Stanje = stanje;
            Pager = pager;
        }
    }
}
