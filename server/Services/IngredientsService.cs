
namespace allspice.Services;

public class IngredientsService
{

  public IngredientsService(IngredientsRepository ingredientsRepository, RecipesService recipesService)
  {
    _ingredientsRepository = ingredientsRepository;
    _recipesService = recipesService;
  }
  private readonly IngredientsRepository _ingredientsRepository;
  private readonly RecipesService _recipesService;

  internal Ingredient CreateIngredient(Ingredient ingredientData, Account userInfo)
  {
    Recipe recipe = _recipesService.GetRecipeById(ingredientData.RecipeId);
    if (recipe.Id != ingredientData.RecipeId)
    {
      throw new Exception("you cant add ingredients to a recipe not made by you");
    }
    Ingredient ingredient = _ingredientsRepository.CreateIngredient(ingredientData);
    return ingredient;
  }
}