<template>
  <div class="sound-container">
    <div class="sound-image">
      <app-header></app-header>
      <img
        alt="image"
        src="/playground_assets/gray-vector.svg"
        class="sound-image1"
      />
      <div class="sound-bg"></div>
    </div>
    <div class="sound-container1">
      <h1 class="sound-text"><span>Waargenomen geluiden</span></h1>
      <div class="sound-container2">
        <div class="sound-container3">
          <svg viewBox="0 0 1024 1024" class="sound-icon">
            <path
              d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
            ></path>
          </svg>
          <label class="sound-text2">7123845</label>
        </div>
        <div class="sound-container4">
          <svg viewBox="0 0 1024 1024" class="sound-icon2">
            <path
              d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
            ></path>
          </svg>
          <label class="sound-text3">4352878</label>
        </div>
        <div class="sound-container5">
          <svg viewBox="0 0 1024 1024" class="sound-icon4">
            <path
              d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
            ></path>
          </svg>
          <label class="sound-text4">9064389</label>
        </div>
      </div>
      <router-link to="/sound1" class="sound-navlink button">
        <span class="sound-text5">
          <span>Zie alle geluiden</span>
          <span></span>
        </span>
      </router-link>
    </div>
    <app-footer rootClassName="footer-root-class-name2"></app-footer>
  </div>
</template>

<script>
import AppHeader from '../components/header'
import AppFooter from '../components/footer'

export default {
  name: 'Sound',
  components: {
    AppHeader,
    AppFooter,
  },
  metaInfo: {
    title: 'Sound - Chengeta wildlife',
    meta: [
      {
        property: 'og:title',
        content: 'Sound - Chengeta wildlife',
      },
    ],
  },
}
</script>

<style scoped>
.sound-container {
  width: 100%;
  height: auto;
  display: flex;
  min-height: 100vh;
  align-items: center;
  flex-direction: column;
  justify-content: flex-start;
  background-color: var(--dl-color-pimary-900);
}
.sound-image {
  flex: 0 0 auto;
  width: 100%;
  height: 500px;
  display: flex;
  position: relative;
  align-items: center;
  flex-direction: column;
  background-size: cover;
  background-image: url("https://images.unsplash.com/photo-1499336315816-097655dcfbda?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1000&q=80");
}
.sound-image1 {
  left: auto;
  right: auto;
  width: 100%;
  bottom: -1px;
  z-index: 100;
  position: absolute;
  object-fit: cover;
}
.sound-bg {
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
  background-color: var(--dl-color-gray-black);
}
.sound-container1 {
  flex: 0 0 auto;
  width: 770px;
  height: 334px;
  display: flex;
  z-index: 100;
  position: relative;
  max-width: 80%;
  box-shadow: 0 20px 25px -5px rgba(0,0,0,0.1),0 10px 10px -5px rgba(0,0,0,0.04);
  margin-top: -12rem;
  align-items: center;
  border-radius: var(--dl-radius-radius-radius75);
  margin-bottom: var(--dl-space-space-tripleunit);
  flex-direction: column;
  justify-content: flex-start;
  background-color: var(--dl-color-gray-white);
}
.sound-text {
  color: var(--dl-color-gray-black);
  margin-top: var(--dl-space-space-halfunit);
  padding-bottom: var(--dl-space-space-triplequarter);
}
.sound-container2 {
  flex: 0 0 auto;
  width: 100%;
  display: flex;
  align-items: center;
  margin-bottom: var(--dl-space-space-tripleunit);
  flex-direction: column;
  justify-content: flex-start;
}
.sound-container3 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.sound-icon {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.sound-icon:hover {
  cursor: pointer;
  transform: scale(1.1);
}
.sound-icon:active {
  cursor: pointer;
}
.sound-text2 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.sound-container4 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.sound-icon2 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.sound-icon2:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.sound-text3 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.sound-container5 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.sound-icon4 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.sound-icon4:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.sound-text4 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.sound-navlink {
  transition: 0.3s;
  border-color: #dadada;
  text-decoration: none;
  background-color: #3a65ff;
}
.sound-navlink:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.sound-text5 {
  color: #ffffff;
}
@media(max-width: 479px) {
  .sound-container1 {
    width: 100%;
  }
}
</style>
