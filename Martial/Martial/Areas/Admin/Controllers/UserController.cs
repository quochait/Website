using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Martial.Data;
using Martial.Extensions;
using Martial.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Martial.Areas.Admin.Controllers
{
    [Authorize(Roles = Role.SuperAdmin)]
    [Area("Admin")]
    public class UserController : Controller
    {
        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;


        public UserController(UserManager<ApplicationUser> userManager,
            ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _applicationDbContext.Users.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (user != null)
            {
                return View(user);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost()
        {
            if (!ModelState.IsValid)
            {
                View(ApplicationUser);
            }

            var id = ApplicationUser.Id;
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Name = ApplicationUser.Name;
                user.Email = ApplicationUser.Email;
                user.LockoutEnabled = ApplicationUser.LockoutEnabled;
                user.PhoneNumber = ApplicationUser.PhoneNumber;

                if (user.LockoutEnabled)
                {
                    await _userManager.AddToRoleAsync(user, Role.Admin);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, Role.Admin);
                }

                var s = await _userManager.UpdateAsync(user);

                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, Role.Admin);
                await _userManager.DeleteAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}