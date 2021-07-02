using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Areas.Admin.Models.Customers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerModelFactory _customerModelFactory;

        public CustomerController(ICustomerModelFactory customerModelFactory)
        {
            _customerModelFactory = customerModelFactory;
        }

        [HttpGet]
        public JsonResult CustomerList()
        {
            var customerList = _customerModelFactory.PrepareCustomerList();
            return new JsonResult(customerList);
        }
    }
}