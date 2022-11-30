import { AppState } from '../AppState'
import { Recipe } from "../models/Recipe.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getFavoriteRecipes() {
    const res = await api.get('account/favorites')
    console.log(res.data)
    AppState.recipes = res.data.map(r => new Recipe(r))
    // AppState.favorites = res.data.map(f => new Recipe(f))
   
  }

  async getFavorites() {
    const res = await api.get('account/favorites/all')
    console.log(res.data)
    // AppState.accountFavorites = res.data.map(r => new Recipe(r))
    AppState.favorites = res.data

  }
}

export const accountService = new AccountService()
