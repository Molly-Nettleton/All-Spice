<template>

  <!-- Modal -->
  <div class="modal fade pic" id="exampleModal" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-xl ">
      <div class="modal-content all container-fluid p-0 pe-2">
        <div class="d-flex" v-if="recipe">

          <div class="col-md-4">
            <img :src="recipe?.img" alt="" class="imgcol rounded-start" @error="badImg" />
            <button type="button" class="btn-close closebtn " data-bs-dismiss="modal" aria-label="Close"></button>
          </div>

          <div class="col-md-8 p-4 ">
            <div class="d-flex">
              <h4 class="ms-4">{{ recipe?.title }} </h4>
              <div class="bg-grey mb-4 px-2 rounded-5 ms-3 mt-1 pb-1">{{ recipe?.category }}</div>
            </div>
            <div class="d-flex justify-content-around ms-4">

              <div class="position-absolute selectable deleteicon rounded-3"><i class="mdi mdi-delete fs-3 text-danger"
                  v-if="account.id == recipe.creatorId" @click="removeRecipe()" data-bs-dismiss="modal"
                  title="Delete recipe."></i></div>

              <div class="col-md-6">
                <div class="ms-3 bg-dark text-center rounded-top p-2">
                  <h5 class="mt-1">Ingredients</h5>
                </div>
                <div class=" ms-3 rounded-0 bg-grey rounded-bottom box2 position-relative">

                  <div class="ms-3 mt-1" v-for="i in ingredients" :key="i.id">
                    <div class="">
                      <Ingredients :ingredient="i" />
                    </div>
                  </div>

                </div>
                <div class="p-2 ms-3 bg-grey rounded" v-if="account.id == recipe.creatorId">
                  <AddIngredient class="" />
                </div>
              </div>

              <div class="col-md-6">
                <div class="ms-3 bg-dark text-center rounded-top p-2 d-flex justify-content-around">
                  <div class="col-1"></div>
                  <div class="col-6">
                    <h5 class="mt-1">Steps</h5>
                  </div>

                  <div class="col-1">
                    <button v-if="account.id == recipe.creatorId" class="rounded-circle border border-white mt-1 hover"
                      type="button" data-bs-toggle="collapse" data-bs-target="#collapseExample" aria-expanded="false"
                      aria-controls="collapseExample">
                      <i class="mdi mdi-pencil text-primary" title="Edit instructions."></i>
                    </button>
                  </div>
                </div>
                <div class=" ms-3 rounded-0 bg-grey rounded box position-relative">
                  <div class="ms-3 mt-1">
                    <div class="collapse" id="collapseExample">
                      <div class="card card-body me-3 p-1">
                        <form @submit.prevent="handleSubmit()">
                          <textarea v-model="editable.instructions" type="text" name="instructions"
                            class="text-start border border-0 form-control input-group-text rounded-0"
                            placeholder="Edit instructions."></textarea>
                          <button class="btn btn-success selectable" type="submit">
                            Submit
                          </button>
                        </form>
                      </div>
                    </div>
                    <div class="">
                      {{ recipe?.instructions }}
                    </div>
                  </div>
                </div>
                <div class="p-2 ms-3 bg-grey rounded-bottom">
                </div>
              </div>

            </div>
          </div>
        </div>
      </div>
    </div>
  </div>


</template>


<script>

import { computed, ref } from "@vue/reactivity";
import { watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { ingredientsService } from "../services/IngredientsService.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import AddIngredient from "./AddIngredient.vue";
import Ingredients from "./Ingredients.vue";

export default {
  props: {
    recipe: {
      type: Recipe,
    }
  },
  setup(props) {
    const editable = ref({});
    async function getIngredientsByRecipeId() {
      try {
        if (AppState.activeRecipe) {
          let recipeId = AppState.activeRecipe.id;
          await ingredientsService.getIngredientsByRecipeId(recipeId);
        }
      }
      catch (error) {
        Pop.error(error);
      }
    }
    watchEffect(() => {
 
        // editable.value = AppState.activeRecipe.instructions
      
      AppState.activeRecipe;
      editable.value =   {...AppState.activeRecipe }
      getIngredientsByRecipeId();
    });
    return {
      editable,
      ingredients: computed(() => AppState.ingredients),
      account: computed(() => AppState.account),
      async removeRecipe() {
        try {
          const yes = await Pop.confirm();
          if (!yes) {
            return;
          }
          const recipeId = AppState.activeRecipe.id;
          await recipesService.removeRecipe(recipeId);
          Pop.success(
            `Recipe removed.`
          );
        } catch (error) {
          Pop.error(error);
        }
      },

      async removeIngredient() {
        try {
          const yes = await Pop.confirm();
          if (!yes) {
            return;
          }
          const recipeId = AppState.activeRecipe.id;
          await recipesService.removeRecipe(recipeId);
          Pop.success(
            `Recipe removed.`
          );
        } catch (error) {
          Pop.error(error);
        }
      },

      async handleSubmit() {
        try {
          let recipeId = AppState.activeRecipe.id
          await recipesService.editInstructions(editable.value, recipeId)
        } catch (error) {
          console.error('[]', error)
          Pop.error(error)
        }
      }

    };
  },
  components: { Ingredients, AddIngredient }
}
</script>


<style lang="scss" scoped>
.modal-content {
  position: relative;
}

.closebtn {
  transform: translateY(-35rem) translateX(69em);

  position: absolute;
}

.box {
  height: 360px;
  overflow: auto;
}

.box2 {
  height: 375px;
  overflow: auto;
}

.imgcol {
  height: 82vh;
  width: 400px;
  object-fit: cover;
}

.deleteicon {
  transform: translateY(28rem) translateX(22rem);
}

.pic {
  background-image: URL(https://images.unsplash.com/photo-1506368249639-73a05d6f6488);
  background-size: cover;
  background-position: bottom;
}
</style>