using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using System.IO;
using Martial.Models;
using Martial.Data;
using Microsoft.AspNetCore.Authorization;
using Martial.Extensions;

namespace Martial.Areas.Admin.Controllers
{
    //[Authorize(Roles = Role.SuperAdmin + "," + Role.Admin)]
    [Area("Admin")]
    public class AlbumController : Controller
    {
        #region Fields

        private readonly ApplicationDbContext _applicationContext;
        private readonly HostingEnvironment _hostingEnviroment;
        const string subPath = "image";

        #endregion

        #region Properties

        //public AlbumViewModel AlbumVM { get; set; }
        [BindProperty]
        public Albums AlbumsVM { get; set; }

        #endregion

        #region Ctor

        public AlbumController(ApplicationDbContext applicationDbContext, HostingEnvironment hostingEnvironment)
        {
            _hostingEnviroment = hostingEnvironment;
            _applicationContext = applicationDbContext;
            AlbumsVM = new Albums();
        }

        #endregion

        #region Action METHOD

        //GET METHOD: List albums have in database
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var albums = await _applicationContext.Albums.Include(a => a.Pictures).ToListAsync();
            return View(albums);
        }

        //GET METHOD: Create new album
        [HttpGet]
        public IActionResult Create()
        {
            return View(AlbumsVM);
        }

        //POST CREATE METHOD
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(AlbumsVM);
            }

            //create album
            _applicationContext.Albums.Add(AlbumsVM);
            await _applicationContext.SaveChangesAsync();


            var webRootPath = _hostingEnviroment.WebRootPath;


            //whether Folder image created    
            if (!Directory.Exists(Path.Combine(webRootPath, subPath)))
            {
                Directory.CreateDirectory(Path.Combine(webRootPath, subPath));
            }

            //create folder stored image depend on Albums.ID
            if (!Directory.Exists(Path.Combine(webRootPath, subPath, AlbumsVM.Id.ToString())))
            {
                Directory.CreateDirectory(Path.Combine(webRootPath, subPath, AlbumsVM.Id.ToString()));
            }

            var formFiles = HttpContext.Request.Form.Files;

            if (formFiles.Count > 0)
            {
                foreach (var file in formFiles)
                {
                    var picture = new Pictures();

                    var pathUpload = Path.Combine(webRootPath, subPath, AlbumsVM.Id.ToString());
                    var extensionFile = Path.GetExtension(file.FileName);
                    picture.Title = Guid.NewGuid().ToString() + extensionFile;

                    using (var fileStream = new FileStream(Path.Combine(pathUpload, picture.Title), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    picture.Path = Path.Combine("\\", subPath, AlbumsVM.Id.ToString(), picture.Title);
                    picture.AlbumId = AlbumsVM.Id;
                    _applicationContext.Pictures.Add(picture);
                }
            }

            //_applicationContext.Add(AlbumsVM);
            await _applicationContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET METHOD: Delete a album
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var album = await _applicationContext.Albums.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (album == null)
            {
                return NotFound();
            }
            var picure = await _applicationContext.Pictures.Where(p => p.AlbumId == id).ToListAsync();

            if (Directory.Exists(Path.Combine(_hostingEnviroment.WebRootPath, "image", album.Id.ToString())))
            {
                Directory.Delete(Path.Combine(_hostingEnviroment.WebRootPath, "image", album.Id.ToString()), true);
            }

            _applicationContext.Pictures.RemoveRange(picure);
            _applicationContext.Albums.Remove(album);

            await _applicationContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET METHOD: Edit a album
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AlbumsVM = await _applicationContext.Albums.Where(a => a.Id == id).Include(p => p.Pictures).SingleOrDefaultAsync();

            return View(AlbumsVM);
        }

        //POST METHOD: Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(AlbumsVM);
            }

            //save picture to database
            var formfiles = HttpContext.Request.Form.Files;
            if (formfiles.Count > 0)
            {
                var pathUpload = Path.Combine(_hostingEnviroment.WebRootPath, subPath, AlbumsVM.Id.ToString());
                foreach (var file in formfiles)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var picture = new Pictures();
                    picture.Title = Guid.NewGuid().ToString() + extension;

                    using (var fileStream = new FileStream(Path.Combine(pathUpload, picture.Title), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    picture.Path = Path.Combine("\\", subPath, AlbumsVM.Id.ToString(), picture.Title);
                    picture.AlbumId = AlbumsVM.Id;
                    _applicationContext.Pictures.Add(picture);
                }
                await _applicationContext.SaveChangesAsync();
            }

            //change information about album
            var albumFromDb = await _applicationContext.Albums.Where(a => a.Id == AlbumsVM.Id).FirstOrDefaultAsync();
            albumFromDb.Descriptions = AlbumsVM.Descriptions;
            albumFromDb.Name = AlbumsVM.Name;
            albumFromDb.ModifiedDate = DateTime.Now;

            _applicationContext.Albums.Update(albumFromDb);
            await _applicationContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //create function ajax to delete a image from album when request
        [Route("/deleteImage/{imageId}/{albumId}")]
        public async Task<string> DeleteAImage(int imageId, int albumId)
        {
            var image = await _applicationContext.Pictures.Where(p => p.Id == imageId && p.AlbumId == albumId).FirstOrDefaultAsync();

            var webRootPath = _hostingEnviroment.WebRootPath;
            if (!Directory.Exists(Path.Combine(webRootPath, "image", albumId.ToString())))
            {
                //return Json(new { result = "Don't have albums." });
                return "Don't have albums.";
            }

            var uploads = Path.Combine(webRootPath, "image", albumId.ToString());
            if (image == null || !System.IO.File.Exists(Path.Combine(uploads, image.Title)))
            {
                //return Json(new { result = "Don't have image in album." });
                return "Don't have image in album.";
            }

            _applicationContext.Pictures.Remove(image);
            await _applicationContext.SaveChangesAsync();
            System.IO.File.Delete(Path.Combine(uploads, image.Title));

            return "Deleted successfully!";
        }

        //create function ajax to add image from album when request in page Edit
        //don't finish
        [Route("/createImage/{albumId}")]
        public async Task<string> CreateImage(int albumId, IList<IFormFile> formFiles)
        {

            foreach (var file in formFiles)
            {
                var picture = new Pictures();

                var pathUpload = Path.Combine(_hostingEnviroment.WebRootPath, subPath, AlbumsVM.Id.ToString());
                var extensionFile = Path.GetExtension(file.FileName);
                picture.Title = Guid.NewGuid().ToString() + extensionFile;

                using (var fileStream = new FileStream(Path.Combine(pathUpload, picture.Title), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                picture.Path = Path.Combine("\\", subPath, AlbumsVM.Id.ToString(), picture.Title);
                picture.AlbumId = AlbumsVM.Id;
                _applicationContext.Pictures.Add(picture);
            }

            await _applicationContext.SaveChangesAsync();
            return "Add successful";
        }

        //GET METHOD: Show details about albums 
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            AlbumsVM = await _applicationContext.Albums.Where(a => a.Id == id).Include(a => a.Pictures).SingleOrDefaultAsync();
            return View(AlbumsVM);
        }

        #endregion
    }
}