
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

      SELECT * FROM recipes WHERE id = LAST_INSERT_ID();";

    Recipe recipe = _db.Query<Recipe>(sql, recipeData).FirstOrDefault();
    return recipe;
  }
}

