<template>
  <div class="home-container">
    <div class="home-hero">
      <div class="home-bg">
        <img
          alt="image"
          src="/playground_assets/why-wildlife-900h.jpg"
          class="home-image"
        />
      </div>
      <app-header></app-header>
      <div class="home-container1">
        <div class="home-container2">
          <h1 class="home-text"><span>Chengata Wildlife</span></h1>
          <span class="home-text02">
            <span>
              Chengeta Wildlife is actief in belangrijke gebieden in Afrika om
              rangers op te leiden
              <span v-html="rawg0o3"></span>
            </span>
            <br />
            <span>
              en duurzame gemeenschapinspanningen te ondersteunen om de lokale
              wilde dieren
            </span>
            <br />
            <span>te beschermen.</span>
          </span>
        </div>
        <img
          alt="image"
          src="/playground_assets/gray-vector.svg"
          class="home-image1"
        />
        <img
          alt="image"
          src="/playground_assets/white-vector.svg"
          class="home-image2"
        />
      </div>
    </div>
    <div class="home-section1">
      <div class="home-container3">
        <div class="home-container4">
          <h3 class="home-text08 healine">Onze missie</h3>
          <span class="home-text09 textXL">
            <span class="home-text10">
              Lokaal geleide en duurzame bescherming van de natuur bieden, waarbij
              de mens als deel van het ecosysteem wordt erkend. Het is intelligent
              gericht, deskundig en gerechtelijk toegepast, kosteneffectief en
              geharmoniseerd met alle andere bestaande inspanningen ter
              bescherming van in het wild levende dieren en planten.
            </span>
          </span>
        </div>
        <div class="home-cards-container">
          <div class="home-card1">
            <div class="home-container5">
              <svg viewBox="0 0 1024 1024" class="home-icon">
                <path
                  d="M639.403 658.091l32 241.152-137.429-82.475c-13.269-7.851-29.995-8.363-43.904 0l-137.429 82.475 32.043-241.109c39.296 15.829 82.304 24.533 127.317 24.533s88.021-8.747 127.403-24.576zM654.165 554.283c-2.475 1.28-4.821 2.773-6.955 4.48-39.253 24.448-85.547 38.571-135.211 38.571-70.699 0-134.656-28.587-181.035-74.965s-74.965-110.336-74.965-181.035 28.587-134.656 74.965-181.035 110.336-74.965 181.035-74.965 134.656 28.587 181.035 74.965 74.965 110.336 74.965 181.035-28.587 134.656-74.965 181.035c-11.861 11.861-24.875 22.571-38.869 31.915zM304.64 612.48l-48.256 363.221c-3.115 23.339 13.312 44.8 36.693 47.915 9.984 1.323 19.669-0.939 27.563-5.717l191.36-114.816 191.403 114.816c20.224 12.117 46.421 5.589 58.539-14.635 5.205-8.661 6.955-18.389 5.717-27.563l-48.213-363.307c11.947-9.173 23.296-19.115 33.92-29.739 61.696-61.696 99.968-147.072 99.968-241.323s-38.272-179.627-99.968-241.365-147.115-99.968-241.365-99.968-179.627 38.272-241.365 99.968-99.968 147.115-99.968 241.365 38.272 179.627 99.968 241.365c10.667 10.667 22.016 20.608 33.963 29.781z"
                ></path>
              </svg>
            </div>
            <h6 class="home-text11 textXL"><span>Ons werk</span></h6>
            <span class="home-text13">
              Chengeta Wildlife maintains a simple operating principle across five
              key pillars to support the protection of wildlife.
            </span>
          </div>
          <div class="home-card2">
            <app-component></app-component>
            <h6 class="home-text14 textXL">Onze projecten</h6>
            <span class="home-text15">
              Chengeta wildlife houdt zich bezig in natuurgebieden in Africa om
              rangers opteleiden en de wilde dieren te beschermen.
            </span>
          </div>
          <div class="home-card3">
            <div class="home-container6">
              <svg viewBox="0 0 1024 1024" class="home-icon2">
                <path
                  d="M636 938h-6q-92-24-158-90-38-38-65-103t-27-119q0-52 38-89t92-37 93 37 39 89q0 34 25 58t63 24 64-24 26-58q0-120-91-206t-219-86q-92 0-168 47t-114 125q-24 50-24 120 0 80 28 154 6 20-14 26t-26-12q-32-82-32-168 0-78 30-138 42-90 129-144t191-54q146 0 249 99t103 237q0 52-39 88t-93 36-92-36-38-88q0-34-26-59t-64-25-63 25-25 59q0 112 80 192 56 56 140 78 18 2 14 26-4 16-20 16zM530 626q0 74 55 128t137 54q4 0 18-2t23-2 18 3 11 13q4 22-18 26-24 4-52 4-80 0-132-38-102-70-102-186 0-22 22-22 20 0 20 22zM416 930q-8 0-14-6-54-54-86-114-46-80-46-184 0-94 71-162t171-68 171 68 71 162q0 20-22 20t-22-20q0-78-58-133t-140-55-140 55-58 133q0 96 38 164 26 46 80 104 16 14 0 30-6 6-16 6zM150 414q-22 0-22-20 0-4 4-12 64-92 160-140 100-52 220-52t220 52q98 48 160 138 4 8 4 12 0 14-16 20t-24-8q-60-82-144-124-92-46-200-47t-200 47q-90 46-146 126-6 8-16 8zM760 190q-8 0-10-2-118-60-238-60-130 0-238 60-10 6-20 0t-10-18q0-14 10-20 116-64 258-64 130 0 258 64 18 10 8 28-8 12-18 12z"
                ></path>
              </svg>
            </div>
            <h6 class="home-text16 textXL"><span>Hoe kan je helpen</span></h6>
            <span class="home-text18">
              Get involved with Chengeta Wildlife by supporting our work with a
              donation, creating your own fundraiser or shopping at our online
              store.
            </span>
          </div>
        </div>
      </div>
    </div>
    <app-footer></app-footer>
  </div>
</template>

<script>
import AppHeader from '../components/header'
import AppComponent from '../components/component'
import AppFooter from '../components/footer'

export default {
  name: 'Home',
  components: {
    AppHeader,
    AppComponent,
    AppFooter,
  },

  data() {
    return {
      rawg0o3: ' ',
    }
  },

  metaInfo: {
    title: 'Chengeta wildlife',
    meta: [
      {
        property: 'og:title',
        content: 'Chengeta wildlife',
      },
    ],
  },
}
</script>

<style scoped>
.home-container {
  width: 100%;
  height: auto;
  display: flex;
  min-height: 100vh;
  align-items: flex-start;
  flex-direction: column;
}
.home-hero {
  flex: 0 0 auto;
  width: 100%;
  height: 80vh;
  display: flex;
  position: relative;
  align-items: center;
  flex-direction: column;
}
.home-bg {
  flex: 0 0 auto;
  width: 100%;
  height: 100%;
  display: flex;
  opacity: 0.7;
  position: absolute;
  align-items: flex-start;
  flex-direction: column;
  background-color: var(--dl-color-gray-black);
}
.home-image {
  width: 100%;
  height: 845px;
  object-fit: cover;
}
.home-container1 {
  top: auto;
  left: auto;
  right: 0px;
  width: 100%;
  bottom: 0px;
  height: 875px;
  display: flex;
  position: absolute;
  align-items: center;
  flex-direction: column;
  justify-content: center;
}
.home-container2 {
  display: flex;
  opacity: 1;
  align-items: center;
  padding-left: var(--dl-space-space-tripleunit);
  padding-right: var(--dl-space-space-tripleunit);
  flex-direction: column;
  justify-content: center;
}
.home-text {
  color: var(--dl-color-gray-white);
  text-align: center;
}
.home-text02 {
  color: #ffffff;
}
.home-image1 {
  top: auto;
  left: auto;
  right: 0px;
  width: 100%;
  bottom: -1px;
  position: absolute;
  object-fit: cover;
}
.home-image2 {
  left: auto;
  right: 0px;
  width: 100%;
  bottom: 0px;
  position: absolute;
  object-fit: cover;
}
.home-section1 {
  width: 100%;
  height: 819px;
  display: flex;
  position: relative;
  align-items: center;
  padding-top: var(--dl-space-space-tripleunit);
  padding-left: var(--dl-space-space-doubleunit);
  padding-right: var(--dl-space-space-doubleunit);
  flex-direction: column;
  padding-bottom: var(--dl-space-space-fiveunits);
  background-color: var(--dl-color-pimary-900);
}
.home-container3 {
  width: 100%;
  display: flex;
  max-width: 1320px;
  align-items: center;
  flex-direction: column;
}
.home-container4 {
  width: 66%;
  display: flex;
  align-items: center;
  padding-left: var(--dl-space-space-unit);
  padding-right: var(--dl-space-space-unit);
  flex-direction: column;
}
.home-text08 {
  color: var(--dl-color-secondary-400);
  text-align: center;
}
.home-text09 {
  color: var(--dl-color-secondary-700);
  text-align: center;
  margin-bottom: 0.25rem;
}
.home-text10 {
  display: inline;
  font-weight: 400;
  white-space: normal;
  background-color: rgb(241, 245, 249);
}
.home-cards-container {
  display: flex;
  margin-top: var(--dl-space-space-tripleunit);
  align-items: flex-start;
  padding-top: var(--dl-space-space-tripleunit);
  margin-bottom: var(--dl-space-space-tripleunit);
  flex-direction: row;
  padding-bottom: var(--dl-space-space-tripleunit);
  justify-content: space-between;
}
.home-card1 {
  flex: 0 0 auto;
  width: 30%;
  display: flex;
  padding: var(--dl-space-space-unit);
  box-shadow: 0 10px 15px -3px rgba(0,0,0,0.1),0 4px 6px -2px rgba(0,0,0,0.05);
  align-items: center;
  border-radius: var(--dl-radius-radius-radius50);
  flex-direction: column;
  background-color: var(--dl-color-gray-white);
}
.home-container5 {
  flex: 0 0 auto;
  width: 3rem;
  height: 3rem;
  display: flex;
  box-shadow: 0 10px 15px -3px rgba(0,0,0,0.1),0 4px 6px -2px rgba(0,0,0,0.05);
  align-items: center;
  border-radius: var(--dl-radius-radius-round);
  flex-direction: column;
  justify-content: center;
  background-image: linear-gradient(180deg, #f87171, #dc2626);
}
.home-icon {
  fill: var(--dl-color-gray-white);
  width: 24px;
  height: 24px;
}
.home-text11 {
  color: var(--dl-color-secondary-100);
  margin-top: var(--dl-space-space-unit);
  text-align: center;
  font-family: Open Sans;
}
.home-text13 {
  color: var(--dl-color-secondary-700);
  font-size: 1rem;
  margin-top: var(--dl-space-space-halfunit);
  text-align: center;
  font-family: Open Sans;
  line-height: 1.625rem;
}
.home-card2 {
  flex: 0 0 auto;
  width: 30%;
  display: flex;
  padding: var(--dl-space-space-unit);
  box-shadow: 0 10px 15px -3px rgba(0,0,0,0.1),0 4px 6px -2px rgba(0,0,0,0.05);
  align-items: center;
  border-radius: var(--dl-radius-radius-radius50);
  flex-direction: column;
  background-color: var(--dl-color-gray-white);
}
.home-text14 {
  color: var(--dl-color-secondary-100);
  margin-top: var(--dl-space-space-unit);
  text-align: center;
  font-family: Open Sans;
}
.home-text15 {
  color: var(--dl-color-secondary-700);
  font-size: 1rem;
  margin-top: var(--dl-space-space-halfunit);
  text-align: center;
  font-family: Open Sans;
  line-height: 1.625rem;
}
.home-card3 {
  flex: 0 0 auto;
  width: 30%;
  display: flex;
  padding: var(--dl-space-space-unit);
  box-shadow: 0 10px 15px -3px rgba(0,0,0,0.1),0 4px 6px -2px rgba(0,0,0,0.05);
  align-items: center;
  border-radius: var(--dl-radius-radius-radius50);
  flex-direction: column;
  background-color: var(--dl-color-gray-white);
}
.home-container6 {
  flex: 0 0 auto;
  width: 3rem;
  height: 3rem;
  display: flex;
  box-shadow: 0 10px 15px -3px rgba(0,0,0,0.1),0 4px 6px -2px rgba(0,0,0,0.05);
  align-items: center;
  border-radius: var(--dl-radius-radius-round);
  flex-direction: column;
  justify-content: center;
  background-image: linear-gradient(180deg, #34d399, #059669);
}
.home-icon2 {
  fill: var(--dl-color-gray-white);
  width: 24px;
  height: 24px;
}
.home-text16 {
  color: var(--dl-color-secondary-100);
  width: 204px;
  margin-top: var(--dl-space-space-unit);
  text-align: center;
  font-family: Open Sans;
}
.home-text18 {
  color: var(--dl-color-secondary-700);
  font-size: 1rem;
  margin-top: var(--dl-space-space-halfunit);
  text-align: center;
  font-family: Open Sans;
  line-height: 1.625rem;
}
@media(max-width: 991px) {
  .home-cards-container {
    align-items: center;
    flex-direction: column;
  }
  .home-card1 {
    width: 90%;
    margin-bottom: var(--dl-space-space-fiveunits);
  }
  .home-card2 {
    width: 90%;
    margin-bottom: var(--dl-space-space-fiveunits);
  }
  .home-card3 {
    width: 90%;
  }
}
@media(max-width: 767px) {
  .home-section1 {
    padding-left: var(--dl-space-space-doubleunit);
    padding-right: var(--dl-space-space-doubleunit);
  }
  .home-container4 {
    width: 100%;
  }
}
@media(max-width: 479px) {
  .home-container2 {
    padding-left: var(--dl-space-space-doubleunit);
    padding-right: var(--dl-space-space-doubleunit);
  }
  .home-card1 {
    margin-bottom: var(--dl-space-space-tripleunit);
  }
  .home-text13 {
    text-align: left;
  }
  .home-card2 {
    margin-bottom: var(--dl-space-space-tripleunit);
  }
  .home-text15 {
    text-align: left;
  }
  .home-text18 {
    text-align: left;
  }
}
</style>
