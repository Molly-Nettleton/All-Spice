import { AppState } from "../AppState.js";
import { FavoriteRecipe } from "../models/FavoriteRecipe.js";
import { api } from "./AxiosService.js"

class FavoritesService{

 async addFavoriteRecipe(recipeId) {
   const res = await api.post("api/favorites", recipeId);
   AppState.favoriteRecipe = [new FavoriteRecipe(res.data), ...AppState.favoriteRecipe]
   console.log(AppState.favoriteRecipe)
}
}
export const favoritesService = new FavoritesService()