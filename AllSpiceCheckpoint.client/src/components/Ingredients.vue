<template><div class="d-flex">
  <i class="mdi mdi-close hoverable fs-smaller text-danger"  v-if="account.id == ingredient.creatorId" @click="removeIngredient()" title="Delete ingredient."></i><div class="ms-1">{{ ingredient.quantity }} {{ ingredient.name }} </div></div>
</template>


<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { ingredientsService } from "../services/IngredientsService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    ingredient: {
      type: Ingredient,
      required: true
    }
  },
  setup(props) {
    return {
      account: computed(() => AppState.account),
      ingredients: computed(() => AppState.ingredients),
      async removeIngredient() {
        try {
          const yes = await Pop.confirm();
          if (!yes) {
            return;
          }
          await ingredientsService.removeIngredient(props.ingredient.id);
          Pop.success(
            'Ingredient removed.'
          )
        } catch (error) {
          console.error('[]', error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>