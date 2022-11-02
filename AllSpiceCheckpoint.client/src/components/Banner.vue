<template>
  <div class="container-fluid banner">
    <div class="row">
      <div class="d-flex justify-content-end">
        <SearchBar />
        <span class="ms-4 mt-2">
          <Login />
        </span>
      </div>
    </div>
    <div class="row fontglow">
      <div class="col-md d-flex justify-content-center mt-4 ">
        <h2 class="">ALL SPICE</h2>
      </div>
    </div>
    <div class="row fontglow">
      <div class="col-md d-flex justify-content-center">
        <h5>Recipes n stuff</h5>
      </div>
    </div>

  </div>
  <div class="d-flex justify-content-center">
    <div class="col-md-4 bg-white d-flex justify-content-center buttonbar elevation-5">
      <div class="mt-2">
        <button @click="getAllRecipes('')" class="btn ms-2 fs-4 hover" title="Home">HOME</button>
        <button @click="getMyRecipes('myrecipes')" class="btn ms-2 fs-4 hover" Title="MyRecipes">MY RECIPES</button>
        <button @click="getFavoriteRecipes('myfavorites')" class="btn ms-2 me-2 fs-4 hover"
          Title="Favorites">FAVORITES</button>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState.js"
import { accountService } from "../services/AccountService.js"
import { recipesService } from "../services/RecipesService.js"
import Pop from "../utils/Pop.js"
import SearchBar from "./SearchBar.vue"


export default {
    setup() {
        return {
            recipes: computed(() => AppState.recipes),
            async getAllRecipes() {
                try {
                    await recipesService.getAllRecipes();
                }
                catch (error) {
                    console.error("[]", error);
                    Pop.error(error);
                }
            },
            async getFavoriteRecipes() {
                try {
                    await accountService.getFavoriteRecipes();
                }
                catch (error) {
                    console.error("[]", error);
                    Pop.error(error);
                }
            },
            async getMyRecipes() {
                try {
                    await recipesService.getMyRecipes();
                }
                catch (error) {
                    Pop.error(error);
                }
            },
        };
    },
    components: { SearchBar }
}
</script>


<style lang="scss" scoped>
.banner {
  background-image: URL(https://images.unsplash.com/photo-1506368249639-73a05d6f6488);
  background-size: cover;
  background-position: center;
  background-attachment: fixed;
  height: 250px;
  position: relative;
}

.buttonbar {
  transform: translateY(-2.5rem) translateX(.5rem);
  position: absolute;
  min-height: 70px;
  min-width: 250px;
}
</style>