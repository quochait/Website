using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Martial.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting.Internal;
using Martial.Data;

namespace Martial.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        #region Fields

        private readonly ApplicationDbContext _martialContext;
        public static int sizePicture = 4;
        //private readonly HostingEnvironment _hostingEnvironment;
        

        #endregion



        #region Properties

        public Albums AlbumVM { get; set; }

        #endregion



        #region Ctor

        public HomeController(ApplicationDbContext martialContext, HostingEnvironment hostingEnvironment)
        {
            _martialContext = martialContext;
            //_hostingEnvironment = hostingEnvironment;
        }

        #endregion



        #region Action Method

        //GET METHOD: Show albums have in database
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var albums = await _martialContext.Albums.Include(a => a.Pictures).ToListAsync();
            var lstImg = await _martialContext.Albums.Select(t => t.Pictures).Take(3).ToListAsync();
            return View(albums);
        }

        //GET METHOD: Show album details with id albums
        public async Task<IActionResult> Details(int id)
        {
            AlbumVM = await _martialContext.Albums.Where(a => a.Id == id).Include(a => a.Pictures).FirstOrDefaultAsync();
            if (AlbumVM == null)
            {
                return NotFound();
            }

            return View(AlbumVM);
        }

       
        #endregion

    }
}