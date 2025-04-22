<script setup>
import { AppState } from '@/AppState.js';
import { recipeService } from '@/services/RecipesService.js';
import { Pop } from '@/utils/Pop.js';
import { Modal } from 'bootstrap/dist/js/bootstrap.bundle.js';
import { computed } from 'vue';


const recipe = computed(() => AppState.activeRecipe)


async function deleteRecipe(recipeId) {
  try {
    const confirmed = await Pop.confirm("are you sure?")
    if (!confirmed) {
      return
    }
    await recipeService.deleteRecipe(recipeId)
    Modal.getOrCreateInstance('#recipeModal').hide()
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <section v-if="recipe" class="container">
    <div class="row justify-content-center ">
      <div class="col-md-4 px-0 text-end ">
        <div class="recipe-img rounded-start " :style="{ backgroundImage: `url(${recipe.img})` }">
          <div class="">
            <span class="mdi fs-3 mdi-heart bg-gray mt-0 px-2 rounded-bottom text-red"></span>

          </div>

        </div>
        <!-- <img class="img-fluid recipe-img rounded-start" :src="recipe.img" alt=""> -->
      </div>
      <div class="col-md-8 pt-2 d-flex flex-column">
        <div class="d-flex justify-content-between">
          <div class="d-flex align-items-bottom">
            <h3 class="text-success">{{ recipe.title }}</h3>
            <span class="m-2 bg-gray px-2 rounded text-light">{{ recipe.category }}</span>
          </div>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="row pt-3 flex-grow-1">
          <div class="col-md-6 ">
            <div class="card text-start bg-success-subtle h-100 shadow">
              <div class="card-header bg-success">
                Recipe Steps
              </div>
              <div class="card-body">
                <p class="card-text">{{ recipe.instructions }}</p>
                <a href="#" class="btn btn-primary">Go somewhere</a>
              </div>
            </div>
          </div>
          <div class="col-md-6 pt-2 pt-md-0 flex-grow-1">
            <div class="card text-start bg-success-subtle h-100 shadow">
              <div class="card-header bg-success">
                Ingredients </div>
              <div class="card-body">
                <h5 class="card-title">Special title treatment</h5>
                <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                <a href="#" class="btn btn-primary">Go somewhere</a>
              </div>
            </div>
          </div>
        </div>
        <div class="text-end py-1 align-self-end col-12 ">
          <button @click="deleteRecipe(recipe.id)" title="Delete Recipe" class="btn btn-outline-red me-2">Delete
            Recipe</button>
          <span>published by: {{ recipe.creator.name }}</span>
        </div>
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>
.recipe-img {
  height: 50dvh;
  width: 100%;
  background-position: center;
  background-size: cover;
}
</style>