<template>
  <div class="dashboard-container">
    <app-header1 rootClassName="header1-root-class-name"></app-header1>
    <div class="dashboard-container1">
      <div class="dashboard-map" id="map">
            <l-map style="height: 100%; Width: 100%;" :zoom="zoom" :center="center" :bounds ="bounds" :max-bounds="maxBounds">
            <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
            <l-Circle
              :lat-lng="circle.center"
              :radius="circle.radius"
              :color="circle.color"
            />
            </l-map>
      </div>
      <div class="dashboard-sidebar">
        <div class="dashboard-container2">
          <span class="dashboard-text">Dashboard</span>
          <span class="dashboard-text" @click=fullScreenView()>Fullscreen</span>
          <span class="dashboard-text" @click=printMapHtml()>Print map</span>
          <span class="dashboard-text">Historische data</span>
        </div>
      </div>
      <div class="dashboard-geluidendata"></div>
    </div>
    <app-footer rootClassName="footer-root-class-name3"></app-footer>
  </div>
</template>

<script>
import AppHeader1 from '../components/header1'
import AppFooter from '../components/footer'
import { latLngBounds, latLng } from "leaflet";
import { LMap, LTileLayer, LMarker, LCircle } from 'vue2-leaflet';
import html2canvas from 'html2canvas';

export default {
  name: 'Dashboard',
  components: {
    AppHeader1,
    AppFooter,
    LMap,
    LTileLayer,
    LMarker,
    LCircle
  },
  data(){
        return {
            url: 'http://{s}.tile.osm.org/{z}/{x}/{y}.png',
            attribution:
                '&copy; <a target="_blank" href="http://osm.org/copyright%22%3EOpenStreetMap</a> contributors',
            zoom: 16,
            center: [51.505, -0.159],
            bounds: latLngBounds([
                  [-2.30081290280357, 23.16963806152345],
                  [-2.82991732677597, 23.58716201782228]
                ]),
            maxBounds: latLngBounds([
                  [-2.30081290280357, 23.16963806152345],
                  [-2.82991732677597, 23.58716201782228]
                ]),
            Markers: [],
            circle : {
              center: [-2.45, 13.359],
              radius: 1000,
              color: '#ff7800'
            },
            circle: {
              center: [-44.55, 23.34],
              radius: 1118,
              color: 'red'}
        };
  },
    methods: {
        fullScreenView() {
            var mapId = document.getElementById('map');
            mapId.requestFullscreen();
        },
        printMapHtml() {
            const screenshotTarget = document.getElementById('map');
            html2canvas(screenshotTarget, {
                useCORS: true,
                allowTaint: true
            }).then((canvas) => {
                const base64image = canvas.toDataURL("image/png");
                var temp_link = document.createElement('a');
                temp_link.href = base64image;
                temp_link.download = "map.png";
                temp_link.click();
            });
        }
    },
      mounted() {

    },
  metaInfo: {
    title: 'dashboard - Chengeta wildlife',
    meta: [
      {
        property: 'og:title',
        content: 'dashboard - Chengeta wildlife',
      },
    ],
  },
}
</script>

<style scoped>
.dashboard-container {
  width: 100%;
  display: flex;
  overflow: auto;
  min-height: 100vh;
  align-items: center;
  flex-direction: column;
  background-color: #D9D9D9;
}
.dashboard-container1 {
  width: 100%;
  height: 100%;
  display: flex;
  position: relative;
  align-items: flex-start;
  background-color: #D9D9D9;
}
.dashboard-map {
  top: 0px;
  flex: 0 0 auto;
  left: 200px;
  width: 100%;
  height: 517px;
  display: flex;
  position: absolute;
  align-self: flex-end;
  align-items: flex-start;
  flex-direction: column;
}
.dashboard-sidebar {
  flex: 0 0 auto;
  width: 200px;
  height: 912px;
  display: flex;
  position: relative;
  align-items: flex-start;
  flex-direction: column;
  background-color: #efefef;
}
.dashboard-container2 {
  width: 200px;
  height: 232px;
  display: flex;
  position: relative;
  align-items: flex-start;
  flex-direction: column;
}
.dashboard-text {
  top: var(--dl-space-space-unit);
  left: 59px;
  align-self: center;
  cursor: pointer;
  color: black;
  margin-bottom: 1rem;
}
.dashboard-text1 {
  top: var(--dl-space-space-tripleunit);
  left: 40px;
  position: absolute;
  align-self: center;
  color: black;
}
.dashboard-geluidendata {
  flex: 0 0 auto;
  left: 200px;
  width: 100%;
  bottom: 0px;
  height: 371px;
  display: flex;
  position: absolute;
  align-items: flex-start;
  flex-direction: column;
}
@media(max-width: 991px) {
  .dashboard-map {
    width: 776px;
  }
  .dashboard-geluidendata {
    width: 775px;
  }
}
@media(max-width: 767px) {
  .dashboard-map {
    width: 563px;
  }
  .dashboard-geluidendata {
    width: 565px;
  }
}
@media(max-width: 479px) {
  .dashboard-map {
    width: 280px;
  }
  .dashboard-sidebar {
    width: 143px;
    padding-right: 0px;
  }
  .dashboard-text {
    align-self: flex-start;
  }
  .dashboard-text1 {
    left: 0px;
  }
  .dashboard-geluidendata {
    width: 282px;
  }
}
</style>
