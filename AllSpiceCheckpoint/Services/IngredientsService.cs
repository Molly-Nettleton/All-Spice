namespace AllSpiceCheckpoint.Services;

public class IngredientsService
{
  private readonly RecipesRepository _recipesRepo;
  private readonly FavoritesRepository _favoritesRepo;
  private readonly IngredientsRepository _ingredientsRepo;

  public IngredientsService(RecipesRepository recipesRepo, FavoritesRepository favoritesRepo, IngredientsRepository ingredientsRepo)
  {
    _recipesRepo = recipesRepo;
    _favoritesRepo = favoritesRepo;
    _ingredientsRepo = ingredientsRepo;
  }

  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {
    return _ingredientsRepo.CreateIngredient(newIngredient);
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    return _ingredientsRepo.GetIngredientsByRecipe(recipeId);
  }

  internal void RemoveIngredient(int ingredientId, string accountId)
  {
    Ingredient foundIngredient = GetIngredientById(ingredientId);
    if (foundIngredient == null)
    {
      throw new Exception("Ingredient not found");
    }
    if ( foundIngredient.CreatorId != accountId)
    {
      throw new Exception("Unauthorized");
    }
    _ingredientsRepo.RemoveIngredient(foundIngredient);
  }

  internal Ingredient GetIngredientById(int ingredientId)
  {
    Ingredient foundIngredient = _ingredientsRepo.GetByIngredientId(ingredientId);
    if (foundIngredient == null)
    {
      throw new Exception("Ingredient not found");
    }
    return foundIngredient;
  }
}