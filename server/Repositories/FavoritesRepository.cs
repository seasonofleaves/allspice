


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

  internal Favorite GetFavoriteById(int favoriteId)
  {
    string sql = "SELECT * FROM favorites WHERE id = @favoriteId;";
    Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
    return favorite;
  }

  internal void DeleteFavorite(int favoriteId)
  {
    string sql = "DELETE FROM favorites WHERE id = @favoriteId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { favoriteId });
    if (rowsAffected != 1)
    {
      throw new Exception($"{rowsAffected} favorites were deleted");
    }
  }
}

