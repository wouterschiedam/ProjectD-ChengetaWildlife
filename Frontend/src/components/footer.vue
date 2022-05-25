<template>
  <div class="footer-container" v-bind:class="rootClassName">
    <span class="footer-text textSM">
      Copyright © 2022 Hogeschool Rotterdam Project-D
    </span>
  </div>
</template>

<script>
export default {
  name: 'Footer',
  props: {
    rootClassName: String,
  },
}
</script>

<style scoped>
.footer-container {
  width: 100%;
  display: flex;
  padding: var(--dl-space-space-doubleunit);
  align-items: center;
  flex-direction: column;
  justify-content: center;
  background-color: var(--dl-color-pimary-900);
}
.footer-text {
  color: var(--dl-color-secondary-500);
  align-self: center;
}
.footer-root-class-name {
  align-self: center;
  margin-top: var(--dl-space-space-triplequarter);
}
.footer-root-class-name1 {
  margin-top: 11rem;
}
.footer-root-class-name2 {
  margin-top: 13.5rem;
}
@media(max-width: 479px) {
  .footer-root-class-name1 {
    margin-top: 11rem;
  }
}
</style>
