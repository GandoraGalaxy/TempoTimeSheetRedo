using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TimeSheet.Models.Entities
{
    [Table("Users", Schema = "TimeSheetApp")]
    public class User : IdentityUser
    {
        public User() : base()
        {

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Division DivisionID { get; set; }
    }
}
