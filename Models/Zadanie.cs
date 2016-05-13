using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zarzadzanie_Projektami.Models
{
    public class Zadanie
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public int CzasTrwania { get; set; }
        public ZadanieEnum Znaczenie { get; set; }

        public virtual Projekt Projekt { get; set; }

        public virtual ICollection<Zasob> Zasoby { get; set; }
    }
}