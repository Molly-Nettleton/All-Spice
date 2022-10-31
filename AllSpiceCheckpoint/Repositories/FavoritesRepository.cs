namespace AllSpiceCheckpoint.Repositories;

public class FavoritesRepository : BaseRepository
{
  public FavoritesRepository(IDbConnection db) : base(db)
  { }

  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    string sql = @"
      INSERT INTO favorites(recipeId, accountId)
      VALUES(@RecipeId, @AccountId);
      SELECT LAST_INSERT_ID() 
    ;";
    int id = _db.ExecuteScalar<int>(sql, newFavorite);
    newFavorite.Id = id;
    return newFavorite;
  }

  internal void RemoveFavorite(Favorite foundFavorite)
  {
    string sql = @"
    DELETE FROM
    favorites
    WHERE
    id = @Id LIMIT 1
    ;";
    _db.Execute(sql, foundFavorite);
  }

  internal Favorite GetFavoritesById(int favoriteId)
  {
    string sql = @"
   SELECT *
   FROM favorites
   WHERE id = @favoriteId
   ;";
    return _db.QueryFirstOrDefault<Favorite>(sql, new { favoriteId });
  }

  internal List<FavoriteRecipe> GetFavoritesByAccountId(string accountId)
  {
    string sql = @"
    SELECT
    rec.*,
    COUNT(fav.id) AS FavoriteCount,
    fav.id AS FavoriteId,
      a.*
      FROM favorites fav
      JOIN recipes rec ON rec.id = fav.recipeId
      JOIN accounts a ON a.id = rec.creatorId
      WHERE fav.accountId = @accountId
      GROUP BY fav.id
      ;";
    return _db.Query<FavoriteRecipe, Profile, FavoriteRecipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      recipe.AccountId = profile.Id;
      return recipe;
    }, new { accountId }).ToList();
  }

internal Favorite GetFavoriteByRecipeAndAccount(Favorite newFavorite)
{
    string sql = @"
  SELECT * FROM favorites
  WHERE recipeId = @recipeId AND accountId = @accountId
  ;";
    return _db.Query<Favorite>(sql, newFavorite).FirstOrDefault();
  }
}