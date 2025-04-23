



namespace allspice.Repositories;

public class IngredientsRepository
{

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
    INSERT INTO
    ingredients(name, quantity, recipe_id)
    VALUES(@Name, @Quantity, @RecipeId);

    SELECT
    ingredients.*,
    recipes.*
    FROM ingredients
    INNER JOIN recipes ON recipes.id = ingredients.recipe_id
    WHERE ingredients.id = LAST_INSERT_ID();";

    Ingredient createdIngredient = _db.Query(sql, (Ingredient ingredient, Recipe recipe) =>
    {
      ingredient.RecipeId = recipe.Id;
      return ingredient;
    }, ingredientData).SingleOrDefault();
    return createdIngredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
   SELECT
    ingredients.*,
    recipes.*
    FROM ingredients
    INNER JOIN recipes ON recipes.id = ingredients.recipe_id
    WHERE ingredients.recipe_id = @recipeId;
    ";

    List<Ingredient> ingredients = _db.Query(sql, (Ingredient ingredient, Recipe recipe) =>
    {
      ingredient.RecipeId = recipe.Id;
      return ingredient;
    }, new { recipeId }).ToList();
    return ingredients;
  }

  internal Ingredient GetIngredientsById(int ingredientId)
  {
    string sql = @"
    SELECT * FROM ingredients WHERE id = @ingredientId
    ;";

    Ingredient ingredient = _db.Query<Ingredient>(sql, new { ingredientId }).SingleOrDefault();
    return ingredient;
  }

  internal void DeleteIngredient(int ingredientId)
  {
    string sql = "DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { ingredientId });
    if (rowsAffected != 1)
    {
      throw new Exception("whoops " + rowsAffected);
    }
  }
}