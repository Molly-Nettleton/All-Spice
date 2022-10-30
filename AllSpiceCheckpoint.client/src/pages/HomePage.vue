<template>
  <section class="container position-relative">
    <div class="row justify-content-center pt-5">
      <div class="fixed-bottom pb-3 pt-3 addrecipe text-end"><button data-bs-target="#recipeFormModal" data-bs-toggle="modal" class="btn btn-success rounded-circle hover elevation-3" title="Add recipe">
        <i class="mdi mdi-plus  fs-3" data-bs-dismiss="modal"></i>
      </button></div>
      <div class="col-md-4 d-flex justify-content-center" v-for="r in recipes" :key="r.id">
        <RecipeCard :recipe="r" />
      </div>
    </div>
  </section>
  <ActiveRecipeModal :recipe="activeRecipe" />
  <NewRecipesModal/>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState.js";
import ActiveRecipeModal from "../components/ActiveRecipeModal.vue";
import NewRecipesModal from "../components/NewRecipesModal.vue";
import RecipeCard from "../components/RecipeCard.vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
export default {
  setup() {
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      }
      catch (error) {
        console.error("[getting all recipes]", error);
        Pop.error(error);
      }
    }
    onMounted(() => {
      getAllRecipes();
    });
    return {
      recipes: computed(() => AppState.recipes),
      activeRecipe: computed(() => AppState.activeRecipe)
    };
  },
  components: { RecipeCard, ActiveRecipeModal, NewRecipesModal }
}
</script>

<style scoped lang="scss">
.addrecipe{
// position: absolute;
//   transform: translateY(0.5rem) translateX(3.5rem);
}
</style>