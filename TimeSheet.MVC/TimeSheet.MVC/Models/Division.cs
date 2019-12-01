using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.MVC.Models
{
    public class Division
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(User))]
        public User ManagerID { get; set; }
    }
}
