using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;


namespace SportsStore.Components
{
  public class NavigationMenuViewComponent : ViewComponent
  {
    private IProductRepository repository;

    public NavigationMenuViewComponent(IProductRepository repo)
    {
      repository = repo;
    }

    public IViewComponentResult Invoke()
    {
      ViewBag.SelectedCategory = RouteData?.Values["category"];
      return View(repository.Products.Select(product => product.Category).Distinct().OrderBy(product => product));
    }

    //public string Invoke()
    //{
    //  return "Hello from the Nav View Component";
    //}
  }
}
