using Citus.Education.WebApp.Sample.Models.DataTables;
using Citus.Education.WebApp.Sample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;

namespace Citus.Education.WebApp.Sample.Business.Managers
{
    public class BankAccountsManager
    {
        public static List<BankAccountViewModel> GetAccounts()
        {
            //na WCF
            List<BankAccountViewModel> accounts = new List<BankAccountViewModel>();

            List<string> statusList = new List<string>();
            statusList.Add("Aktivan");
            statusList.Add("Neaktivan");
            statusList.Add("Nepoznat");

            for (int i = 0; i < 15; i++)
            {
                BankAccountModel account = new BankAccountModel { Id = i, Code = "000" + i.ToString(), IBAN = "RBZSGSGS" + i.ToString(), Name = "AccountName" + i.ToString(), Status = "Neaktivan" };

                BankAccountViewModel model = new BankAccountViewModel { Account = account, StatusList = statusList};

                accounts.Add(model);
            }
            return accounts;
        }

        public static BankAccountViewModel GetAccount(int id)
        {
            var accounts = GetAccounts();

            var account = accounts.FirstOrDefault(x => x.Account.Id == id);

            return account;
        }

        public static DataTablesResponseModel<BankAccountModel> GetBankAccountDataTable(int pageSize, int position, string search, int sortColumnId, string sortDirection)
        {
            List<BankAccountModel> items = new List<BankAccountModel>();

            var bankAccountList = GetAccounts();

            int totalCount = bankAccountList.Count();

            var query = bankAccountList.Select(x => x.Account).AsQueryable();

            if (search != String.Empty)
            {
                query = query.Where(x => x.Name.Contains(search) || x.IBAN.Contains(search) || x.Code.Contains(search));
            }

            string sortColumn = "Code";

            switch (sortColumnId)
            {
                case 1:
                    sortColumn = "Name";
                    break;
                case 2:
                    sortColumn = "Description";
                    break;
                case 3:
                    sortColumn = "IBAN";
                    break;
                default:
                    sortColumn = "Code";
                    break;
            }

            string direction = (sortDirection == "DESC") ? "DESC" : "ASC";
            // Apply sorting:
            //dynamic from System.Linq.Dynamic in Common Exstensions
            query = query.OrderBy(sortColumn + " " + sortDirection);

            //paging
            query = query.Skip(position).Take(pageSize);

            DataTablesResponseModel<BankAccountModel> model = new DataTablesResponseModel<BankAccountModel>(query.ToList(), totalCount, totalCount, 0);

            return model;
        }

        public static List<AutocompleteModel> GetAccounts(string term)
        {
            var accounts = GetAccounts();
            var autocompleteModel = accounts
                .Where(x => x.Account.Name.StartsWith(term))
                .Take(10)
                .Select(x => new AutocompleteModel {
                    ID = x.Account.Id,
                    Code = x.Account.Name,
                    Value = x.Account.Name })
                 .ToList();

            return autocompleteModel;

        }
    }
}