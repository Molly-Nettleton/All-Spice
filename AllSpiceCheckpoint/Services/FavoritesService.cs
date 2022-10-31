namespace AllSpiceCheckpoint.Services;
public class FavoritesService
{
  private readonly FavoritesRepository _favoritesRepo;

  public FavoritesService(FavoritesRepository favoritesRepo)
  {
    _favoritesRepo = favoritesRepo;
  }

  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    Favorite favoriteRecipe = _favoritesRepo.GetFavoriteByRecipeAndAccount(newFavorite);
    if(favoriteRecipe != null){
      throw new Exception("Already favorited.");
    }
    Favorite favorite = _favoritesRepo.CreateFavorite(newFavorite);
    return favorite;
  }

  internal void RemoveFavorite(int favoriteId, string accountId)
  {
    Favorite foundFavorite = GetFavoriteById(favoriteId);
    if (foundFavorite == null)
    {
      throw new Exception("Invalid id.");
    }
    _favoritesRepo.RemoveFavorite(foundFavorite);
  }

  internal Favorite GetFavoriteById(int favoriteId)
  {
    Favorite foundFavorite = _favoritesRepo.GetFavoritesById(favoriteId);
    if (foundFavorite == null)
    {
      throw new Exception("Invalid id.");
    }
    return foundFavorite;
  }
}