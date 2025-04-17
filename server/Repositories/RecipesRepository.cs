



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

  internal void UpdateRecipe(Recipe recipeToUpdate)
  {
    string sql = @"
    UPDATE recipes
    SET
    title = @Title,
    instructions = @Instructions,
    img = @Img,
    category = @Category
    WHERE id = @Id
    LIMIT 1;
    ";

    int rowsAffected = _db.Execute(sql, recipeToUpdate);
    if (rowsAffected == 0)
    {
      throw new Exception("Update failed");
    }
    if (rowsAffected > 1)
    {
      throw new Exception("everything wrong with update");
    }
  }

  internal void DeleteRecipe(int recipeId)
  {
    string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { recipeId });
    if (rowsAffected > 1)
    {
      throw new Exception("WHOOPS");
    }
  }
}