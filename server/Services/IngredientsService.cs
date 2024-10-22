


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

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    List<Ingredient> ingredients = _repository.GetIngredientsByRecipeId(recipeId);
    return ingredients;
  }

  private Ingredient GetIngredientById(int ingredientId)
  {
    Ingredient ingredient = _repository.GetIngredientById(ingredientId);
    if (ingredient == null)
    {
      throw new Exception($"Invalid ingredient id: {ingredientId}");
    }
    return ingredient;
  }

}
