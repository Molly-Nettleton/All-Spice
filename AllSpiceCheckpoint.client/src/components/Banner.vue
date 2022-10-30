<template>
  <div class="container-fluid banner">
    <div class="row"><div class="d-flex justify-content-end">
      <SearchBar />
     <span class="ms-4 mt-2"><Login /></span> 
    </div>
    </div>
    <div class="row">
      <div class="col-md d-flex justify-content-center mt-4">
      <h2 class="">ALL SPICE</h2>
    </div></div>
    <div class="row">
      <div class="col-md d-flex justify-content-center">
        <h5>Recipes n stuff</h5>
      </div>
    </div>
    
  </div>
  <div class="d-flex justify-content-center">
    <div class="col-md-4 bg-white d-flex justify-content-center buttonbar elevation-5">
      <div class="mt-2">
    <button @click="filterList('')" class="btn ms-3 fs-4 hover" title="Home">HOME</button>
    <button @click="filterList('myrecipes')" class="btn ms-3 fs-4 hover" Title="MyRecipes">MY RECIPES</button>
    <button @click="filterList('myfavorites')" class="btn ms-3 me-3 fs-4 hover" Title="Favorites">FAVORITES</button></div>
    </div>
  </div>
</template>


<script>
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  setup(){
    return {
      async filterList(type) {
        try {
          await recipesService.getList(type)
        }catch(error){
          Pop.error(error,'[FilterList]')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.banner{
  background-image: URL(https://images.unsplash.com/photo-1506368249639-73a05d6f6488);
  background-size: cover;
  background-position: center;
  background-attachment: fixed;
  height: 250px;
  position: relative;
}

.buttonbar{
  transform: translateY(-2.5rem) translateX(.5rem);
  position: absolute;
  min-height: 70px;
  min-width: 250px;
}
</style>