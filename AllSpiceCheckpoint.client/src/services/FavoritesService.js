import { AppState } from "../AppState.js";
import { FavoriteRecipe } from "../models/FavoriteRecipe.js";
import { api } from "./AxiosService.js"

class FavoritesService {

  async addFavoriteRecipe(recipe) {
    let recipeId = {};
    recipeId.recipeId = recipe.id
    const res = await api.post("api/favorites", recipeId);
    // recipe.favoriteId = res.data.id
    AppState.favorites = [res.data, ...AppState.favorites]

  }

  async removeFavoriteRecipe(favoriteId) {
    await api.delete(`api/favorites/${favoriteId}`);
    let index = AppState.favorites.findIndex(f => f.id == favoriteId)
    AppState.favorites.splice(index, 1)
    if (AppState.number) {
      AppState.recipes = AppState.recipes.filter(f => f.favoriteId != favoriteId)
    }

  }
}
export const favoritesService = new FavoritesService()