using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompanySchedulces.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        public string EmployeeFname { get; set; }

        public string EmployeeLname { get; set; }

        public int EmployeePNumber { get; set; }

        public string EmployeePos { get; set; }

        public string EmployeeNum { get; set; }

        public DateTime Hired_date { get; set; }

        public string EmployeeTypeOfHours { get; set; }

        public decimal EmployeeSalary { get; set; }

    }

    public class EmployeeDto
    {
        public int EmployeeID { get; set; }

        public string EmployeeFname { get; set; }

        public string EmployeeLname { get; set; }

        public int EmployeePNumber { get; set; }

        public string EmployeePos { get; set; }

        public string EmployeeNum { get; set; }

        public DateTime Hired_date { get; set; }

        public string EmployeeTypeOfHours { get; set; }

        public decimal EmployeeSalary { get; set; }

    }


}