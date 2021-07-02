using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using Microsoft.AspNetCore.Mvc;
using GraniteHouse.Models;
using Microsoft.AspNetCore.Authorization;
using GraniteHouse.Utility;

namespace GraniteHouse.Areas.Admin.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ProductTypesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Add(productTypes);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }


        //GET Edit Action Method
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTypes = await _db.ProductTypes.FindAsync(id);

            if (productTypes == null)
            {
                return NotFound();
            }

            return View(productTypes);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductTypes productTypes)
        {
            var prouductTypesFromDb = _db.ProductTypes.Where(p => p.ID == id);
            if (prouductTypesFromDb == null)
            {
                return NotFound();
            }

            if (id != productTypes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }


        //GET Delete Action Method
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var productTypes = await _db.ProductTypes.FindAsync(id);

            if (productTypes == null)
            {
                return NotFound();
            }

            _db.ProductTypes.Remove(productTypes);

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        //GET Details Action method
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var productTypes = await _db.ProductTypes.FindAsync(id);

            if (productTypes == null)
            {
                return NotFound();
            }

            return View(productTypes);
        }
    }
}