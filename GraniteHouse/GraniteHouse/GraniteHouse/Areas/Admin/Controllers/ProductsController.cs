using GraniteHouse.Data;
using GraniteHouse.Models;
using GraniteHouse.Models.ViewModel;
using GraniteHouse.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        [BindProperty]
        public ProductsViewModel ProductsVM { get; set; }

        public ProductsController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            ProductsVM = new ProductsViewModel()
            {
                ProductTypes = _db.ProductTypes.ToList(),
                SpecialTags = _db.SpecialTags.ToList(),
                Products = new Products()
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = _db.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags);
            return View(await products.ToListAsync());
        }

        //GET: Products Create method
        [HttpGet]
        public IActionResult Create()
        {
            return View(ProductsVM);
        }

        //Post : Product Create method
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(ProductsVM);
            }

            _db.Products.Add(ProductsVM.Products);
            await _db.SaveChangesAsync();

            //Image being saved

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var productsFromDb = _db.Products.Find(ProductsVM.Products.ID);

            if (files.Count != 0)
            {
                //Image has been uploaded
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, ProductsVM.Products.ID + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }

                productsFromDb.Image = @"\" + SD.ImageFolder + '\\' + ProductsVM.Products.ID + extension;
            }
            else
            {
                //don't upload image
                var uploads = Path.Combine(webRootPath, SD.ImageFolder + '\\' + SD.DefaultProductImage);
                System.IO.File.Copy(uploads, webRootPath + '\\' + SD.ImageFolder + '\\' + ProductsVM.Products.ID + Path.GetExtension(SD.DefaultProductImage));
                productsFromDb.Image = '\\' + SD.ImageFolder + '\\' + ProductsVM.Products.ID + Path.GetExtension(SD.DefaultProductImage);
            }

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET : EDIT METHOD
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductsVM.Products = await _db.Products.Include(m => m.SpecialTags).Include(m => m.ProductTypes).SingleOrDefaultAsync(m => m.ID == id);

            if (ProductsVM.Products == null)
            {
                return NotFound();
            }
            return View(ProductsVM);
        }

        ////POST: EDIT METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit()
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                var productFromDb = _db.Products.Where(m => m.ID == ProductsVM.Products.ID).FirstOrDefault();

                //if user upload new image
                if (files.Count > 0 && files[0] != null)
                {
                    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(productFromDb.Image);

                    if (System.IO.File.Exists(Path.Combine(uploads, productFromDb.ID + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, productFromDb.ID + extension_old));
                    }

                    using (var filesStream = new FileStream(Path.Combine(uploads, ProductsVM.Products.ID + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filesStream);
                    }

                    productFromDb.Image = @"\" + SD.ImageFolder + '\\' + ProductsVM.Products.ID + extension_new;
                }

                productFromDb.Name = ProductsVM.Products.Name;
                productFromDb.Price = ProductsVM.Products.Price;
                productFromDb.Available = ProductsVM.Products.Available;
                productFromDb.SpecialTagID = ProductsVM.Products.SpecialTagID;
                productFromDb.ProductTypeID = ProductsVM.Products.ProductTypeID;
                productFromDb.ShadeColor = ProductsVM.Products.ShadeColor;

                _db.Products.Update(productFromDb);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(ProductsVM);
        }

        //GET: DELETE METHOD
        /*
           - lấy ProductVM 
           - lấy path file ảnh
           - xóa file ảnh
           - xóa product
        */
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Products productFormDb = _db.Products.Find(id);
            if (productFormDb == null)
            {
                return NotFound();
            }

            var webRootPath = _hostingEnvironment.WebRootPath;
            var path = productFormDb.Image;
            var pathOfFile = webRootPath + path;

            if (System.IO.File.Exists(pathOfFile))
            {
                System.IO.File.Delete(pathOfFile);
            }

            _db.Products.Remove(productFormDb);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET: Details method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductsVM.Products = await _db.Products.Include(m => m.SpecialTags).Include(m => m.ProductTypes).FirstOrDefaultAsync();
            if (ProductsVM.Products == null)
            {
                return NotFound();
            }

            return View(ProductsVM);
        }
    }
}