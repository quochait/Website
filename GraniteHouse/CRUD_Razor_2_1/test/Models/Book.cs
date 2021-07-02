using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
  public class Book
  {
    public int BookID { get; set; }

    [Display(Name = "Name of book.")]
    public string NameBook { get; set; }

    public Book()
    {
      new List<Book>
      {
      new Book { BookID = 2, NameBook = "book2" },
      new Book { BookID = 1, NameBook = "book1" }
     };
    }

    public static implicit operator Book(List<Book> v)
    {
      throw new NotImplementedException();
    }
  }

}
