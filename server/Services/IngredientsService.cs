

namespace allspice.Services;

public class IngredientsService
{
  public IngredientsService(IngredientsRepository repository)
  {
    _repository = repository;
  }
  private readonly IngredientsRepository _repository;

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Ingredient ingredient = _repository.CreateIngredient(ingredientData);
    return ingredient;
  }

}
