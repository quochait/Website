using GraniteHouse.Data;
using GraniteHouse.Models;
using GraniteHouse.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Areas.Admin.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class AdminUsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminUsersController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.ApplicationUsers.ToList());
        }


        //GET edit
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || id.Trim().Length == 0)
            {
                return NotFound();
            }

            var userFromDb = await _db.ApplicationUsers.FindAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }
        

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                ApplicationUser userFromDb = _db.ApplicationUsers.Where(u => u.Id == id).FirstOrDefault();
                userFromDb.Name = applicationUser.Name;
                userFromDb.PhoneNumber = applicationUser.PhoneNumber;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(applicationUser);
        }

        //Get Delete
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null || id.Trim().Length == 0)
        //    {
        //        return NotFound();
        //    }

        //    var userFromDb = await _db.ApplicationUsers.FindAsync(id);
        //    if (userFromDb == null)
        //    {
        //        return NotFound();
        //    }
        
        //    return View(userFromDb);
        //}


        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(string id)
        {
            ApplicationUser userFromDb = _db.ApplicationUsers.Where(u => u.Id == id).FirstOrDefault();
            userFromDb.LockoutEnd = DateTime.Now.AddYears(1000);

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}