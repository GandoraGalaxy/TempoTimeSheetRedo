using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimeSheet.MVC.Configuration;
using TimeSheet.MVC.Models;
using TimeSheet.MVC.WebServiceAccess.Base;

namespace TimeSheet.MVC.WebServiceAccess
{
    public class WebApiCalls : WebApiCallsBase, IWebApiCalls
    {
        public WebApiCalls(IWebServiceLocator settings) : base(settings)
        {

        }

        public Task<IList<Division>> AddDivisionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Payroll>> AddPayrollAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Role>> AddRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TimeClock>> AddTimeClockAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> AddUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Division>> GetDivisionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Payroll>> GetPayrollAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Role>> GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TimeClock>> GetTimeClockAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Division>> RemoveDivisionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Payroll>> RemovePayrollAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Role>> RemoveRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TimeClock>> RemoveTimeClockAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> RemoveUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Division>> UpdateDivisionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Payroll>> UpdatePayrollAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Role>> UpdateRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TimeClock>> UpdateTimeClockAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> UpdateUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
