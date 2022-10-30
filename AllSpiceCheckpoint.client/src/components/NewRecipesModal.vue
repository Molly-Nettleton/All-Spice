<template>
  <div class="modal fade" id="recipeFormModal" tabindex="-1" aria-labelledby="Label" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content ">
        <div class="modal-body FORM">
          <div class="p-2 bg-success">
            <h4> New Recipe</h4>
          </div>
          <form @submit.prevent="handleSubmit()" class="">
            <div class="mt-3 inputBox">
              <span>Title</span>
              <input type="text" required name="title" v-model="editable.title" />
            </div>
            <div class="mt-3 inputBox">
              <span>Image</span>
              <input type="url" required name="img" v-model="editable.img" />
            </div>
            <div class="mt-3 inputBox">
              <span>Instructions</span>
              <input type="text" required name="instructions" v-model="editable.instructions" />
            </div>
            <div class="mt-3 inputBox">
              <span>Category</span>
              <input type="text" required name="instructions" v-model="editable.category" />
            </div>
            <div class="my-3">
              <button class="btn btn-success selectable" type="submit" data-bs-dismiss="modal">
                Submit
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { ref } from "vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
export default {
  setup() {
    const editable = ref({});
    return {
      editable,
      async handleSubmit() {
        try {

          await recipesService.createRecipe(editable.value)
          editable.value = {}
        } catch (error) {
          console.error(error);
          Pop.error(error, "[handleSubmit]");
        }
      },
    }
  }
}
</script>


<style lang="scss" scoped>

</style>