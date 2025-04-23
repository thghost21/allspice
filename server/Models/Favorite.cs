namespace allspice.Models;

public class Favorite : RepoItem
{
  public int RecipeId { get; set; }
  public string AccountId { get; set; }
}

public class FavoriteProfile : Profile
{
  public int RecipeId { get; set; }
  public string AccountId { get; set; }
}

public class FavoriteRecipe : Recipe
{
  public int FavoriteId { get; set; }
  public string AccountId { get; set; }
}