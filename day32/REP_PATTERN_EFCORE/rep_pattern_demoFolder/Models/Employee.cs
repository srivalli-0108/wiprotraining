using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace rep_pattern_demo.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeId
        {
            get;
            set;
        }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Name is required")]
        public string EmployeeName
        {
            get;
        }
    }
}