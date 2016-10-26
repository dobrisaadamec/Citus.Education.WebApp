using Citus.Education.WebApp.Sample.Business.Managers;
using Citus.Education.WebApp.Sample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Citus.Education.WebApp.Sample.WebAPI.Controllers
{
    public class BankAccountController : ApiController
    {
        // GET: api/BankAccount
        public IEnumerable<BankAccountViewModel> Get()
        {
            return BankAccountsManager.GetAccounts() ;
        }

        // GET: api/BankAccount/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BankAccount
        public string Post([FromBody]string value)
        {
            return "Iz POST metode";
        }

        // PUT: api/BankAccount/5
        public string Put()
        {
            return "Iz PUT metode";
        }

        // DELETE: api/BankAccount/5
        public void Delete(int id)
        {
        }
    }
}
