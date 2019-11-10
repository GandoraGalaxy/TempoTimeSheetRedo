using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Models.Entities.Base;

namespace TimeSheet.Models.Entities
{
    public class Payroll : EntityBase
    {

        public decimal Salary { get; set; }

        public User EmployeeID { get; set; }
    }
}
