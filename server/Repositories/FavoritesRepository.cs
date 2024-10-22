
namespace allspice.Repositories;

public class FavoritesRepository
{
  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
  {
    string sql = @"
      INSERT INTO
      favorites(recipeId, accountId)
      VALUES(@RecipeId, @AccountId);
      
      SELECT
      favorites.*,
      accounts.*,
      recipes.*
      FROM favorites
      JOIN recipes ON recipes.id = favorites.recipeId
      JOIN accounts ON accounts.id = favorites.accountId
      WHERE favorites.id = LAST_INSERT_ID();";

    FavoriteRecipe favoriteProfile = _db.Query<Favorite, Profile, FavoriteRecipe, FavoriteRecipe>(sql, (favorite, profile, recipe) =>
    {
      recipe.FavoriteId = favorite.Id;
      recipe.Creator = profile;
      return recipe;
    }, favoriteData).FirstOrDefault();
    return favoriteProfile;
  }

  internal List<FavoriteRecipe> GetFavoriteByAccountId(string userId)
  {
    string sql = @"
        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM
        favorites
        JOIN recipes ON recipes.id = favorites.recipeId
        JOIN accounts ON favorites.accountId = accounts.id
        WHERE favorites.accountId = @userId;";

    List<FavoriteRecipe> favorites = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>(sql, (favorite, recipe, profile) =>
    {
      recipe.FavoriteId = favorite.Id;
      recipe.Creator = profile;
      return recipe;
    }, new { userId }).ToList();
    return favorites;
  }
}

