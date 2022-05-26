<template>
  <div class="component1-container">
    <span class="component1-text textSM">{{ text }}</span>
  </div>
</template>

<script>
export default {
  name: 'Component1',
  props: {
    text: {
      type: String,
      default: 'Copyright © 2022 Hogeschool Rotterdam Project-D',
    },
  },
}
</script>

<style scoped>
.component1-container {
  width: 100%;
  height: 24px;
  display: flex;
  padding: var(--dl-space-space-doubleunit);
  position: relative;
  align-items: center;
  flex-direction: column;
  justify-content: center;
  background-color: var(--dl-color-gray-900);
}
.component1-text {
  color: var(--dl-color-secondary-500);
  align-self: center;
}
</style>
