using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Models;

namespace test.Controllers
{
  
  public class ViewBookController : Controller
  {
    private Book _book = new List<Book>();
    public IActionResult Index()
    {
      List<Book> listBook = new List<Book>
      {
      
      };


      return View(listBook);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost] 
    public IActionResult Create(Book book)
    {
      if(book.NameBook == "book1")
      {
        ModelState.AddModelError(string.Empty, "book1 has been stored in database!");
      }
      if (!ModelState.IsValid)
      {
        return View(book);
      }

      return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult DetailBook(int id, Book book)
    {
     
      return View(book);
    }
  }
}