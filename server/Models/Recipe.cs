using System.ComponentModel.DataAnnotations;

namespace allspice.Models;

public class Recipe
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  [MinLength(3), MaxLength(25)]
  public string Title { get; set; }
  [MinLength(15), MaxLength(250)]
  public string Instructions { get; set; }
  [MaxLength(5000)]
  public string Img { get; set; }
  [MaxLength(1000)]
  public string Category { get; set; }
  public string CreatorId { get; set; }
}