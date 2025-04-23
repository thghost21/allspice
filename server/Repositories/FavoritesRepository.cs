
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
    favorites(account_id, recipe_id)
    VALUES(@AccountId, @RecipeId);

    SELECT
    favorites.*,
    recipes.*,
    accounts.*
    FROM favorites
    INNER JOIN recipes ON recipes.id = favorites.recipe_id
    INNER JOIN accounts ON accounts.id = favorites.account_id
    WHERE favorites.id = LAST_INSERT_ID();";

    FavoriteRecipe createdFavoriteRecipe = _db.Query(sql, (Favorite favorite, FavoriteRecipe recipe, Profile account) =>
    {

      recipe.FavoriteId = favorite.Id;
      recipe.Creator = account;
      return recipe;

    }, favoriteData).SingleOrDefault();
    return createdFavoriteRecipe;

  }
}