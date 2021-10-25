using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exp_3_VeriTasima.Models
{
    public class IletisimViewModel
    {
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public List<string> Bayiler { get; set; }
    }
}