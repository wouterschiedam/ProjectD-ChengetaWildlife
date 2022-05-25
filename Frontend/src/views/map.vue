<template>
  <div class="map-container">
    <div class="map-image">
      <app-header></app-header>
      <img
        alt="image"
        src="/playground_assets/gray-vector.svg"
        class="map-image1"
      />
      <div class="map-bg"></div>
    </div>
    <div id="map" class="map-container1"></div>
    <app-footer></app-footer>
  </div>
</template>

<script>
import AppHeader from '../components/header'
import AppFooter from '../components/footer'

export default {
  name: 'Map',
  components: {
    AppHeader,
    AppFooter,
  },
  metaInfo: {
    title: 'Map - Chengeta wildlife',
    meta: [
      {
        property: 'og:title',
        content: 'Map - Chengeta wildlife',
      },
    ],
  },
}
</script>

<style scoped>
.map-container {
  width: 100%;
  height: auto;
  display: flex;
  min-height: 100vh;
  align-items: center;
  flex-direction: column;
  justify-content: flex-start;
  background-color: var(--dl-color-pimary-900);
}
.map-image {
  flex: 0 0 auto;
  width: 100%;
  height: 500px;
  display: flex;
  position: relative;
  align-items: center;
  flex-direction: column;
  background-size: cover;
  background-image: url("/playground_assets/istockphoto-1208290498-170667a-1500w.jpg");
}
.map-image1 {
  left: auto;
  right: auto;
  width: 100%;
  bottom: -1px;
  height: 52px;
  z-index: 100;
  position: absolute;
  object-fit: cover;
}
.map-bg {
  top: auto;
  flex: 0 0 auto;
  left: auto;
  right: 0px;
  width: 100%;
  bottom: auto;
  height: 100%;
  display: flex;
  opacity: 0.5;
  position: absolute;
  align-items: flex-start;
  flex-direction: column;
  background-size: cover;
  justify-content: center;
  background-image: url("/playground_assets/gray-vector.svg");
}
.map-container1 {
  flex: 0 0 auto;
  width: 80%;
  height: 770px;
  display: flex;
  z-index: 100;
  position: relative;
  max-width: 100%;
  box-shadow: 0 20px 25px -5px rgba(0,0,0,0.1),0 10px 10px -5px rgba(0,0,0,0.04);
  margin-top: -12rem;
  max-height: 80%;
  align-items: center;
  border-radius: var(--dl-radius-radius-radius75);
  margin-bottom: var(--dl-space-space-tripleunit);
  flex-direction: column;
  justify-content: flex-start;
  background-color: var(--dl-color-gray-white);
}
@media(max-width: 479px) {
  .map-container1 {
    width: 100%;
  }
}
</style>
