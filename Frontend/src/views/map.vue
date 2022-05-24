<template>
    <div class="map-container">
        <div class="map-image">
            <app-header></app-header>
            <img alt="image"
                 src="/playground_assets/gray-vector.svg"
                 class="map-image1" />
            <div class="map-bg"></div>
        </div>
        <div><button onclick=printMapHtml()>Print map</button></div>
        <div id="map" class="map-container1">
            <l-map style="height: 100%" :zoom="zoom" :center="center">
            <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
            <l-marker :lat-lng="markerLatLng"></l-marker>
            </l-map>
        </div>
        <button class="print-container" @click=fullScreenView()>Full Screen</button>
        <br>
        <button @click=printMapHtml()>Print map</button>
        <app-footer></app-footer>
    </div>
</template>

<script>
    import AppHeader from '../components/header'
    import AppFooter from '../components/footer'
    import { LMap, LTileLayer, LMarker } from 'vue2-leaflet';
    import html2canvas from 'html2canvas';

    export default {
        name: 'Map',
        components: {
            AppHeader,
            AppFooter,
            LMap,
            LTileLayer,
            LMarker
        },
        data() {
            return {
                url: 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
                attribution:
                    '&copy; <a target="_blank" href="http://osm.org/copyright%22%3EOpenStreetMap</a> contributors',
                zoom: 15,
                center: [51.505, -0.159],
                markerLatLng: [51.504, -0.159]
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
                var legend = L.control({ position: "bottomleft" });

                legend.onAdd = function (map) {
                    var div = L.DomUtil.create("div", "legend");
                    div.innerHTML += "<h4>Legend</h4>";
                    div.innerHTML += '<i style="background: #d90000"></i><span>Gunshot</span><br>';
                    div.innerHTML += '<i style="background: #696e6c"></i><span>Vehicle</span><br>';
                    div.innerHTML += '<i style="background: #20a120"></i><span>Animal</span><br>';
                    div.innerHTML += '<i style="background: #000000"></i><span>Unknown</span><br>';
                    // div.innerHTML += '<i class="icon" style="background-image: url(https://d30y9cdsu7xlg0.cloudfront.net/png/194515-200.png);background-repeat: no-repeat;"></i><span>Grænse</span><br>';

                    return div;
                };
                legend.addTo(l-map);
        }
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
