using GraniteHouse.Data;
using GraniteHouse.Models;
using GraniteHouse.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace GraniteHouse.Areas.Admin.Controllers
{
    //[Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class SpecialTagsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

        //GET Create method
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST Create method
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTags.Add(specialTags);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }

        //GET Edit method
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = _db.SpecialTags.Find(id);

            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        //POST Edit method
        public async Task<IActionResult> Edit(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTags.Update(specialTags);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }


        //GET Details method
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = _db.SpecialTags.Find(id);
            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        //POST Details method
        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction(nameof(Index));
        }
        
        //GET Delete method
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var specialTags = _db.SpecialTags.Find(id);
            if (specialTags == null)
            {
                return NotFound();
            }

            _db.SpecialTags.Remove(specialTags);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}