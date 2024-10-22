using Microsoft.Extensions.DependencyInjection;

namespace allspice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  public FavoritesController(Auth0Provider auth0Provider, FavoritesService favoritesService)
  {
    _auth0Provider = auth0Provider;
    _favoritesService = favoritesService;
  }
  private readonly Auth0Provider _auth0Provider;
  private readonly FavoritesService _favoritesService;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<FavoriteRecipe>> CreateFavorite([FromBody] Favorite favoriteData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      favoriteData.AccountId = userInfo.Id;
      FavoriteRecipe favoriteProfile = _favoritesService.CreateFavorite(favoriteData);
      return Ok(favoriteProfile);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{favoriteId}")]
  public async Task<ActionResult<string>> DeleteFavorite(int favoriteId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      _favoritesService.DeleteFavorite(favoriteId, userInfo.Id);
      return Ok("No longer favorited recipe");
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
