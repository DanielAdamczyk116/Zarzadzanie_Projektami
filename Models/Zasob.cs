using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zarzadzanie_Projektami.Models
{
    public class Zasob
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public ZasobEnum Rodzaj { get; set; }

        public virtual Zadanie Zadanie { get; set; }
    }
}