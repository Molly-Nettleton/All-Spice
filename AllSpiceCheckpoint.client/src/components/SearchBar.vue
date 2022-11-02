<template>
  <div class="search-container mt-2">
    <form @submit.prevent="handleSubmit">
      <input class="rounded-2 border border-0 p-2" type="text" placeholder="Search by category .." required="true" minlength="2"
        name="search" v-model="editable">
      <button type="submit" class="rounded-2 border border-0 p-2 ms-1"><i class="mdi mdi-magnify mx-2" alt=""
          title="search By Name"></i></button>
    </form>
  </div>

</template>


<script>
import { ref, watchEffect } from 'vue';
import { recipesService } from "../services/RecipesService.js"
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js"


export default {
  setup() {
    const editable = ref("")
    watchEffect(()=>{})
    return {
      editable,
      async handleSubmit() {
        try {
          await recipesService.getRecipesBySearchTerm(editable.value)
          editable.value = []
        } catch (error) {
          logger.error('[SearchForm]', error)
          Pop.error(error)
        }
      }
    }

  }
}
</script>


<style lang="scss" scoped>

</style>