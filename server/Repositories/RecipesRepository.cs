


namespace allspice.Repositories;

public class RecipesRepository
{

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO
    recipes(title, instructions, img, category, creator_id)
    VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);
    
    SELECT
    recipes.*,
    accounts.*
    FROM recipes
    INNER JOIN accounts ON accounts.id = recipes.creator_id
    WHERE recipes.id = LAST_INSERT_ID();";

    Recipe recipe = _db.Query(sql, (Recipe recipe, Profile account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, recipeData).SingleOrDefault();
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
    SELECT
    recipes.*,
    accounts.*
    FROM recipes
    INNER JOIN accounts ON accounts.id = recipes.creator_id;";

    List<Recipe> recipes = _db.Query(sql, (Recipe recipe, Profile account) =>
    {
      recipe.Creator = account;
      return recipe;

    }).ToList();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    string sql = @"
    SELECT
    recipes.*,
    accounts.*
    FROM recipes
    INNER JOIN accounts ON accounts.id = recipes.creator_id
    WHERE recipes.id = @recipeId;
    ";
    Recipe foundRecipe = _db.Query(sql, (Recipe recipe, Profile account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, new { recipeId }).SingleOrDefault();
    return foundRecipe;
  }
}