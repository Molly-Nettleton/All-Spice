<template>
  <form @submit.prevent="addIngredient()" v-if="account.id == recipe.creatorId">
    <div class="input-group d-flex">
      <div class="d-flex col-md-2">
        <input type="text" maxlength="3" name="ingredient quantity"
          class="border border-0 form-control input-group-text rounded-0" placeholder="#" v-model="editable.quantity" />
      </div>
      <div class="d-flex col-10">
        <input type="text" name="ingredient name"
          class="border border-0 form-control input-group-text text-start rounded-0" maxlength="35"
          placeholder="Add ingredient.." v-model="editable.name" />
        <button class="btn btn-success rounded-0" type="submit">+</button>
      </div>
    </div>

  </form>
</template>

<script>
import { computed, ref } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { ingredientsService } from "../services/IngredientsService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    let editable = ref({ recipeId: AppState.activeRecipe.id });
    return {
      editable,
      recipe: computed(() => AppState.activeRecipe),
      account: computed(() => AppState.account),

      async addIngredient() {
        try {
          await ingredientsService.addIngredient(editable.value)
        } catch (error) {
          Pop.error(error);
        }
      },
    };
  },
};
</script>



<style lang="scss" scoped>

</style>