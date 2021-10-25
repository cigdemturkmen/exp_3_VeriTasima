using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exp_3_VeriTasima.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Brans Brans { get; set; }

    }
}