using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testSession.Models;
using System.Collections.Generic;
using testSession.Extensions;

namespace testSession.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    int i = 1;

    public IActionResult Session()
    {
      List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("test");
      if (lstShoppingCart == null)
      {
        lstShoppingCart = new List<int>();
      }
      lstShoppingCart.Add(i);
      i++;

      HttpContext.Session.Set("test", lstShoppingCart);
      return View();
    }
  }
}
