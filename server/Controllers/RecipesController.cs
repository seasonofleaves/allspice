namespace allspice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth0Provider;

  public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider)
  {
    _recipesService = recipesService;
    _auth0Provider = auth0Provider;
  }

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _recipesService.CreateRecipe(recipeData);
      return Ok(recipe);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Recipe>> GetAllRecipes()
  {
    try
    {
      List<Recipe> recipes = _recipesService.GetAllRecipes();
      return Ok(recipes);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{recipeId}")]
  public ActionResult<Recipe> GetRecipeById(int recipeId)
  {
    try
    {
      Recipe recipe = _recipesService.GetRecipeById(recipeId);
      return Ok(recipe);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpPut("{recipeId}")]
  public async Task<ActionResult<Recipe>> EditRecipe(int recipeId, [FromBody] Recipe editRecipeData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Recipe recipe = _recipesService.EditRecipe(recipeId, userInfo.Id, editRecipeData);
      return Ok(recipe);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
