<template>
  <section class="container">
    <div class="pt-5">
      <div class="row">
        <div class="col-1 fixed-bottom pb-3 text-end addcol">
          <button data-bs-target="#recipeFormModal" data-bs-toggle="modal"
            class="btn btn-success rounded-circle hover elevation-3" title="Add recipe">
            <i class="mdi mdi-plus  fs-3" data-bs-dismiss="modal"></i>
          </button>
        </div>
      </div>
      <div class="mb-5 d-flex flex-wrap">
        <div class="col-md-4 d-flex justify-content-center recipes" v-for="r in recipes">
          <RecipeCard :recipe="r" :key="r?.id" />
        </div>
      </div>
    </div>
  </section>
  <ActiveRecipeModal :recipe="activeRecipe" />
  <NewRecipesModal />
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
.addcol {
  margin-left: 86rem;
}

@media screen AND (max-width: 768px) {
  .recipes{
    flex: auto;
    justify-content: center;
  }
}
</style>