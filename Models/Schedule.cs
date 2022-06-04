using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanySchedulces.Models
{
    public class Schedule
    {

        [Key]
        public int ScheduleID { get; set; }

        public DateTime ScheduleDate { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("Shift")]
        public int ShiftsID { get; set; }
        public virtual Shift Shift { get; set; }
        
    }
}