<template>
{{ingredient.quantity}} {{ingredient.name}}
</template>


<script>
import { Ingredient } from "../models/Ingredient.js";

export default {
  props: {
    ingredient: {
      type: Ingredient,
      required: true
    }
  },
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>