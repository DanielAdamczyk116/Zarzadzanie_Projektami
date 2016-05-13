using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zarzadzanie_Projektami.Models
{
    public class Projekt
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }

        public virtual Profil Profil { get; set; }
        public virtual ICollection<Zadanie> Zadania { get; set; }


    }
}