using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models.Entities;

namespace TimeSheet.MVC.WebServiceAccess.Base
{
    public interface IWebApiCalls
    {
        Task<IList<Division>> GetDivisionsAsync();
        Task<IList<Payroll>> GetPayrollAsync();
        Task<IList<TimeClock>> GetTimeClockAsync();
        Task<IList<User>> GetUsersAsync();
        Task<IList<Role>> GetRolesAsync();
        Task<IList<Division>> UpdateDivisionsAsync();
        Task<IList<Payroll>> UpdatePayrollAsync();
        Task<IList<TimeClock>> UpdateTimeClockAsync();
        Task<IList<User>> UpdateUsersAsync();
        Task<IList<Role>> UpdateRolesAsync();
        Task<IList<Division>> AddDivisionsAsync();
        Task<IList<Payroll>> AddPayrollAsync();
        Task<IList<TimeClock>> AddTimeClockAsync();
        Task<IList<User>> AddUsersAsync();
        Task<IList<Role>> AddRolesAsync();
        Task<IList<Division>> RemoveDivisionsAsync();
        Task<IList<Payroll>> RemovePayrollAsync();
        Task<IList<TimeClock>> RemoveTimeClockAsync();
        Task<IList<User>> RemoveUsersAsync();
        Task<IList<Role>> RemoveRolesAsync();
    }
}
