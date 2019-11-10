using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TimeSheet.Models.Entities.Base;

namespace TimeSheet.Models.Entities
{
    [Table("Divisions", Schema = "TimeSheetApp")]
    public class Division : EntityBase
    {
        public string Name { get; set; }

        [ForeignKey(nameof(User))]
        public User ManagerID { get; set; }
    }
}
