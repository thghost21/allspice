<script setup>
import ModalComponent from './components/ModalComponent.vue';
import Navbar from './components/Navbar.vue';
import { RouterView } from 'vue-router';
import RecipeModal from './components/RecipeModal.vue';

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <RouterView />
  </main>
  <footer class=" text-center">
    Made with <i class="mdi mdi-heart text-pink"></i> by CodeWorks
  </footer>
</template>

<style lang="scss"></style>
