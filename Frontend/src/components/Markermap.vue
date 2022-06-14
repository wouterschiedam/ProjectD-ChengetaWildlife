<template>
     <div class="dashboard-map" id="map" style="z-index:0;"></div>
</template>

<script>
import { latLngBounds } from "leaflet";
import { LMap, LTileLayer, LMarker, LPopup, LFeatureGroup } from "vue2-leaflet";
import "leaflet.heat";
import axios from "axios";
    export default {
        components: {
            LMap,
            LTileLayer,
            LMarker,
            LPopup,
            LFeatureGroup
        },
        data() {
            return {
                LoggedIn: null,
                sounds: [],
                point: null,
                timer: "",
                zoom: 13,
                center: L.latLng(47.41322, -1.219482),
                url: 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
                attribution:
                    '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors',
                marker: [],
            };
        },
        methods: {
            GetSounds() {
                axios.get("api/auth/mqttdata", {
                        params: {
                            limit: 15,
                        },
                    })
                    .then((response) => {
                        this.sounds = response.data;
                        this.Markers = response.data;
                        this.Markers.forEach((element) => {
                            this.marker.push([element.latitude, element.longitude, element.probability]);
                        });
                        this.createMap()
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    });
            },
            createMap() {
                var map = L.map("map").setView([47.41322, -1.219482], 13);
                map.options.minZoom = 6;
                map.options.maxZoom = 50;
                L.tileLayer(this.url, {
                    attribution: this.attribution,
                }).addTo(map);
                map.attributionControl.setPrefix("");
                this.AddMarkers(map);
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


            },
            AddMarkers(map) {
                var MyMarkers = L.featureGroup();
                for (var i = 0; i < 13; i++) {
                    var date = new Date(this.Markers[i].time * 1000)
                        .toLocaleTimeString("en-NL")
                        .toString();
                    if (
                        this.Markers[i].probability <= 20 &&
                        this.Markers[i].probability >= 0
                    ) {
                        var zerotwenty = L.icon({
                            iconUrl: require("../markers/marker-svg.png"),
                            iconSize: [25, 45],
                        });
                        var marker = new L.marker(
                            [this.marker[i][0], this.marker[i][1]],
                            { icon: zerotwenty }
                        ).bindPopup(
                            "Time: " +
                                date +
                                "\n, probability: " +
                                this.Markers[i].probability.toString() +
                                "\n, Soundtype: " +
                                this.Markers[i].soundtype.toString()
                        );
                    }
                    if (
                        this.Markers[i].probability <= 40 &&
                        this.Markers[i].probability > 20
                    ) {
                        var twentyfourty = L.icon({
                            iconUrl: require("../markers/twentyfourty.png"),
                            iconSize: [25, 45],
                        });
                        var marker = new L.marker(
                            [this.marker[i][0], this.marker[i][1]],
                            { icon: twentyfourty }
                        ).bindPopup(
                            "Time: " +
                                date +
                                "\n, probability: " +
                                this.Markers[i].probability.toString() +
                                "\n, Soundtype: " +
                                this.Markers[i].soundtype.toString()
                        );
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
                        var marker = new L.marker(
                            [this.marker[i][0], this.marker[i][1]],
                            { icon: fourtysixty }
                        ).bindPopup(
                            "Time: " +
                                date +
                                "\n, probability: " +
                                this.Markers[i].probability.toString() +
                                "\n, Soundtype: " +
                                this.Markers[i].soundtype.toString()
                        );
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
                        var marker = new L.marker(
                            [this.marker[i][0], this.marker[i][1]],
                            { icon: sixtyeighty }
                        ).bindPopup(
                            "Time: " +
                                date +
                                "\n, probability: " +
                                this.Markers[i].probability.toString() +
                                "\n, Soundtype: " +
                                this.Markers[i].soundtype.toString()
                        );
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
                        var marker = new L.marker(
                            [this.marker[i][0], this.marker[i][1]],
                            { icon: eightyplus }
                        ).bindPopup(
                            "Time: " +
                                date +
                                "\n, probability: " +
                                this.Markers[i].probability.toString() +
                                "\n, Soundtype: " +
                                this.Markers[i].soundtype.toString()
                        );
                        // add color to markers
                    }
                    MyMarkers.addLayer(marker);
                }
                MyMarkers.addTo(map);
                map.fitBounds(MyMarkers.getBounds());
                map.setMaxBounds(map.getBounds());
                
            },
        },
        created(){
            this.GetSounds();
        }
    }

</script>
