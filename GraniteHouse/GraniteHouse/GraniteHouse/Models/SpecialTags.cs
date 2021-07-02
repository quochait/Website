using System.ComponentModel.DataAnnotations;

namespace GraniteHouse.Models
{
  public class SpecialTags
  {
    public int ID { get; set; }

    [Required]
    public string Name { get; set; }
  }
}
