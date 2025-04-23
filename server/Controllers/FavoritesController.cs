using System.Threading.Tasks;

namespace allspice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{


  public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
  {
    _favoritesService = favoritesService;
    _auth0Provider = auth0Provider;
  }

  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0Provider;

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<FavoriteRecipe>> CreateFavorite([FromBody] Favorite favoriteData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      favoriteData.AccountId = userInfo.Id;
      FavoriteRecipe favoriteRecipe = _favoritesService.CreateFavorite(favoriteData);
      return Ok(favoriteRecipe);
    }
    catch (System.Exception)
    {

      throw;
    }
  }
}