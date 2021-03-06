using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
  public class AdminController : Controller
  {
    private IProductRepository repository;

    public AdminController(IProductRepository repo)
    {
      repository = repo;
    }

    public IActionResult Index()
    {
      return View(repository.Products);
    }
  }
}