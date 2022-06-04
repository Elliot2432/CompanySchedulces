using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompanySchedulces.Models
{
    public class Shift
    {
        [Key]
        public int ShiftsID { get; set; }

        public string ShiftsStart_Time { get; set; }

        public string ShiftsEnd_Time { get; set; }

    }
}
