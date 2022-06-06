<template>
    <div>
        <h2 style=" color: black">Laatste update: {{ this.counter }}s</h2>
        <div class="dashboard-geluidendata">
            <table class="flat-table flat-table-1">
                <thead>
                    <tr>
                        <th>Time</th>
                        <th>ID</th>
                        <th>Latitude</th>
                        <th>Longitude</th>
                        <th>Soundtype</th>
                        <th>Probability</th>
                        <th>Sound</th>
                    </tr>
                </thead>
                <tbody v-for="sound in sounds" :key="sound.id">
                    <tr>
                        <td>
                            {{ new Date(sound.time * 1000).toLocaleDateString("en-NL") }}
                            <br />
                            {{ new Date(sound.time * 1000).toLocaleTimeString("en-NL") }}
                        </td>
                        <td>{{ sound.pid }}</td>
                        <td>{{ sound.latitude }}</td>
                        <td>{{ sound.longitude }}</td>
                        <td v-bind:class="
                  sound.soundtype == 'gunshot'
                    ? 'red'
                    : sound.soundtype == 'vehicle'
                    ? 'yellow'
                    : sound.soundtype == 'animal'
                    ? 'orange'
                    : sound.soundtype == 'unknown'
                    ? 'black'
                    : 'white'
                ">
                            {{ sound.soundtype }}
                        </td>
                        <td>
                            <Progress :transitionDuration="1"
                                      strokeColor="white"
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

<script>
    import axios from "axios";
    import Progress from "easy-circular-progress";

    export default {
    name: 'dashboardTable',
    components: {
        Progress
    },
    data() {
        return {
            sounds: [],
            timer: 0,
            counter: 0
        }
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
                    console.log("Updated table");
                })
                .catch(function (error) {
                    console.log(error);
                    alert(error);
                });
        },
        cancelAutoUpdate() {
            clearInterval(this.timer);
        }
    },
    mounted() {
        this.GetSounds();
        this.timer = setInterval(() => {
            if (this.$router.currentRoute.path != '/dashboard')
                clearInterval(this.timer);
                if (this.counter < 60) {
                    this.counter += 1;
                } else {
                    this.counter = 0;
                    this.GetSounds();
                }
            }, 1000);
    }
}
</script>

<style scoped>
    .dashboard-geluidendata {
        width: 85%;
        height: 49%;
        position: absolute;
        height: 49%;
        overflow-x: hidden;
        overflow-y: auto;
    }

    .red {
        color: red;
    }

    .white {
        color: white;
    }

    .yellow {
        color: yellow;
    }

    .black {
        color: black;
    }

    .orange {
        color: orange;
    }
    .flat-table {
        width: 100%;
        border-collapse: collapse;
        font-family: bold;
        color: #f7f7f7;
        border: none;
        border-radius: 3px;
        -webkit-border-radius: 3px;
        -moz-border-radius: 3px;
    }

    .flat-table th,
    .flat-table td {
        box-shadow: inset 0 -1px rgba(0, 0, 0, 0.25), inset 0 1px rgba(0, 0, 0, 0.25);
    }

    .flat-table th {
        text-align: center;
        font-weight: normal;
        -webkit-font-smoothing: antialiased;
        padding: 1em;
        color: white;
        text-shadow: 0 0 1px rgba(0, 0, 0, 0.1);
        font-size: 1.5em;
    }

    .flat-table td {
        padding: 0.7em 1em 0.7em 1.15em;
        text-shadow: 0 0 1px rgba(255, 255, 255, 0.1);
        font-size: 1.4em;
    }

    .flat-table tr {
        -webkit-transition: background 0.3s, box-shadow 0.3s;
        -moz-transition: background 0.3s, box-shadow 0.3s;
        transition: background 0.3s, box-shadow 0.3s;
    }

    .flat-table-1 tbody {
        background: #336ca6;
    }

    .flat-table-1 thead {
        background: #2a5784;
        position: sticky;
        z-index: 1;
        top: 0;
    }

    .flat-table-1 tbody tr:hover {
        background: #448dda;
        filter: drop-shadow(1px 2px 4px #333);
    }

    audio:hover {
        transform: scale(1.05);
        filter: drop-shadow(3px 5px 5px #333);
    }

    audio {
        filter: drop-shadow(2px 3px 3px #333);
    }

    ::-webkit-scrollbar {
        width: 30px;
        background-color: #18324b;
    }

    ::-webkit-scrollbar-track {
        background-color: transparent;
    }

    ::-webkit-scrollbar-thumb {
        background-color: #e8e8e8;
        border-radius: 20px;
        border: 6px solid transparent;
        background-clip: content-box;
    }

    ::-webkit-scrollbar-thumb:active {
        background-color: #b1b1b1;
    }
</style>
