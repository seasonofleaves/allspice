using Microsoft.AspNetCore.Http.HttpResults;

namespace allspice.Services;

public class RecipesService
{
  private readonly RecipesRepository _repository;
  public RecipesService(RecipesRepository repository)
  {
    _repository = repository;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repository.CreateRecipe(recipeData);
    return recipe;
  }

  internal Recipe EditRecipe(int recipeId, string userId, Recipe editRecipeData)
  {
    Recipe recipeToEdit = GetRecipeById(recipeId);
    if (recipeToEdit.CreatorId != userId)
    {
      throw new Exception("Not your recipe to edit.");
    }

    recipeToEdit.Title = editRecipeData.Title ?? recipeToEdit.Title;
    recipeToEdit.Instructions = editRecipeData.Instructions ?? recipeToEdit.Instructions;
    recipeToEdit.Img = editRecipeData.Img ?? recipeToEdit.Img;
    recipeToEdit.Category = editRecipeData.Category ?? recipeToEdit.Category;

    _repository.EditRecipe(recipeToEdit);
    return recipeToEdit;
  }

  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _repository.GetAllRecipes();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _repository.GetRecipeById(recipeId);
    if (recipe == null) { throw new Exception($"Invalid recipe id: {recipeId}"); }
    return recipe;
  }
}
