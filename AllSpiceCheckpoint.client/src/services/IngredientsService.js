import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { api } from "./AxiosService.js"

class IngredientsService {
  async getIngredientsByRecipeId(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    console.log(res.data);
    AppState.ingredients = res.data.map(i => new Ingredient(i))
  }

  async addIngredient(ingredientData) {
    const res = await api.post("api/ingredients", ingredientData);
    console.log(res.data);
    
    let newIngredient = new Ingredient(res.data)
    AppState.ingredients = [newIngredient, ...AppState.ingredients]
  }

  async removeIngredient(ingredientId) {
    const res = await api.delete(`api/ingredients/${ingredientId}`);
    AppState.ingredients = AppState.ingredients.filter(i => i.id != ingredientId)
    console.log(res.data);
  }

}

export const ingredientsService = new IngredientsService()