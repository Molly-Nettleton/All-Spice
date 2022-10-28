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
    return _favoritesRepo.CreateFavorite(newFavorite);
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

  private Favorite GetFavoriteById(int favoriteId)
  {
    Favorite foundFavorite = _favoritesRepo.GetFavoritesById(favoriteId);
    if (foundFavorite == null)
    {
      throw new Exception("Invalid id.");
    }
    return foundFavorite;
  }
}