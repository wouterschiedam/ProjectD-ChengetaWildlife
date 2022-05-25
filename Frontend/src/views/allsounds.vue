<template>
  <div class="allsounds-container">
    <div class="allsounds-image">
      <app-header></app-header>
      <img
        alt="image"
        src="/playground_assets/gray-vector.svg"
        class="allsounds-image1"
      />
      <div class="allsounds-container01">
        <h1 class="allsounds-text"><span>Waargenomen geluiden</span></h1>
        <div class="allsounds-container02">
          <label class="allsounds-text02">Afspelen</label>
          <label class="allsounds-text03">Id</label>
        </div>
        <div class="allsounds-container03">
          <div class="allsounds-container04">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text04">5832583</label>
          </div>
          <div class="allsounds-container05">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon02">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text05">2199709</label>
          </div>
          <div class="allsounds-container06">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon04">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text06">3061811</label>
          </div>
          <div class="allsounds-container07">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon06">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text07">0388667</label>
          </div>
          <div class="allsounds-container08">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon08">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text08">1613551</label>
          </div>
          <div class="allsounds-container09">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon10">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text09">6546322</label>
          </div>
          <div class="allsounds-container10">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon12">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text10">5569585</label>
          </div>
          <div class="allsounds-container11">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon14">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text11">7240092</label>
          </div>
          <div class="allsounds-container12">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon16">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text12">9188789</label>
          </div>
          <div class="allsounds-container13">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon18">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text13">5884827</label>
          </div>
          <div class="allsounds-container14">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon20">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text14">4212807</label>
          </div>
          <div class="allsounds-container15">
            <svg viewBox="0 0 1024 1024" class="allsounds-icon22">
              <path
                d="M426 704l256-192-256-192v384zM512 86q176 0 301 125t125 301-125 301-301 125-301-125-125-301 125-301 301-125z"
              ></path>
            </svg>
            <label class="allsounds-text15">1448410</label>
          </div>
        </div>
      </div>
      <app-footer rootClassName="footer-root-class-name"></app-footer>
    </div>
  </div>
</template>

<script>
import AppHeader from '../components/header'
import AppFooter from '../components/footer'

export default {
  name: 'Allsounds',
  components: {
    AppHeader,
    AppFooter,
  },
  metaInfo: {
    title: 'All sounds - Chengeta wildlife',
    meta: [
      {
        property: 'og:title',
        content: 'All sounds - Chengeta wildlife',
      },
    ],
  },
}
</script>

<style scoped>
.allsounds-container {
  width: 100%;
  height: auto;
  display: flex;
  min-height: 100vh;
  align-items: center;
  flex-direction: column;
  justify-content: flex-start;
  background-color: var(--dl-color-pimary-900);
}
.allsounds-image {
  flex: 0 0 auto;
  width: 100%;
  height: 500px;
  display: flex;
  position: relative;
  align-items: center;
  flex-direction: column;
  background-size: cover;
  background-image: url("/playground_assets/prachtige-omgeving-van-de-bomen-savannepleinen-tijdens-zonsondergang-perfect-voor-achtergrond-het-landschap-die-1775295162-1500w.jpg");
}
.allsounds-image1 {
  left: auto;
  right: auto;
  width: 100%;
  bottom: -1px;
  z-index: 100;
  position: absolute;
  object-fit: cover;
}
.allsounds-container01 {
  width: 784px;
  height: 681px;
  display: flex;
  z-index: 100;
  position: relative;
  max-width: 80%;
  box-shadow: 0 20px 25px -5px rgba(0,0,0,0.1),0 10px 10px -5px rgba(0,0,0,0.04);
  margin-top: var(--dl-space-space-fiveunits);
  align-items: center;
  margin-left: 0px;
  margin-right: 0px;
  border-radius: var(--dl-radius-radius-radius75);
  margin-bottom: var(--dl-space-space-doubleunit);
  flex-direction: column;
  justify-content: flex-start;
  background-color: var(--dl-color-gray-white);
}
.allsounds-text {
  color: var(--dl-color-gray-black);
  margin-top: var(--dl-space-space-halfunit);
  padding-bottom: var(--dl-space-space-triplequarter);
}
.allsounds-container02 {
  width: 100%;
  height: 35px;
  display: flex;
  align-items: flex-start;
  border-color: var(--dl-color-gray-900);
  border-width: 1px;
}
.allsounds-text02 {
  color: #060606;
  align-self: flex-start;
  margin-left: 0.25rem;
}
.allsounds-text03 {
  color: #060606;
  align-self: flex-start;
  margin-left: 1.2rem;
}
.allsounds-container03 {
  width: 100%;
  height: 672px;
  display: flex;
  align-items: center;
  margin-bottom: var(--dl-space-space-tripleunit);
  flex-direction: column;
  justify-content: flex-start;
}
.allsounds-container04 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon:hover {
  cursor: pointer;
  transform: scale(1.1);
}
.allsounds-icon:active {
  cursor: pointer;
}
.allsounds-text04 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container05 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon02 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon02:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text05 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container06 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon04 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon04:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text06 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container07 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon06 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon06:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text07 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container08 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon08 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon08:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text08 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container09 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon10 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon10:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text09 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container10 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon12 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon12:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text10 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container11 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon14 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon14:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text11 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container12 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon16 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon16:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text12 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container13 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon18 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon18:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text13 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container14 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon20 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon20:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text14 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
.allsounds-container15 {
  flex: 0 0 auto;
  width: auto;
  height: auto;
  display: flex;
  align-self: flex-start;
  align-items: flex-start;
  justify-content: center;
}
.allsounds-icon22 {
  fill: #3a65ff;
  width: 32px;
  height: 32px;
  margin-top: var(--dl-space-space-halfunit);
  transition: 0.3s;
  margin-left: var(--dl-space-space-halfunit);
  margin-right: var(--dl-space-space-halfunit);
}
.allsounds-icon22:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.allsounds-text15 {
  color: #000000;
  width: 10rem;
  font-size: smaller;
  align-self: flex-start;
  margin-top: var(--dl-space-space-halfunit);
  margin-left: var(--dl-space-space-doubleunit);
  padding-top: 0px;
  border-color: #3a65ff;
  border-width: 2px;
  padding-left: var(--dl-space-space-halfunit);
  border-radius: var(--dl-radius-radius-radius4);
  background-color: #ffffff;
}
@media(max-width: 479px) {
  .allsounds-container01 {
    width: 100%;
  }
}
</style>
