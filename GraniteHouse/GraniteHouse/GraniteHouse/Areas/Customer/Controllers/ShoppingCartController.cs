using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Extensions;
using GraniteHouse.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using GraniteHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }

        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Products>()
            };
        }

        //Get: Index method
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            if (lstShoppingCart != null && lstShoppingCart.Count > 0)
            {
                foreach (var cartItem in lstShoppingCart)
                {
                    Products product = await _db.Products.Include(p => p.SpecialTags).Include(p => p.ProductTypes).Where(p => p.ID == cartItem).SingleOrDefaultAsync();
                    ShoppingCartVM.Products.Add(product);
                }
            }

            return View(ShoppingCartVM);
        }

        //Post: Index method
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexPost()
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            ShoppingCartVM.Appointments.AppointmentDate = ShoppingCartVM.Appointments.AppointmentDate.AddHours(ShoppingCartVM.Appointments.AppointmentTime.Hour).AddMinutes(ShoppingCartVM.Appointments.AppointmentTime.Minute);

            Appointments appointments = ShoppingCartVM.Appointments;
            _db.Appointments.Add(appointments);
            await _db.SaveChangesAsync();

            int appointmentsId = appointments.ID;

            foreach (int productID in lstShoppingCart)
            {
                ProductsSelectedForAppointment products = new ProductsSelectedForAppointment()
                {
                    AppointmentID = appointmentsId,
                    ProductID = productID
                };
                _db.ProductsSelectedForAppointments.Add(products);
            }

            await _db.SaveChangesAsync();
            lstShoppingCart = new List<int>();
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);

            return RedirectToAction("AppointmentConfirmation", "ShoppingCart", new { id = appointments.ID });
        }


        //Action method remove product from Shopping cart
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

        //Get Appointment Confirmation method
        public IActionResult AppointmentConfirmation(int id)
        {
            ShoppingCartVM.Appointments = _db.Appointments.Where(a => a.ID == id).FirstOrDefault();
            List<ProductsSelectedForAppointment> objProductList = _db.ProductsSelectedForAppointments.Where(p => p.AppointmentID == id).ToList();

            foreach (ProductsSelectedForAppointment productAppointmentObj in objProductList)
            {
                ShoppingCartVM.Products.Add(_db.Products.Include(p => p.ProductTypes).Include(p => p.SpecialTags).Where(p => p.ID == productAppointmentObj.ProductID).FirstOrDefault());

            }

            return View(ShoppingCartVM);
        }

    }
}