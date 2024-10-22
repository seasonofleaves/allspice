using System.ComponentModel.DataAnnotations;

namespace allspice.Models;

public class Ingredient
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  [MaxLength(2000)]
  public string Name { get; set; }
  [MaxLength(2000)]
  public string Quantity { get; set; }
  public int RecipeId { get; set; }
}