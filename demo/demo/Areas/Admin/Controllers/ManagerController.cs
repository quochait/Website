using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using demo.Areas.Admin.Models.DataTables;
using demo.Areas.Admin.Models.Customer;

namespace demo.Areas.Admin.Controllers
{
    [Authorize()]
    [Area("Admin")]
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Manager/ListUsers.cshtml");
        }

        public IActionResult ListUsers()
        {
            var model = new CustomerSearchModel
            {
                UsernamesEnabled = true,
                CompanyEnabled = true,
                PhoneEnabled = true,
                AvailablePageSizes = "test"
            };
            //model.PageSize = 10;

            return View(model);
        }
    }
}