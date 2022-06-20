<template>
    <div class="dashboard-map" id="map" style="z-index: 0"></div>
</template>

<script>
import { latLngBounds } from "leaflet";
import { LMap, LTileLayer, LMarker, LPopup, LFeatureGroup } from "vue2-leaflet";
import "leaflet.heat";
import axios from "axios";
import store from "../store";
import Vuex from "vuex";
var map;
var MyMarkers;
var newMyMarkers;
export default {
    components: {
        LMap,
        LTileLayer,
        LMarker,
        LPopup,
        LFeatureGroup,
    },
    data() {
        return {
            LoggedIn: null,
            counter: 0,
            sounds: store.state.sounds,
            markers: [],
            sounds: [],
            point: null,
            timer: "",
            zoom: 13,
            center: L.latLng(47.41322, -1.219482),
            url: "http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
            attribution:
                '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors',
            marker: [],
            watcher: 0
        };
    },
    methods: {
        GetSounds() {
            axios
                .get("api/auth/mqttdata", {
                    params: {
                        limit: 15,
                    },
                })
                .then((response) => {
                    this.Markers = response.data;
                    this.Markers.forEach((element) => {
                        this.marker.push([
                            element.latitude,
                            element.longitude,
                            element.probability,
                        ]);
                    });
                    this.createMap();
                   

                })
                .catch(function (error) {
                    console.log(error);
                    alert(error);
                });
        },
        createMap() {
            map = L.map("map").setView([47.41322, -1.219482], 13);
            map.options.minZoom = 6;
            map.options.maxZoom = 50;
            L.tileLayer(this.url, {
                attribution: this.attribution,
            }).addTo(map);
            map.attributionControl.setPrefix("");
            
            //this.AddMarkers(map);
            var legend = L.control({ position: "topright" });
            legend.onAdd = function (map) {
                var div = L.DomUtil.create("div", "info legend"),
                    grades = [0, 20, 40, 60, 80],
                    color = [
                        "#ccccff",
                        "#b2b2ff",
                        "#9999ff",
                        "#7f7fff",
                        "#6666ff",
                    ];
                // Loop for color shades
                for (var i = 0; i < grades.length; i++) {
                    div.innerHTML +=
                        '<span style="background: ' + color[i] + '"></span> ';
                }
                // a line break
                div.innerHTML += "<br>";
                // second loop for text
                for (var i = 0; i < grades.length; i++) {
                    div.innerHTML +=
                        "<label>" +
                        grades[i] +
                        (grades[i + 1] ? "&ndash;" + grades[i + 1] : "+") +
                        "</label>";
                }
                return div;
            };
            legend.addTo(map);
            this.AddMarkers(map);
        },
        AddMarkers(map) {
            MyMarkers = new L.featureGroup()
            for (var i = 0; i < 15; i++) {
                var date = new Date(this.Markers[i].time * 1000)
                    .toLocaleTimeString("en-NL")
                    .toString();
                var template =
                "<div>Time: "+date+"</div>" +
                "<div>Probability: "+this.Markers[i].probability.toString()+"</div>" +
                "<div>Soundtype: "+this.Markers[i].soundtype.toString()+"</div>";
                if (
                    this.Markers[i].probability <= 20 &&
                    this.Markers[i].probability >= 0
                ) {
                    var zerotwenty = L.icon({
                        iconUrl: require("../markers/marker-svg.png"),
                        iconSize: [25, 45],
                    });
                    this.markers.push(new L.marker(
                        [this.marker[i][0], this.marker[i][1]],
                        { icon: zerotwenty }
                    ));
                }
                if (
                    this.Markers[i].probability <= 40 &&
                    this.Markers[i].probability > 20
                ) {
                    var twentyfourty = L.icon({
                        iconUrl: require("../markers/twentyfourty.png"),
                        iconSize: [25, 45],
                    });
                    this.markers.push(new L.marker(
                        [this.marker[i][0], this.marker[i][1]],
                        { icon: twentyfourty }
                    ));
                    // add color to markers
                }
                if (
                    this.Markers[i].probability <= 60 &&
                    this.Markers[i].probability > 40
                ) {
                    var fourtysixty = L.icon({
                        iconUrl: require("../markers/fourtysixty.png"),
                        iconSize: [25, 45],
                    });
                    this.markers.push(new L.marker(
                        [this.marker[i][0], this.marker[i][1]],
                        { icon: fourtysixty }
                    ));
                    // add color to markers
                }
                if (
                    this.Markers[i].probability <= 80 &&
                    this.Markers[i].probability > 60
                ) {
                    var sixtyeighty = L.icon({
                        iconUrl: require("../markers/sixtyeigthy.png"),
                        iconSize: [25, 45],
                    });
                    this.markers.push(new L.marker(
                        [this.marker[i][0], this.marker[i][1]],
                        { icon: sixtyeighty }
                    ));
                    // add color to markers
                }
                if (
                    this.Markers[i].probability <= 100 &&
                    this.Markers[i].probability > 80
                ) {
                    var eightyplus = L.icon({
                        iconUrl: require("../markers/eightyplus.png"),
                        iconSize: [25, 45],
                    });
                    this.markers.push(new L.marker(
                        [this.marker[i][0], this.marker[i][1]],
                        { icon: eightyplus }
                    ));
                    // add color to markers
                }
                MyMarkers.addLayer(this.markers[i].bindPopup(template));
                
            }
            
            MyMarkers.addTo(map);
            map.fitBounds(MyMarkers.getBounds());
            map.setMaxBounds(map.getBounds());   
        },
        removeLayer(MyMarkers){
            for(var i=0; i<15; i++){
                MyMarkers.removeLayer(this.markers[i])
            } 
        },
        updateMarkers(map) {  
            MyMarkers = new  L.featureGroup()
            this.markers = []

            for (var i = 0; i < 15; i++) {
               var template =
                "<div>Time: "+date+"</div>" +
                "<div>Probability: "+this.sounds[i].probability.toString()+"</div>" +
                "<div>Soundtype: "+this.sounds[i].soundtype.toString()+"</div>";
                var date = new Date(this.sounds[i].time * 1000)
                    .toLocaleTimeString("en-NL")
                    .toString();
                if (
                    this.sounds[i].probability <= 20 &&
                    this.sounds[i].probability >= 0
                ) {
                    var zerotwenty = L.icon({
                        iconUrl: require("../markers/marker-svg.png"),
                        iconSize: [25, 45],
                    });
                    this.markers.push(new L.marker(
                        [this.sounds[i].latitude, this.sounds[i].longitude],
                        { icon: zerotwenty }
                    ));
                }
                if (
                    this.sounds[i].probability <= 40 &&
                    this.sounds[i].probability > 20
                ) {
                    var twentyfourty = L.icon({
                        iconUrl: require("../markers/twentyfourty.png"),
                        iconSize: [25, 45],
                    });
                    this.markers.push(new L.marker(
                        [this.sounds[i].latitude, this.sounds[i].longitude],
                        { icon: twentyfourty }
                    ));
                    // add color to markers
                }
                if (
                    this.sounds[i].probability <= 60 &&
                    this.sounds[i].probability > 40
                ) {
                    var fourtysixty = L.icon({
                        iconUrl: require("../markers/fourtysixty.png"),
                        iconSize: [25, 45],
                    });
                    this.markers.push(new L.marker(
                        [this.sounds[i].latitude, this.sounds[i].longitude],
                        { icon: fourtysixty }
                    ));
                    // add color to markers
                }
                if (
                    this.sounds[i].probability <= 80 &&
                    this.sounds[i].probability > 60
                ) {
                    var sixtyeighty = L.icon({
                        iconUrl: require("../markers/sixtyeigthy.png"),
                        iconSize: [25, 45],
                    });
                    this.markers.push(new L.marker(
                        [this.sounds[i].latitude, this.sounds[i].longitude],
                        { icon: sixtyeighty }
                    ));
                    // add color to markers
                }
                if (
                    this.sounds[i].probability <= 100 &&
                    this.sounds[i].probability > 80
                ) {
                    var eightyplus = L.icon({
                        iconUrl: require("../markers/eightyplus.png"),
                        iconSize: [25, 45],
                    });
                    this.markers.push(new L.marker(
                        [this.sounds[i].latitude, this.sounds[i].longitude],
                        { icon: eightyplus }
                    ));
                    // add color to markers
                }
                MyMarkers.addLayer(this.markers[i].bindPopup(template));
          
            }
            MyMarkers.addTo(map);
            map.fitBounds(MyMarkers.getBounds());
            map.setMaxBounds(map.getBounds());

        },
    },
    mounted() {
        this.GetSounds();
    },
    watch:{
        '$store.state.sounds'(){
                this.sounds = store.state.sounds;
                this.removeLayer(MyMarkers)
                this.updateMarkers(map)
            },
           
            
        }
    }

</script>
