<script setup>

defineProps({
  modalId: { type: String, required: true },
  modalTitle: { type: String, required: true }
})

</script>


<template>
  <div class="modal fade" :id="modalId" tabindex="-1" :aria-labelledby="modalId + 'label'">
    <div class="modal-dialog modal-xl ">
      <div class="modal-content rounded  ">
        <div class="modal-body p-0 ">
          <slot></slot>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>