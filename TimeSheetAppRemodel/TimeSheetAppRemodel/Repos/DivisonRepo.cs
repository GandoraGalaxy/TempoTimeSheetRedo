using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetAppRemodel.EF;
using TimeSheet.Models.Entities;
using TimeSheetAppRemodel.Repos.Base;

namespace TimeSheetAppRemodel.DAL.Repos
{
    public class DivisonRepo : RepoBase<Division>
    {
        public DivisonRepo(DbContextOptions<TimeSheetContext> options) : base(options)
        {

        }

        public DivisonRepo()
        {

        }
    }
}
