using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zarzadzanie_Projektami.Models
{
    public class Profil
    {
        public int ID { get; set; }

        [Required]
        public string Login { get; set; }

        [StringLength(15, ErrorMessage = "Imie nie dłuższe niz 15 znaków")]
        [Required]
        public string Imie{ get; set; }

        [Required]
        public string Nazwisko { get; set; }

        public int MyProperty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataUtworzeniaKonta { get; set; }
        public virtual ICollection<Projekt> Projekty { get; set; }


    }
}