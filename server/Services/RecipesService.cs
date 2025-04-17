




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

  internal Recipe UpdateRecipe(int recipeId, Account userInfo, Recipe recipeData)
  {
    Recipe recipeToUpdate = GetRecipeById(recipeId);
    if (recipeToUpdate.CreatorId != userInfo.Id)
    {
      throw new Exception("you cant edit another users recipe");
    }
    recipeToUpdate.Category = recipeData.Category ?? recipeToUpdate.Category;
    recipeToUpdate.Title = recipeData.Title ?? recipeToUpdate.Title;
    recipeToUpdate.Instructions = recipeData.Instructions ?? recipeToUpdate.Instructions;
    recipeToUpdate.Img = recipeData.Img ?? recipeToUpdate.Img;

    _recipesRepository.UpdateRecipe(recipeToUpdate);
    return recipeToUpdate;

  }

  internal void DeleteRecipe(Account userInfo, int recipeId)
  {
    Recipe recipe = GetRecipeById(recipeId);
    if (recipe.CreatorId != userInfo.Id)
    {
      throw new Exception("You can not delete another users recipe");
    }
    _recipesRepository.DeleteRecipe(recipeId);
  }
}