using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetAppRemodel.EF;
using TimeSheet.Models.Entities;
using TimeSheetAppRemodel.Repos.Base;

namespace TimeSheetAppRemodel.DAL.Repos
{
    public class PayrollRepo : RepoBase<Payroll>
    {
        public PayrollRepo(DbContextOptions<TimeSheetContext> options) : base(options)
        {

        }

        public PayrollRepo()
        {

        }
    }
}
