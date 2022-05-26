<template>
  <div class="dashboard-container">
    <app-header1 rootClassName="header1-root-class-name"></app-header1>
    <div class="dashboard-container1">
      <div class="dashboard-map" id="map">
            <l-map style="height: 100%; Width: 100%;" :zoom="zoom" :center="center" :bounds ="bounds" :max-bounds="maxBounds">
            <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
            <l-marker :lat-lng="markerLatLng"></l-marker>
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
      <div class="dashboard-geluidendata">
          <h1 style="color: black">Sounds</h1>
              <table style="color: black">
                  <tr>
                      <th>ID</th>
                      <th>Latitude</th>
                      <th>Longitude</th>
                      <th>Soundtype</th>
                      <th>Probability</th>
                      <th>Sound</th>
                  </tr>
                  <tbody v-for="sound in sounds" :key="sound.id">
                      <tr>
                          <td> {{ sound.id }} </td>
                          <td> {{ sound.latitude }} </td>
                          <td> {{ sound.longitude }} </td>
                          <td> {{ sound.soundtype }} </td>
                          <td> {{ sound.probability + "%" }} </td>
                          <td>
                              <audio controls>
                                <source v-bind:src="sound.sound">
                              </audio>
                          </td>
                      </tr>
                  </tbody>
              </table>
          </div>
      </div>
    <!--<app-footer rootClassName="footer-root-class-name3"></app-footer>-->
  </div>
</template>

<script>
import AppHeader1 from '../components/header1'
import AppFooter from '../components/footer'
import { latLngBounds, latLng, Icon } from "leaflet";
import { LMap, LTileLayer, LMarker, LCircle } from 'vue2-leaflet';
import html2canvas from 'html2canvas';

delete Icon.Default.prototype._getIconUrl;
Icon.Default.mergeOptions({
  iconRetinaUrl: require('leaflet/dist/images/marker-icon-2x.png'),
  iconUrl: require('leaflet/dist/images/marker-icon.png'),
  shadowUrl: require('leaflet/dist/images/marker-shadow.png')
}) 

export default {
  name: 'Dashboard',
        data() {
            return {
                sounds: [],
                id: 0,
                latitude: '',
                longitude: '',
                soundtype: '',
                probability: 0,
                sound: '',
                time: 0
            }
        },
        methods: {
            GetSounds() {
                axios.get("api/auth/mqttdata")
                    .then((response) => {
                        this.sounds = response.data;
                        this.Markers = response.data;
                                                response.data.forEach((element) => {
                        this.Markers.push({
                          sounds: [element.longitude.split(',')[0], element.latitude.split(',')[1]],
                          });
                          Markers.addTo(LMap); // hier gebleven, maar werkt niet
                        });                    
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    })
            }
        },
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
            markerLatLng: [-2.82991732677597, 23.58716201782228],
            bounds: latLngBounds([
                  [-2.30081290280357, 23.16963806152345],
                  [-2.82991732677597, 23.58716201782228]
                ]),
            maxBounds: latLngBounds([
                  [-2.30081290280357, 23.16963806152345],
                  [-2.82991732677597, 23.58716201782228]
                ]),
            circle : {
              center: [-2.45, 13.359],
              radius: 1000,
              color: '#ff7800'
            },
            circle: {
              center: [-44.55, 23.34],
              radius: 1118,
              color: 'red'
            },
            
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
  mounted() {
    this.GetSounds();
  }
}
</script>

<style scoped>
table {
    width: 300px;
    border-collapse: collapse;
}
table, th, td {
    border: 1px solid grey;
}
th, td {
    padding: 10px;
    text-align: left;
}
.soundInfo {
    display: flex;
    color: black;
    width: 100%;

}
.soundInfo div {
    margin: 2% 8% 0 0;
}

.soundInfo div p {
    margin-bottom: 3%;
}

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
  /* align-items: flex-start; */
  margin-left: 2%;
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
