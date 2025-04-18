<script setup>
import { AppState } from '@/AppState.js';
import RecipeCard from '@/components/RecipeCard.vue';
import { recipeService } from '@/services/RecipesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const recipes = computed(() => AppState.recipes)

onMounted(() => {
  getAllRecipes()
})


async function getAllRecipes() {
  try {
    await recipeService.getAllRecipes()
  }
  catch (error) {
    Pop.error(error, "could not get recipes");
    logger.error("Could not get recipes", error)
  }
}
</script>

<template>
  <section class="container-fluid">
    <div class="row justify-content-center align-items-center">
      <div class="col-12 bgImg d-flex flex-column align-items-center justify-content-center">
        <div class="d-flex ">
          <div class="">
            <h1 class="text-center">All-Spice</h1>
            <p class="fs-3 mb-0">Cherish Your Family</p>
            <p class="fs-3">And Their Cooking</p>
          </div>
        </div>
      </div>
      <div class="col-md-4 text-center my-3">
        <div class="home-buttons">
          <div class="btn-group shadow " role="group" aria-label="Basic radio toggle button group">
            <input type="radio" class="btn-check" name="btnradio" id="btnradio1" autocomplete="off" checked>
            <label class="btn fs-4 btn-light btn-outline-success " for="btnradio1">Home</label>

            <input type="radio" class="btn-check" name="btnradio" id="btnradio2" autocomplete="off">
            <label class="btn fs-4 btn-light btn-outline-success" for="btnradio2">My Recipes</label>

            <input type="radio" class="btn-check" name="btnradio" id="btnradio3" autocomplete="off">
            <label class="btn fs-4 btn-light btn-outline-success" for="btnradio3">Favorites</label>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4 py-2">
        <RecipeCard :recipe="recipe" />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
.bgImg {
  background-image: url("https://images.unsplash.com/photo-1483137140003-ae073b395549?q=80&w=3270&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");
  min-height: 45dvh;
  background-position: center;
  background-size: cover;
}
</style>
