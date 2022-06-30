<template>
    <div class="dashboard-heatmap" id="heatmap" style="z-index:0"></div>
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
                Loggedin: null,
                sounds: [],
                point: null,
                timer: "",
                center: L.latLng(-1.41322, 21.219482),
                url: "http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                attribution:
                    '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors',
                marker: [],
            }
        },
        methods: {
            GetSounds() {
                axios.get("api/auth/mqttdata", {
                        params: {
                            limit: 500,
                        },
                    })
                    .then((response) => {
                        this.sounds = response.data;
                        this.Markers = response.data;
                        this.Markers.forEach((element) => {
                            this.marker.push([element.latitude, element.longitude]);
                        });
                        this.createHeatMap();
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    });
            },
            createHeatMap() {
                var heatmap = L.map("heatmap").setView(
                    this.center,
                    8
                );
                heatmap.options.minZoom = 6;
                heatmap.options.maxZoom = 50;
                L.tileLayer(this.url, {
                    attribution: this.attribution,
                }).addTo(heatmap);
                heatmap.attributionControl.setPrefix("");
                var legend = L.control({ position: "topright" });
                legend.onAdd = function (heatmap) {
                    var div = L.DomUtil.create("div", "info legend"),
                        grades = [20, 40, 60, 80],
                        color = [
                            "#570000",
                            "#ff0000",
                            "#ffc800",
                            "#ffff00",

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
                legend.addTo(heatmap);
                var newAddressPoints = this.marker.map(function (p) {
                    return [p[0], p[1]];
                });
                var heatmapLayer = L.heatLayer(newAddressPoints, {
                    radius: 25,
                    maxZoom: 12,
                    minOpacity: 0.5,
                    max: 1,
                    blur: 15,
                    gradient: {
                        0: "#000000",
                        0.2: "#570000",
                        0.4: "#ff0000",
                        0.6: "#ffc800",
                        0.8: "#ffff00",
                    },
                });

                heatmapLayer.addTo(heatmap);
                // var MyMarkers = L.featureGroup();
                // for (var i = 0; i < this.marker.length; i++) {
                //     var marker = L.marker(this.marker[i][0], this.marker[i][1]);
                //     MyMarkers.addLayer(marker);
                // }
                setTimeout(function () {
                    heatmap.addLayer(heatmapLayer);
                }, 500);
            },
        },
        created() {
            this.GetSounds();
        },
    }

</script>
