<template>
    <div class="container" v-if="isLoggedIn()">
        <aside>
            <div class="top">
                <div class="logo">
                    <img src="../../public/playground_assets/217332412_177488101085809_6155924843160933349_n-1500h.jpg" />
                    <h2>Chengeta</h2>
                </div>
                <div class="close" id="closee-btn">
                    <span class="material-icons-sharp">close</span>
                </div>
            </div>
            <div class="sidebar">
                <a @click="dashboard()">
                    <span class="material-icons-sharp">grid_view</span>
                    <h3>Dashboard</h3>
                </a>
                <a @click="Account()">
                    <span class="material-icons-sharp">person_add</span>
                    <h3>Nieuw account</h3>
                </a>
                <a @click="Logout()">
                    <span class="material-icons-sharp">logout</span>
                    <h3>Uitloggen</h3>
                </a>
            </div>
        </aside>
        <div class="dashboard-geluidendata">
            <h2 style="color: black">Historische data</h2>
            <table class="flat-table flat-table-1">
                <tr>
                    <th>Time</th>
                    <th>ID</th>
                    <th>Latitude</th>
                    <th>Longitude</th>
                    <th>Soundtype</th>
                    <th>Probability</th>
                    <th>Sound</th>
                </tr>
                <tbody v-for="sound in sounds">
                    <tr>
                        <td>{{ new Date(sound.time * 1000).toLocaleDateString('en-NL') }} <br> {{ new Date(sound.time * 1000).toLocaleTimeString('en-NL') }}</td>
                        <td>{{ sound.id }}</td>
                        <td>{{ sound.latitude }}</td>
                        <td>{{ sound.longitude }}</td>
                        <td v-bind:class="sound.soundtype == 'gunshot' ? 'red' :
                              sound.soundtype == 'vehicle' ? 'yellow' :
                              sound.soundtype == 'animal' ? 'orange' :
                              sound.soundtype == 'unknown' ? 'black' : 'white'">
                              {{ sound.soundtype }}
                        </td>
                        <td>
                            <Progress :transitionDuration="1" strokeColor="white"
                                      v-bind:value="sound.probability" />
                        </td>
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

<script type="text/javascript" src="node_modules/vuejs/dist/vue.min.js"></script>
<script type="text/javascript" src="node_modules/vue-simple-search-dropdown/dist/vue-simple-search-dropdown.min.js"></script>
<script type="text/javascript">
    Vue.use(Dropdown);
</script>

<script>
    import axios from "axios";
    import Progress from "easy-circular-progress";

    export default {
        name: "HistoryData",
        components: {
            Progress
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
                timer: ""
            }
        },
        methods: {
            GetSounds() {
                axios
                    .get("api/auth/mqttdata", {
                        params: {
                            limit: 150
                        }
                    })
                    .then((response) => {
                        this.sounds = response.data;
                        console.log("updated");
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    });
            },
            cancelAutoUpdate() {
                clearInterval(this.timer);
            },
            dashboard() {
                this.$router.push("dashboard");
            },
            Logout() {
                this.$cookie.delete('token');
                this.$cookie.delete('superUser');
                this.$router.push("/");
            },
            async isLoggedIn() {
                return this.LoggedIn;
            }
        },
        mounted() {
            this.GetSounds();
            this.timer = setInterval(() => {
                this.GetSounds()
            }, 60000)
        },
        beforeDestroy() {
            this.cancelAutoUpdate();
        }
    }
</script>

<style scoped>
    .dashboard-geluidendata {
        width: 100%;
        margin-left: 13%;
        margin-top: 3%;
        position: absolute;
    }
</style>