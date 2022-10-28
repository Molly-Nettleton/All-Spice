namespace AllSpiceCheckpoint.Models;

public class FavoriteRecipe : Recipe
{ 
  public int FavoriteId { get; set; }
  public string AccountId { get; set; }
  public int RecipeId { get; set; }
  }