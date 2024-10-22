
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
}
