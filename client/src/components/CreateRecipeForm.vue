<script setup>
import { recipeService } from '@/services/RecipesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { Modal } from 'bootstrap/dist/js/bootstrap.bundle.js';
import { ref } from 'vue';

const editableRecipeData = ref({
  title: '',
  category: '',
  img: '',
})

async function createRecipe() {
  try {
    await recipeService.createRecipe(editableRecipeData.value)
    Modal.getOrCreateInstance('#createModal').hide()
    Modal.getOrCreateInstance('#recipeModal').show()
  }
  catch (error) {
    Pop.error(error, 'could not create recipe');
    logger.error('could not create recipe', error)
  }
}
</script>


<template>
  <form @submit.prevent="createRecipe()">
    <div class="modal-header bg-success rounded-top-1">
      <h3 class="modal-title text-light">New Recipe</h3>
      <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
    </div>
    <div class="modal-body">
      <div class="d-flex flex-column">
        <label for="">Title</label>
        <input v-model="editableRecipeData.title" type="text" placeholder="Title..." required minlength="3"
          maxlength="50">
        <label for="">Category</label>
        <select v-model="editableRecipeData.category" name="category " id="category" required>
          <option value="breakfast">Breakfast</option>
          <option value="lunch">Lunch</option>
          <option value="dinner">Dinner</option>
          <option value="snack">Snack</option>
          <option value="dessert">Dessert</option>
        </select>

      </div>
      <label for="">Image</label>
      <input v-model="editableRecipeData.img" type="url" placeholder="Image...">
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
      <button type="submit" class="btn btn-primary">Save changes</button>
    </div>
  </form>
</template>


<style lang="scss" scoped>
label {
  display: block;
}

input {
  width: 100%;
}
</style>