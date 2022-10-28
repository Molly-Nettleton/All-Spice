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
}