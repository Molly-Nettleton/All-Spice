<template>
  <div class=" component my-4 rounded-3 elevation-5 hover" :style="{ backgroundImage: `url(${recipe.img})` }">

    <div class="d-flex justify-content-between">
      <h6 class="rounded px-2 py-1 ms-2 mt-3 category">{{ recipe.category }}</h6>
      <i class="mdi mdi-heart text-danger p-2 heart hoverable hover rounded-bottom mx-2" v-if="favorited"
        @click="removeFavoriteRecipe()"></i>
      <i class="mdi mdi-heart-outline text-danger p-2 heart hoverable hover rounded-bottom mx-2" v-else
        @click="addFavoriteRecipe()"></i>
    </div>
    <div class="" @click="getRecipeDetails()">
      <p class="title p-1 rounded-2 selectable" data-bs-toggle="modal" data-bs-target="#exampleModal">{{ recipe.title }}
      </p>
    </div>

  </div>
</template>


<script>
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import { favoritesService } from "../services/FavoritesService.js";
import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";
import { computed } from "@vue/reactivity";


export default {
  props: {
    recipe: {
      type: Recipe,
      required: true
    }
  },
  setup(props) {
    return {
      favorited: computed(() => AppState.favorites.find(f => f.id == props.recipe.id)),
      async addFavoriteRecipe() {
        try {
          // const recipeId = { recipeId: props.recipe.id }
          await favoritesService.addFavoriteRecipe(props.recipe)
          Pop.success("Added to favorites.")
        } catch (error) {
          console.error('[]', error)
          Pop.error(error)
        }
      },

      async removeFavoriteRecipe() {
        try {
          let id = this.favorited.favoriteId
          // const favorite = AppState.favoriteRecipe.find(f => f.accountId == AppState.account.id && f.recipeId == AppState.activeRecipe.id)
          // await favoritesService.removeFavoriteRecipe(favorite.id)
          const yes = await Pop.confirm();
          if (!yes) {
            return;
          }
          await favoritesService.removeFavoriteRecipe(id)
          Pop.success("Removed from favorites.")
        } catch (error) {
          console.error('[]', error)
          Pop.error(error)
        }
      },

      async getRecipeDetails() {
        try {
          await recipesService.getRecipeDetails(props.recipe.id)
        } catch (error) {
          console.error('[]', error)
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.component {
  width: 350px;
  height: 350px;
  position: relative;
  background-size: cover;
  background-position: center;
}

.title {
  position: absolute;
  transform: translateY(15.5rem) translateX(.5rem);
  width: 330px;
  max-height: 70px;
  background-color: rgba(88, 88, 88, 0.623);
  color: rgb(246, 245, 243);
  font-size: large;
}

.category {
  background-color: rgba(88, 88, 88, 0.623);
  color: rgb(246, 245, 243);
}

.heart {
  background-color: rgba(255, 255, 255, 0.607);
}
</style>