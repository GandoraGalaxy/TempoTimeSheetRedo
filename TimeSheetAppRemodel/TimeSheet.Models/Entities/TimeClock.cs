using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Models.Entities.Base;

namespace TimeSheet.Models.Entities
{
    public class TimeClock : EntityBase
    {

        public DateTime ClockIn { get; set; }

        public DateTime InLunch { get; set; }

        public DateTime OutLunch { get; set; }

        public DateTime ClockOut { get; set; }

        public User EmployeeID { get; set; }
    }
}
