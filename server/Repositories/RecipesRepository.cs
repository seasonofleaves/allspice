


namespace allspice.Repositories;

public class RecipesRepository
{
  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
      INSERT INTO
      recipes(title, instructions, img, category, creatorId)
      VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);

      SELECT
      recipes.*,
      accounts.*
      FROM recipes
      JOIN accounts ON recipes.creatorId = accounts.id
      WHERE recipes.id = LAST_INSERT_ID();";

    Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, JoinCreatorToRecipe, recipeData).FirstOrDefault();
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
    SELECT
    recipes.*,
    accounts.*
    FROM recipes
    JOIN accounts ON recipes.creatorId = accounts.id;";
    List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, JoinCreatorToRecipe).ToList();
    return recipes;
  }

  private Recipe JoinCreatorToRecipe(Recipe recipe, Profile profile)
  {
    recipe.Creator = profile;
    return recipe;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    string sql = @"
      SELECT
      recipes.*,
      accounts.*
      FROM recipes
      JOIN accounts ON recipes.creatorId = accounts.id
      WHERE recipes.id = @recipeId;";

    Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, JoinCreatorToRecipe, new { recipeId }).FirstOrDefault();
    return recipe;
  }

  internal void EditRecipe(Recipe recipeToEdit)
  {
    string sql = @"
      UPDATE
      recipes
      SET
      title = @Title,
      instructions = @Instructions,
      img = @Img,
      category = @Category
      WHERE id = @Id
      LIMIT 1;";

    int rowsAffected = _db.Execute(sql, recipeToEdit);

    if (rowsAffected == 0) { throw new Exception("No recipes were updated."); }
    if (rowsAffected > 1) { throw new Exception($"{rowsAffected} recipes were updated."); }
  }

  internal void DeleteRecipe(int recipeId)
  {
    string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { recipeId });
    if (rowsAffected == 0)
    {
      throw new Exception("No recipes were deleted.");
    }
    if (rowsAffected > 1)
    {
      throw new Exception($"{rowsAffected} recipes were deleted.");
    }
  }
}

