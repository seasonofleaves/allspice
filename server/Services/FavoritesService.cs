


namespace allspice.Services;

public class FavoritesService
{
  public FavoritesService(FavoritesRepository repository, FavoritesService favoritesService)
  {
    _repository = repository;
  }
  private readonly FavoritesRepository _repository;
}
