<template>
    <div class="dashboard-map" id="map" style="z-index: 0"></div>
</template>

<script>
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
                var legend2 = L.control({ position: "topright" });
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
                legend2.onAdd = function (map) {
                    var div = L.DomUtil.create("div", "info legend"),
                        grades = ["gunshot", "vehicle", "animal", "unknown"],
                        color = [
                            "#FF0000",
                            "#FFA500",
                            "#00993C",
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
                            "</label>";
                    }
                    return div;
                };
                legend.addTo(map);
                legend2.addTo(map);
                this.AddMarkers(map);
            },
            myFunction(value) {

            },
            AddMarkers(map) {
                MyMarkers = new L.featureGroup()
                for (var i = 0; i < 15; i++) {
                    var date = new Date(this.Markers[i].time * 1000)
                        .toLocaleTimeString("en-NL")
                        .toString();
                    var template =
                        '<div class="select">Status: <select v-model="value" @change="myFunction(value)"><option value="Open">open</option><option value="Closed">closed</option><option value="In progress">in progress</option> </select> </div >' +
                        "<div>Time: " + date + "</div>" +
                        "<div>Probability: " + this.Markers[i].probability.toString() + "</div>" +
                        "<div>Soundtype: " + this.Markers[i].soundtype.toString() + "</div>" +
                        "<audio controls><source src='" + this.Markers[i].sound + "'</audio>";
                    if (
                        this.Markers[i].probability <= 20 &&
                        this.Markers[i].probability >= 0
                    ) {
                        if (this.Markers[i].soundtype == "vehicle") {
                            var zerotwenty = L.icon({
                                iconUrl: require("../markers/vehicle_zerotwenty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.Markers[i].soundtype == "animal") {
                            var zerotwenty = L.icon({
                                iconUrl: require("../markers/animal_zerotwenty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.Markers[i].soundtype == "gunshot") {
                            var zerotwenty = L.icon({
                                iconUrl: require("../markers/gunshot_zerotwenty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else {
                            var zerotwenty = L.icon({
                                iconUrl: require("../markers/marker-svg.png"),
                                iconSize: [25, 45],
                            });
                        }
                        this.markers.push(new L.marker(
                            [this.marker[i][0], this.marker[i][1]],
                            { icon: zerotwenty }
                        ));
                    }
                    if (
                        this.Markers[i].probability <= 40 &&
                        this.Markers[i].probability > 20
                    ) {
                        if (this.Markers[i].soundtype == "vehicle") {
                            var twentyfourty = L.icon({
                                iconUrl: require("../markers/vehicle_twentyfourty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.Markers[i].soundtype == "animal") {
                            var twentyfourty = L.icon({
                                iconUrl: require("../markers/animal_twentyfourty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.Markers[i].soundtype == "gunshot") {
                            var twentyfourty = L.icon({
                                iconUrl: require("../markers/gunshot_twentyfourty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else {
                            var twentyfourty = L.icon({
                                iconUrl: require("../markers/twentyfourty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        this.markers.push(new L.marker(
                            [this.marker[i][0], this.marker[i][1]],
                            { icon: twentyfourty }
                        ));
                    }
                    if (
                        this.Markers[i].probability <= 60 &&
                        this.Markers[i].probability > 40
                    ) {
                        if (this.Markers[i].soundtype == "vehicle") {
                            var fourtysixty = L.icon({
                                iconUrl: require("../markers/vehicle_fourtysixty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.Markers[i].soundtype == "animal") {
                            var fourtysixty = L.icon({
                                iconUrl: require("../markers/animal_fourtysixty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.Markers[i].soundtype == "gunshot") {
                            var fourtysixty = L.icon({
                                iconUrl: require("../markers/gunshot_fourtysixty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else {
                            var fourtysixty = L.icon({
                                iconUrl: require("../markers/fourtysixty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        this.markers.push(new L.marker(
                            [this.marker[i][0], this.marker[i][1]],
                            { icon: fourtysixty }
                        ));
                    }
                    if (
                        this.Markers[i].probability <= 80 &&
                        this.Markers[i].probability > 60
                    ) {
                        if (this.Markers[i].soundtype == "vehicle") {
                            var sixtyeighty = L.icon({
                                iconUrl: require("../markers/vehicle_sixtyeighty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.Markers[i].soundtype == "animal") {
                            var sixtyeighty = L.icon({
                                iconUrl: require("../markers/animal_sixtyeighty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.Markers[i].soundtype == "gunshot") {
                            var sixtyeighty = L.icon({
                                iconUrl: require("../markers/gunshot_sixtyeighty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else {
                            var sixtyeighty = L.icon({
                                iconUrl: require("../markers/sixtyeighty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        this.markers.push(new L.marker(
                            [this.marker[i][0], this.marker[i][1]],
                            { icon: sixtyeighty }
                        ));
                    }
                    if (
                        this.Markers[i].probability <= 100 &&
                        this.Markers[i].probability > 80
                    ) {
                        if (this.Markers[i].soundtype == "vehicle") {
                            var eightyplus = L.icon({
                                iconUrl: require("../markers/vehicle_eightyplus.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.Markers[i].soundtype == "animal") {
                            var eightyplus = L.icon({
                                iconUrl: require("../markers/animal_eightyplus.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.Markers[i].soundtype == "gunshot") {
                            var eightyplus = L.icon({
                                iconUrl: require("../markers/gunshot_eightyplus.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else {
                            var eightyplus = L.icon({
                                iconUrl: require("../markers/eightyplus.png"),
                                iconSize: [25, 45],
                            });
                        }
                        this.markers.push(new L.marker(
                            [this.marker[i][0], this.marker[i][1]],
                            { icon: eightyplus }
                        ));
                    }
                    /*if (
                        this.Markers[i].soundtype == "vehicle"
                    ) {

                    }*/
                    MyMarkers.addLayer(this.markers[i].bindPopup(template));

                }

                MyMarkers.addTo(map);
                map.fitBounds(MyMarkers.getBounds());
                map.setMaxBounds(map.getBounds());
            },
            removeLayer(MyMarkers) {
                for (var i = 0; i < 15; i++) {
                    MyMarkers.removeLayer(this.markers[i])
                }
            },
            updateMarkers(map) {
                MyMarkers = new L.featureGroup()
                this.markers = []

                for (var i = 0; i < 15; i++) {
                    var template =
                        '<div class="select">Status: <select v-model:where="filter" @change="GetSounds"><option value="">open</option><option value="gunshot">closed</option><option value="probability">in progress</option> </select> </div >' +
                        "<div>Time: " + date + "</div>" +
                        "<div>Probability: " + this.sounds[i].probability.toString() + "</div>" +
                        "<div>Soundtype: " + this.sounds[i].soundtype.toString() + "</div>" +
                        "<audio controls><source src='" + this.sounds[i].sound + "'</audio>";
                    var date = new Date(this.sounds[i].time * 1000)
                        .toLocaleTimeString("en-NL")
                        .toString();
                    if (
                        this.sounds[i].probability <= 20 &&
                        this.sounds[i].probability >= 0
                    ) {
                        if (this.sounds[i].soundtype == "vehicle") {
                            var zerotwenty = L.icon({
                                iconUrl: require("../markers/vehicle_zerotwenty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.sounds[i].soundtype == "animal") {
                            var zerotwenty = L.icon({
                                iconUrl: require("../markers/animal_zerotwenty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.sounds[i].soundtype == "gunshot") {
                            var zerotwenty = L.icon({
                                iconUrl: require("../markers/gunshot_zerotwenty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else {
                            var zerotwenty = L.icon({
                                iconUrl: require("../markers/marker-svg.png"),
                                iconSize: [25, 45],
                            });
                        }
                        this.markers.push(new L.marker(
                            [this.sounds[i].latitude, this.sounds[i].longitude],
                            { icon: zerotwenty }
                        ));
                    }
                    if (
                        this.sounds[i].probability <= 40 &&
                        this.sounds[i].probability > 20
                    ) {
                        if (this.sounds[i].soundtype == "vehicle") {
                            var twentyfourty = L.icon({
                                iconUrl: require("../markers/vehicle_twentyfourty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.sounds[i].soundtype == "animal") {
                            var twentyfourty = L.icon({
                                iconUrl: require("../markers/animal_twentyfourty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.sounds[i].soundtype == "gunshot") {
                            var twentyfourty = L.icon({
                                iconUrl: require("../markers/gunshot_twentyfourty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else {
                            var twentyfourty = L.icon({
                                iconUrl: require("../markers/twentyfourty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        this.markers.push(new L.marker(
                            [this.sounds[i].latitude, this.sounds[i].longitude],
                            { icon: twentyfourty }
                        ));
                        //add color to markers
                    }
                    if (
                        this.sounds[i].probability <= 60 &&
                        this.sounds[i].probability > 40
                    ) {
                        if (this.sounds[i].soundtype == "vehicle") {
                            var fourtysixty = L.icon({
                                iconUrl: require("../markers/vehicle_fourtysixty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.sounds[i].soundtype == "animal") {
                            var fourtysixty = L.icon({
                                iconUrl: require("../markers/animal_fourtysixty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.sounds[i].soundtype == "gunshot") {
                            var fourtysixty = L.icon({
                                iconUrl: require("../markers/gunshot_fourtysixty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else {
                            var fourtysixty = L.icon({
                                iconUrl: require("../markers/fourtysixty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        this.markers.push(new L.marker(
                            [this.sounds[i].latitude, this.sounds[i].longitude],
                            { icon: fourtysixty }
                        ));
                        //add color to markers
                    }
                    if (
                        this.sounds[i].probability <= 80 &&
                        this.sounds[i].probability > 60
                    ) {
                        if (this.sounds[i].soundtype == "vehicle") {
                            var sixtyeighty = L.icon({
                                iconUrl: require("../markers/vehicle_sixtyeighty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.sounds[i].soundtype == "animal") {
                            var sixtyeighty = L.icon({
                                iconUrl: require("../markers/animal_sixtyeighty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.sounds[i].soundtype == "gunshot") {
                            var sixtyeighty = L.icon({
                                iconUrl: require("../markers/gunshot_sixtyeighty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else {
                            var sixtyeighty = L.icon({
                                iconUrl: require("../markers/sixtyeighty.png"),
                                iconSize: [25, 45],
                            });
                        }
                        this.markers.push(new L.marker(
                            [this.sounds[i].latitude, this.sounds[i].longitude],
                            { icon: sixtyeighty }
                        ));
                        //add color to markers
                    }
                    if (
                        this.sounds[i].probability <= 100 &&
                        this.sounds[i].probability > 80
                    ) {
                        if (this.sounds[i].soundtype == "vehicle") {
                            var eightyplus = L.icon({
                                iconUrl: require("../markers/vehicle_eightyplus.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.sounds[i].soundtype == "animal") {
                            var eightyplus = L.icon({
                                iconUrl: require("../markers/animal_eightyplus.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else if (this.sounds[i].soundtype == "gunshot") {
                            var eightyplus = L.icon({
                                iconUrl: require("../markers/gunshot_eightyplus.png"),
                                iconSize: [25, 45],
                            });
                        }
                        else {
                            var eightyplus = L.icon({
                                iconUrl: require("../markers/eightyplus.png"),
                                iconSize: [25, 45],
                            });
                        }
                        this.markers.push(new L.marker(
                            [this.sounds[i].latitude, this.sounds[i].longitude],
                            { icon: eightyplus }
                        ));
                        //add color to markers
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
        watch: {
            '$store.state.sounds'() {
                this.sounds = store.state.sounds;
                this.removeLayer(MyMarkers)
                this.updateMarkers(map)
            };


        }
    }

</script>
