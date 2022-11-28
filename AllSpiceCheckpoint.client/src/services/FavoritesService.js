import { AppState } from "../AppState.js";
import { FavoriteRecipe } from "../models/FavoriteRecipe.js";
import { api } from "./AxiosService.js"

class FavoritesService {

  async addFavoriteRecipe(recipe) {
    let recipeId = {};
    recipeId.recipeId = recipe.id
    const res = await api.post("api/favorites", recipeId);
    recipe.favoriteId = res.data.id
    AppState.favoriteRecipe = [recipe, ...AppState.favoriteRecipe]

  }

  async removeFavoriteRecipe(favoriteId) {
    await api.delete(`api/favorites/${favoriteId}`);
    let index = AppState.favoriteRecipe.findIndex(f => f.favoriteId == favoriteId)
    AppState.favoriteRecipe.splice(index, 1)
    if (AppState.number) {
      AppState.favoriteRecipe = AppState.favoriteRecipe.filter(f => f.id != favoriteId)
    }

  }
}
export const favoritesService = new FavoritesService()