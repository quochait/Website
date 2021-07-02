using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IRepository Repository = SimpleRepository.SharedRepository;
        
        public IActionResult Index() => View(Repository.Products.Where(product => product?.Price < 50));
        public IActionResult Index1() => View(Repository.Products);


        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            Repository.AddProduct(product);
            return RedirectToAction("Index");
        }
    }
}