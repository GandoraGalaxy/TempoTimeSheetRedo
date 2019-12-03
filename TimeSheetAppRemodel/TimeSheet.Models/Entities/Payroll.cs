using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Models.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Models.Entities
{
    [Table("Payroll", Schema = "TimeSheet")]
    public class Payroll : EntityBase
    {
        public decimal Salary { get; set; }

        public User EmployeeID { get; set; }
    }
}
