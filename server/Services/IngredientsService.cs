

using Microsoft.AspNetCore.Http.HttpResults;

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

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    List<Ingredient> ingredients = _ingredientsRepository.GetIngredientsByRecipeId(recipeId);
    return ingredients;
  }

  private Ingredient GetIngredientById(int ingredientId)
  {

    Ingredient ingredient = _ingredientsRepository.GetIngredientsById(ingredientId);
    if (ingredient == null)
    {
      throw new Exception("nope");
    }
    return ingredient;
  }

  internal void DeleteIngredient(int ingredientId, Account userInfo)
  {
    Ingredient ingredient = GetIngredientById(ingredientId);
    // FIXME user info = creator check
    _ingredientsRepository.DeleteIngredient(ingredientId);

  }
}