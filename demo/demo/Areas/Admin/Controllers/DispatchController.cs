﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace demo.Areas.Admin.Controllers
{
    public class DispatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}