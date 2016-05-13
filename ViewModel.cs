using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zarzadzanie_Projektami.ViewModel
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DataUtworzenia { get; set; }

        public int ProfilCount { get; set; }
    }
}