import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js"


class RecipesService {
  async getAllRecipes() {
    const res = await api.get('api/recipes')
    // console.log(res.data);
    AppState.recipes = res.data.map(r => new Recipe(r), ...AppState.recipes)
    console.log(AppState.recipes);
  }

  async getRecipeDetails(recipeId) {
    // NOTE vv setting a variable as a response from the server. This is a single recipe we are pulling so we do not need to map through the array, like in getallrecipes, where we map through the array.
    const res = await api.get(`api/recipes/${recipeId}`)
    AppState.activeRecipe = new Recipe(res.data)
    console.log(AppState.activeRecipe);
  }

  async getList(type = '') {
    let res
    if (type) {
      res = await api.get('api/recipes', {
        params: {
          type: type
        }
      })
    } else {
      res = await api.get('api/recipes')
    }
    console.log(res.data)
    AppState.recipes = res.data.map(r => new Recipe(r))
  }

  async createRecipe(recipeData) {
    const res = await api.post("api/recipes", recipeData);
    console.log("[createRecipe]", res.data);
    const newRecipe = new Recipe(res.data);
    AppState.recipes = [newRecipe, ...AppState.recipes];
  }

  async removeRecipe(recipeId) {
    await api.delete(`api/recipes/${recipeId}`);
    let recipe = AppState.recipes.findIndex((r) => r.id == recipeId);
    AppState.recipes.splice(recipe, 1);
  }

  async getMyRecipes() {
    const res = await api.get("api/recipes");
    console.log(res.data);
    AppState.recipes = res.data.map((r) => new Recipe(r));
    AppState.recipes = AppState.recipes.filter((r) => r.creator.id == AppState.account.id);
  }

  async getRecipesBySearchTerm(query) {
    const res = await api.get("api/recipes")
    console.log(res.data)
    AppState.recipes = res.data.map(r => new Recipe(r))
    AppState.recipes = AppState.recipes.filter((f) => f.category.toUpperCase().includes(query.toUpperCase()))

    console.log("search recipes", AppState.recipes);
  }

  async editInstructions(recipeData, recipeId) {
    const res = await api.put(`api/recipes/${recipeId}`, recipeData)
    AppState.activeRecipe = new Recipe(res.data)
  }
}
export const recipesService = new RecipesService()