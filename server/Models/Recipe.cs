namespace allspice.Models;

public class Recipe : RepoItem
{
  public string Title { get; set; }
  public string Instructions { get; set; }
  public string Img { get; set; }
  public string Category { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }

}