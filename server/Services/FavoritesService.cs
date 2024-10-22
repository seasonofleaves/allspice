

namespace allspice.Services;

public class FavoritesService
{
  public FavoritesService(FavoritesRepository repository)
  {
    _repository = repository;
  }
  private readonly FavoritesRepository _repository;

  internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
  {
    FavoriteRecipe favoriteProfile = _repository.CreateFavorite(favoriteData);
    return favoriteProfile;
  }

  internal List<FavoriteRecipe> GetFavoriteByAccountId(string userId)
  {
    List<FavoriteRecipe> favorites = _repository.GetFavoriteByAccountId(userId);
    return favorites;
  }

  private Favorite GetFavoriteById(int favoriteId)
  {
    Favorite favorite = _repository.GetFavoriteById(favoriteId);
    if (favorite == null)
    {
      throw new Exception($"No favorite found with id: {favoriteId}");
    }
    return favorite;
  }

  internal void DeleteFavorite(int favoriteId, string userId)
  {
    Favorite favorite = GetFavoriteById(favoriteId);
    if (favorite.AccountId != userId)
    {
      throw new Exception("Not your favorite to delete.");
    }
    _repository.DeleteFavorite(favoriteId);
  }
}
