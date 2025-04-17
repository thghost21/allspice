




namespace allspice.Services;

public class RecipesService
{

  public RecipesService(RecipesRepository recipesRepository)
  {
    _recipesRepository = recipesRepository;
  }
  private readonly RecipesRepository _recipesRepository;

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _recipesRepository.CreateRecipe(recipeData);
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _recipesRepository.GetAllRecipes();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _recipesRepository.GetRecipeById(recipeId);
    if (recipe == null)
    {
      throw new Exception($"Could not get recipe by id{recipeId}");
    }
    return recipe;
  }
}