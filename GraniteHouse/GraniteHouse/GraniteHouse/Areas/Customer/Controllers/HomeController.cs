using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraniteHouse.Models.ViewModel;
using GraniteHouse.Models;
using GraniteHouse.Data;
using Microsoft.EntityFrameworkCore;
using GraniteHouse.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;



namespace GraniteHouse.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsViewModel ProductsVM { get; set; }

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
            ProductsVM = new ProductsViewModel()
            {
                SpecialTags = _db.SpecialTags.ToList(),
                ProductTypes = _db.ProductTypes.ToList(),
                Products = new Products()
            };
        }


        //GET: INDEX METHOD
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productList = await _db.Products.ToListAsync();
            return View(productList);
        }


        //GET: DETAILS METHOD
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductsVM.Products = await _db.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags).Where(m => m.ID == id).FirstOrDefaultAsync();
            if (ProductsVM.Products == null)
            {
                return NotFound();
            }

            return View(ProductsVM);
        }

        //POST: DETAILS METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart == null)
            {
                lstShoppingCart = new List<int>();
            }

            lstShoppingCart.Add(id);
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);

            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }

        public IActionResult Remove(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart.Count > 0)
            {
                if (lstShoppingCart.Contains(id))
                {
                    lstShoppingCart.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);

            return RedirectToAction(nameof(Index));
        }
    }
}
