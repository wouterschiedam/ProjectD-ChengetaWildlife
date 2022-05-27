<template>
  <div class="container"  v-if="isLoggedIn()">
    <aside>
      <div class="top">
        <div class="logo">
          <img
            src="../../public/playground_assets/217332412_177488101085809_6155924843160933349_n-1500h.jpg"
          />
          <h2>Chengeta</h2>
        </div>
        <div class="close" id="closee-btn">
          <span class="material-icons-sharp">close</span>
        </div>
      </div>
      <div class="sidebar">
        <a @click="router.push({name: 'test'}, )">
          <span class="material-icons-sharp">grid_view</span>
          <h3>Dashboard</h3>
        </a>
        <a @click="fullScreenView()">
          <span class="material-icons-sharp">fullscreen</span>
          <h3>Fullscreen</h3>
        </a>
        <a @click="printMapHtml()">
          <span class="material-icons-sharp">print</span>
          <h3>Print map</h3>
        </a>
        <a href="#">
          <span class="material-icons-sharp">work_history</span>
          <h3>Historische data</h3>
        </a>
        <a v-if="this.superUser" @click="Account()">
          <span class="material-icons-sharp">person_add</span>
          <h3>Nieuw account</h3>
        </a>
        <a @click="Logout()">
          <span class="material-icons-sharp">logout</span>
          <h3>Uitloggen</h3>
        </a>
      </div>
    </aside>
    <!-- MAIN - MAP -->
    <main>
      <div class="dashboard-map" id="map">
        <l-map
          style="height: 100%; width: 100%"
          :zoom="zoom"
          :center="center"
          :bounds="bounds"
          :max-bounds="maxBounds"
        >
          <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
          
         <l-marker v-for="marker in Markers" :key="marker.id"
         :lat-lng="[marker.latitude, marker.longitude]">
          <l-popup>
            <h3>{{ marker.id }}</h3>
            <p>{{ marker.latitude }}</p>
             <p>{{ marker.longitude }}</p>
              <p>{{ marker.soundtype }}</p>
               <p>{{ marker.probability }}</p>
                <p>{{ marker.time }}</p>
          </l-popup>
      </l-marker>

      </l-map>
      </div>
      <!-- MAIN - DATA -->
      <div class="dashboard-geluidendata">
        <h2 style="color: black">Livedata</h2>
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
    </main>
    <!-- TOP -->
    <div class="top">
      <button id="menu-btn" @click="Sidebaropen()">
        <span class="material-icons-sharp">menu</span>
      </button>
    </div>
  </div>
  <div v-else style="color: black; text-align: center;">
    <h1>Error</h1>
    <h2>404 Page not found</h2>
  </div>
</template>

<script>
import AppHeader1 from "../components/header1";
import AppFooter from "../components/footer";
import { latLngBounds, latLng } from "leaflet";
import { LMap, LTileLayer, LMarker, LCircle, LPopup } from "vue2-leaflet";
import html2canvas from "html2canvas";
import axios from "axios";
import router from "../router";
import markerIconPng from "leaflet/dist/images/marker-icon.png"


export default {
  name: "Dashboard",
  components: {
    AppHeader1,
    AppFooter,
    LMap,
    LTileLayer,
    LMarker,
    LCircle,
    LPopup
  },
  props: ["LoggedIn", "superUser"],
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
      Markers: {id: 13, latitude: "-1.5911952104643539", longitude: "23.40987496105848", soundtype: "gunshot"},
    };
  },
  methods: {
    Account: function(){
      router.push({name: "newUser", params: {LoggedIn: this.LoggedIn, superUser: this.superUser}}); 
    },
    Logout(){
      this.$cookie.delete('token');
      this.$cookie.delete('superUser');
      router.push({name: "Log in"});
    },
    isLoggedIn(){
      return this.LoggedIn;
    },
    Sidebaropen(){
        var sideMenu = document.getElementById(menu-btn);
        sideMenu.style.display = "block";	
    },
    Sidebarclose(){
        var sideMenu = document.getElementById(closee-btn);
        sideMenu.style.display = "none";
    },
    GetSounds() {
      axios
        .get("api/auth/mqttdata")
        .then((response) => {
          this.sounds = response.data;
          this.Markers = response.data;
          console.log(this.Markers)
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

<style>
/* STYLING DATA */
main {
  width: 100%;
}
table {
  width: 80%;
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
  text-align: center;
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
  top: 6%;
  flex: 0 0 auto;
  width: 100%;
  height: 517px;
  display: flex;
  position: relative;
  align-items: flex-start;
  flex-direction: column;
}
/* STYLING DATA */
.dashboard-geluidendata {
  top: 62%;
  width: 100%;
  display: flex;
  height: 40%;
  position: absolute;
  overflow-x: hidden;
  overflow-y: auto;
  text-align: justify;
  flex-direction: column;
}
/* custom scrollbar */
::-webkit-scrollbar {
  width: 20px;
}

::-webkit-scrollbar-track {
  background-color: transparent;
}

::-webkit-scrollbar-thumb {
  background-color: #d6dee1;
  border-radius: 20px;
  border: 6px solid transparent;
  background-clip: content-box;
}

::-webkit-scrollbar-thumb:hover {
  background-color: #a8bbbf;
}
/* STYLING SIDEBAR */
a {
  color: var(--color-dark);
}
img {
  display: block;
  width: 100%;
}
h1 {
  font-weight: 800;
  font-size: 1.8rem;
}
h2 {
  font-size: 1.4rem;
}
h3 {
  font-size: 0.87rem;
}
h4 {
  font-size: 0.8rem;
}
h5 {
  font-size: 0.77rem;
}
small {
  font-size: 0.75rem;
}
.container {
  display: grid;
  width: 98%;
  margin: 0 auto;
  gap: 1.8rem;
  grid-template-columns: 14rem 82% auto;
}
aside {
  height: 100vh;
  background: var(--color-light);
}
aside .top {
  background: white;
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-top: 1.4rem;
}
aside .logo {
  display: flex;
  gap: 0.8rem;
}
aside .logo img {
  width: 2.5rem;
  height: 2.5rem;
}
aside .close {
  display: none;
}
aside .sidebar {
  background: white;
  display: flex;
  flex-direction: column;
  position: relative;
  height: 86vh;
  top: 3rem;
}
aside h3 {
  font-weight: 600;
}
aside .sidebar a {
  display: flex;
  color: var(--color-dark);
  margin-left: 2rem;
  gap: 1rem;
  align-items: center;
  position: relative;
  height: 3.7rem;
  transition: all 300ms ease;
  cursor: pointer;
}
aside .sidebar a span {
  font-size: 1.6rem;
  transition: all 300ms ease;
}
aside .sidebar a:last-child {
  position: absolute;
  bottom: 2rem;
  width: 100%;
}
aside .sidebar a.active {
  background: var(--color-light);
  color: var(--color-primary);
  margin-left: 0;
}
aside .sidebar a.active:before {
  content: "";
  width: 6px;
  height: 100%;
  background: var(--color-primary);
}
aside .side a.active span {
  color: var(--color-primary);
  margin-left: calc(1rem - 3px);
}
aside .sidebar a:hover {
  color: var(--color-primary);
}
aside .sidebar a:hover span {
  margin-left: 1rem;
}
/* TOP */
.top {
  display: none;
}

@media screen and (max-width: 820px) {
  .container {
    width: 94%;
    grid-template-columns: 10rem 88% auto;
    margin-left: 1%;
  }
  aside .logo h2 {
    display: none;
  }
  aside .sidebar h3 {
    display: none;
  }
  aside .sidebar h3 {
    width: 5.6rem;
  }
  aside .sidebar h3 {
    position: relative;
    margin-top: 1.8rem;
  }
  table {
    width: 75%;
  }
  .dashboard-map {
    width: 95%;
  }
}
@media screen and (max-width: 768px) {
  .container {
    width: 98%;
    grid-template-columns: 95% auto;
    margin: 0;
    margin-left: 5px;
  }
  aside {
    position: fixed;
    left: 0;
    background: white;
    width: 18rem;
    z-index: 3;
    box-shadow: 1rem 3rem 4rem var(--color-light);
    height: 100vh;
    padding-right: 0.2rem;
    display: none;
  }
  aside .logo {
    margin-left: 1rem;
  }
  aside .logo h2 {
    display: inline;
  }
  aside .sidebar h3 {
    display: inline;
  }
  aside .sidebar a {
    width: 100%;
    height: 3.4rem;
  }
  aside .close {
    display: inline-block;
    cursor: pointer;
  }
  .top {
    display: flex;
  }
  .top button {
    background: transparent;
  }
  table {
    width: 40% !important;
  }
  .dashboard-map {
    width: 95%;
  }
  th,
  td {
    padding: 3px;
    text-align: center;
  }
  .dashboard-geluidendata {
    top: 63%;
  }
}
</style>
