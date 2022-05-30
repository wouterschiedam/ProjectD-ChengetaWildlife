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
        <div class="dashboard-geluidendata">
            <h2 style="color: black">Historische data</h2>
            <table class="flat-table flat-table-1">
                <tr>
                    <th>Date</th>
                    <th>Time</th>
                    <th>ID</th>
                    <th>Latitude</th>
                    <th>Longitude</th>
                    <th>Soundtype</th>
                    <th>Probability</th>
                    <th>Sound</th>
                </tr>
                <tbody v-for="sound in sounds" :key="sound.id">
                    <tr>
                        <td>{{ new Date(sound.time * 1000).toISOString().slice(0, 10) }}</td>
                        <td>{{ new Date(sound.time * 1000).toISOString().slice(-13, -5) }}</td>
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
                            <Progress :transitionDuration="4000" strokeColor="white"
                                      v-bind:value="sound.probability" />
                        </td>
                        <td>
                            <audio controls>
                                <source :options="options" v-bind:src="sound.sound" />
                            </audio>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

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
                time: 0
            }
        },
        methods: {
            GetSounds() {
                axios
                    .get("api/auth/mqttdata", {
                        params: {
                            limit: 0
                        }
                    })
                    .then((response) => {
                        this.sounds = response.data;
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    });
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