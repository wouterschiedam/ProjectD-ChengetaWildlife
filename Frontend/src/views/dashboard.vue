<template>
  <div>
    <app-header1 rootClassName="header1-root-class-name"></app-header1>
    <div class="sidebar">

    </div>
    <div class="dashboard-map" id="map">
      <l-map
        style="height: 100%; width: 100%"
        :zoom="zoom"
        :center="center"
        :bounds="bounds"
        :max-bounds="maxBounds"
      >
        <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
        <l-Circle
          :lat-lng="circle.center"
          :radius="circle.radius"
          :color="circle.color"
        />
      </l-map>
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
            <td>{{ sound.id }}</td>
            <td>{{ sound.latitude }}</td>
            <td>{{ sound.longitude }}</td>
            <td>{{ sound.soundtype }}</td>
            <td>{{ sound.probability + "%" }}</td>
            <td>
              <audio controls>
                <source v-bind:src="sound.sound" />
              </audio>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import AppHeader1 from "../components/header1";
import AppFooter from "../components/footer";
import { latLngBounds, latLng } from "leaflet";
import { LMap, LTileLayer, LMarker, LCircle } from "vue2-leaflet";
import html2canvas from "html2canvas";
import axios from "axios";
export default {
  name: "Dashboard",

  components: {
    AppHeader1,
    AppFooter,
    LMap,
    LTileLayer,
    LMarker,
    LCircle,
  },
  data() {
    return {
      sounds: [],
      id: 0,
      latitude: "",
      longitude: "",
      soundtype: "",
      probability: 0,
      sound: "",
      time: 0,
      url: "http://{s}.tile.osm.org/{z}/{x}/{y}.png",
      attribution:
        '&copy; <a target="_blank" href="http://osm.org/copyright%22%3EOpenStreetMap</a> contributors',
      zoom: 16,
      center: [51.505, -0.159],
      bounds: latLngBounds([
        [-2.30081290280357, 23.16963806152345],
        [-2.82991732677597, 23.58716201782228],
      ]),
      maxBounds: latLngBounds([
        [-2.30081290280357, 23.16963806152345],
        [-2.82991732677597, 23.58716201782228],
      ]),
      Markers: [],
      circle: {
        center: [-2.45, 13.359],
        radius: 1000,
        color: "#ff7800",
      },
      circle: {
        center: [-44.55, 23.34],
        radius: 1118,
        color: "red",
      },
    };
  },
  methods: {
    GetSounds() {
      axios
        .get("api/auth/mqttdata")
        .then((response) => {
          this.sounds = response.data;
        })
        .catch(function (error) {
          console.log(error);
          alert(error);
        });
    },
    fullScreenView() {
      var mapId = document.getElementById("map");
      mapId.requestFullscreen();
    },
    printMapHtml() {
      const screenshotTarget = document.getElementById("map");
      html2canvas(screenshotTarget, {
        useCORS: true,
        allowTaint: true,
      }).then((canvas) => {
        const base64image = canvas.toDataURL("image/png");
        var temp_link = document.createElement("a");
        temp_link.href = base64image;
        temp_link.download = "map.png";
        temp_link.click();
      });
    },
  },
  metaInfo: {
    title: "dashboard - Chengeta wildlife",
    meta: [
      {
        property: "og:title",
        content: "dashboard - Chengeta wildlife",
      },
    ],
  },
  mounted() {
    this.GetSounds();
  },
};
</script>

<style scoped>

table {
  width: 300px;
  border-collapse: collapse;
}
table,
th,
td {
  border: 1px solid grey;
}
th,
td {
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
.dashboard-map {
  top: 0px;
  left: 17%;
  flex: 0 0 auto;
  width: 80%;
  height: 517px;
  display: flex;
  position: relative;
  align-self: flex-end;
  align-items: flex-start;
  flex-direction: column;
}
.dashboard-geluidendata {
  flex: 0 0 auto;
  left: 17%;
  width: 80%;
  height: auto;
  display: flex;
  position: absolute;
  /* align-items: flex-start; */
  margin-left: 2%;
  flex-direction: column;
}
.sidebar {
  position: absolute;
  width: 15%;
  z-index: 1;
  left: 0;
  height: 100%;
  background-color: #110577;
}
</style>
