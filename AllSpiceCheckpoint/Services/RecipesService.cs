namespace AllSpiceCheckpoint.Services;

public class RecipesService
{
  private readonly RecipesRepository _recipesRepo;
  private readonly FavoritesRepository _favoritesRepo;

  public RecipesService(RecipesRepository recipesRepo, FavoritesRepository favoritesRepo)
  {
    _recipesRepo = recipesRepo;
    _favoritesRepo = favoritesRepo;
  }

  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    return _recipesRepo.CreateRecipe(newRecipe);
  }

  internal List<Recipe> GetAllRecipes()
  {
    return _recipesRepo.GetAllRecipes();
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe foundRecipe = _recipesRepo.GetByRecipeId(recipeId);
    if (foundRecipe == null)
    {
      throw new Exception("Recipe not found");
    }
    return foundRecipe;
  }

  internal void RemoveRecipe(int recipeId, string accountId)
  {
    Recipe foundRecipe = GetRecipeById(recipeId);
    if (foundRecipe == null)
    {
      throw new Exception("Recipe not found.");
    }
    if (foundRecipe.CreatorId != accountId)
    {
      throw new Exception("Unauthorized.");
    }
    foundRecipe.Archived = true;
    _recipesRepo.RemoveRecipe(foundRecipe);
  }

  internal Recipe EditRecipe(Recipe recipeData, string AccountId)
  {
    if (recipeData.CreatorId != AccountId)
    {
      throw new Exception("Unauthorized.");
    }
    Recipe original = GetRecipeById(recipeData.Id);
    original.Title = recipeData.Title ?? original.Title;
    original.Category = recipeData.Category ?? original.Category;
    original.Img = recipeData.Img ?? original.Img;
    original.Instructions = recipeData.Instructions ?? original.Instructions;
    Recipe recipe =  _recipesRepo.EditRecipe(original);
    return recipe;
  }
}