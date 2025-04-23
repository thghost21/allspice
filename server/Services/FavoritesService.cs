
namespace allspice.Services;

public class FavoritesService
{


  public FavoritesService(FavoritesRepository favoritesRepository)
  {
    _favoritesRepository = favoritesRepository;
  }
  private readonly FavoritesRepository _favoritesRepository;

  internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
  {
    FavoriteRecipe favoriteRecipe = _favoritesRepository.CreateFavorite(favoriteData);
    return favoriteRecipe;
  }
}