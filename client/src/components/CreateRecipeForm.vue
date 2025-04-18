<script setup>

</script>


<template>
  <div class="modal-header bg-success rounded-top-1">
    <h3 class="modal-title text-light">New Recipe</h3>
    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
  </div>
  <div class="modal-body">
    <form>
      <div class="d-flex">
        <label for="">Title</label>
        <input type="text" placeholder="Title..." required minlength="3" maxlength="50">
        <label for="">Category</label>
        <select name="category " id="" required>
          <option value="breakfast">Breakfast</option>
          <option value="lunch">Lunch</option>
          <option value="dinner">Dinner</option>
          <option value="snack">Snack</option>
          <option value="dessert">Dessert</option>
        </select>

      </div>
      <label for="">Image</label>
      <input type="url" placeholder="Image...">
    </form>
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
    <button type="button" class="btn btn-primary">Save changes</button>
  </div>
</template>


<style lang="scss" scoped>
label {
  display: block;
}

input {
  width: 100%;
}
</style>