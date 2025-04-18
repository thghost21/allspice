<script setup>
import { AppState } from '@/AppState.js';
import { Recipe } from '@/models/Recipe.js';
import { logger } from '@/utils/Logger.js';

defineProps({
  recipe: { type: Recipe, required: true }
})



function setActiveRecipe(recipe) {
  AppState.activeRecipe = recipe
  logger.log(AppState.activeRecipe)

}
</script>


<template>
  <div @click="setActiveRecipe(recipe)" role="button" type="button" data-bs-toggle="modal" data-bs-target="#recipeModal"
    class="recipe-card rounded d-flex flex-column justify-content-between mb-3 "
    :style="{ backgroundImage: `url(${recipe.img})` }">
    <div class="d-flex justify-content-between">
      <span class="bg-gray px-2 rounded m-1">{{ recipe.category }}</span>
      <span class="mdi mdi-heart bg-gray m-1 px-2 rounded text-red"></span>
    </div>
    <div class="d-flex m-2 bg-gray px-2 rounded ">
      <span class="fs-4">{{ recipe.title }}</span>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.recipe-card {
  background-position: center;
  background-size: cover;
  min-height: 30dvh;
}

.card {
  min-height: 30dvh;
}
</style>