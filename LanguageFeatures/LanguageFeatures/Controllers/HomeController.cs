using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageFeatures.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        //public ViewResult Index()
        //{
        //List<string> results = new List<string>();

        //foreach (Product p in Product.GetProducts())
        //{
        //    string name = p?.Name ?? "<No name>";

        //    decimal? price = p?.Price ?? 0;
        //    string relatedName = p?.Related?.Name ?? "<None>";

        //    results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
        //    //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
        //}

        //return View(results);

        //
        //Dictionary<string, Product> products = new Dictionary<string, Product>()
        //{
        //    ["Kayak"] = new Product{Name = "Kayak", Price = 275M} ,
        //    ["Lifejacket"] = new Product{Name = "Lifejacket", Price = 48.95M}
        //};

        //return View("Index", products.Keys);

        //object[] data = new object[]
        //{
        //    274M, 29.95M,  "apple", "orange", 100, 10
        //};

        //decimal total = 0;

        //c1
        //for (int i = 0; i < data.Length; i++)
        //{
        //    if(data[i] is decimal d)
        //    {
        //        total += d;
        //    }

        //}

        //c2
        //for (int i = 0; i < data.Length; i++)
        //{
        //    switch (data[i])
        //    {
        //        case decimal decimalValue:
        //            total += decimalValue;
        //            break;
        //        case int intValue when intValue > 50:
        //            total += intValue;
        //            break;
        //    }
        //}

        //return View("Index", new string[] { $"Total: {total:c2}" });

        //bool FilterByPrice(Product p)
        //{
        //    return (p?.Price ?? 0) >= 20;
        //}

        //ShoppingCart cart = new ShoppingCart() { Products = Product.GetProducts() };
        //decimal cartTotal = cart. ;


        // Product[] productArray =
        //{
        //     new Product {Name = "Kayak", Price = 275M},
        //     new Product {Name = "Lifejacket", Price = 48.95M},
        //     new Product {Name = "Soccer ball", Price = 19.50M},
        //     new Product {Name = "Corner flag", Price = 34.95M}
        // };

        //Func<Product, bool> nameFilter = delegate (Product prod)
        //{
        //    return prod?.Name?[0] == 'S';
        //};
        //decimal priceFilterTotal = productArray.Filter();



        //decimal cartTotal = cart.TotalPrices();
        //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
        //decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

        //decimal priceFilterTotal = productArray.Filter(FilterByPrice).TotalPrices();
        //decimal nameFilterTotal = productArray.Filter(nameFilter).TotalPrices();

        //decimal priceFilterTotal = productArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices();
        //decimal nameFilterTotal = productArray.Filter(p => p?.Name?[0] == 'S').TotalPrices();


        //return View("Index", new string[]
        //{
        //    $"Price Total: {priceFilterTotal:C2}",
        //    $"Name Total: {nameFilterTotal:C2}"
        //});



        //return View("Index", new string[] { $"Total: {cartTotal:C2}" });
        //}

        //c1
        //public ViewResult Index()
        //{
        //    return View(Product.GetProducts().Select(p => p?.Name));
        //}


        //c2 use lambda expression
        //public ViewResult Index() => View(Product.GetProducts().Select(p => p?.Name));

        //public ViewResult Index()
        //{
        //    var products = new[] {
        //         new { Name = "Kayak", Price = 275M },
        //         new { Name = "Lifejacket", Price = 48.95M },
        //         new { Name = "Soccer ball", Price = 19.50M },
        //         new { Name = "Corner flag", Price = 34.95M }
        //    };

        //    return View(products.Select(product => product.GetType().Name));
        //}

        //public async Task<ViewResult> Index()
        //{
        //    long? length = await MyAsyncMethods.GetPageLength();

        //    return View(new string[] { $"Length: {length}" });
        //}

        public ViewResult Index()
        {
            var products = new[] {
                 new { Name = "Kayak", Price = 275M },
                 new { Name = "Lifejacket", Price = 48.95M },
                 new { Name = "Soccer ball", Price = 19.50M },
                 new { Name = "Corner flag", Price = 34.95M }
            };

            //return View(products.Select(product => $"Name: {product.Name}, Price: {product.Price}"));
            return View(products.Select(product => $"{nameof(product.Name)} : {product.Name}, {nameof(product.Price)}: {product.Price}"));
        }
    }
}