using Citus.Education.WebApp.Sample.Business.Managers;
using Citus.Education.WebApp.Sample.Models.ViewModels;
using Citus.Education.WebApp.Sample.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Citus.Education.WebApp.Sample.Web.Controllers
{
    public partial class BankAccountController : Controller
    {
        // GET: Account
        public virtual ActionResult Index()
        {
            List<BankAccountViewModel> model = BankAccountsManager.GetAccounts();

            return View("Index", model);
        }
        [HttpGet]
        public virtual ActionResult Edit(int? id)
        {
            BankAccountViewModel model = new BankAccountViewModel();
            if (id.HasValue)
            {
                //napuni model po id-u
                model = BankAccountsManager.GetAccount(id.Value);
            }
            else
            {
                //može biti za New, svo props će biti prazni

            }
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(BankAccountViewModel model)
        {
            //TODO Manager Save metoda
            if (ModelState.IsValid)
            {
            }

            model.Message = "Spašeno";

            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditAjax(BankAccountViewModel model)
        {
            //TODO Manager Save metoda
            if (ModelState.IsValid)
            {
            }

            return Json("Poruka sa AJAX metode: spašeno!!!");
        }

        public virtual ActionResult ListDataTables()
        {
            return View("ListDataTables");
        }

        public virtual ActionResult GetBankAccountListAjax(DataTablesRequestModel model)
        {
            int sortColumnId = 0;
            string sortDirection = String.Empty;

            if (model.Order.Count() > 0)
            {
                sortColumnId = model.Order.FirstOrDefault().Column;
                sortDirection = model.Order.FirstOrDefault().Dir;
            }

            var result = BankAccountsManager.GetBankAccountDataTable(model.Length, model.Start, model.Search.Value, sortColumnId, sortDirection);

            return Json(result,
     JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetNameAutocomplete(string term)
        {
            var result = BankAccountsManager.GetAccounts(term);

            return Json(result);
        }
    }
}