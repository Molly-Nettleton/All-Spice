<template>
  <div class="modal fade" id="recipeFormModal" tabindex="-1" aria-labelledby="Label" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content ">
        <div class="modal-body form">

          <div class="p-2 bg-dark">
            <h4> New Recipe</h4>
          </div>

<img
  :src="editable.img || 'http://static1.squarespace.com/static/5898e29c725e25e7132d5a5a/58aa11bc9656ca13c4524c68/58aa11e99656ca13c45253e2/1487540713345/600x400-Image-Placeholder.jpg?format=original'"
  alt="" class="img-fluid pt-2" />

          <div class="row">
            <div class="d-flex">
              <div class="mt-3 inputBox me-3 ms-2">
                <span>Title</span>
                <input type="text" required name="title" v-model="editable.title" class="form-control mb-2 " />
              </div>


              <div class="mt-3 inputBox">
                <span>Image</span>
                <input type="url" required name="img" v-model="editable.img" class="form-control mb-2" />
              </div>
            </div>

          </div>
          <form @submit.prevent="handleSubmit()" class="">

            <div class="mt-3 inputBox">
              <span>Instructions</span>
              <textarea type="text" required name="instructions" row="4" v-model="editable.instructions"
                class="form-control mb-2"> </textarea>
            </div>

            <div class="mt-3 inputBox">
              <div class="form-group">
                <label for="type" class="pe-2 mb-2">Category</label>
                <select required name="category" v-model="editable.category">
                  <option value="Breakfast">Breakfast</option>
                  <option value="Soup">Soup</option>
                  <option value="Drinks">Drinks</option>
                  <option value="Baking">Baking</option>
                  <option value="Seafood">Seafood</option>
                  <option value="Bbq">BBQ</option>
                  <option value="Italian">Italian</option>
                  <option value="Japanese">Japanese</option>
                  <option value="Mexican">Mexican</option>
                </select>
              </div>
            </div>

            <div class="my-3 d-flex justify-content-between">
              <button class="btn btn-success selectable" type="submit" data-bs-dismiss="modal">
                Submit
              </button>
              <button type="button" class="btn btn-secondary " data-bs-dismiss="modal">Cancel</button>
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