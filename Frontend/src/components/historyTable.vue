<template>
    <div>
        <h2 style=" color: black">Laatste update: {{ this.counter }}s</h2>
        <div class="dashboard-geluidendata">
            <table class="flat-table flat-table-1">
                <thead>
                    <tr>
                        <th>Time</th>
                        <th>ID</th>
                        <th>Latitude;Longitude</th>
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
                        <td>{{ Number(sound.latitude).toFixed(7) }};{{ Number(sound.longitude).toFixed(7) }}</td>
                        <td class="badgeColumn">
                            <div class="badge" v-bind:style="{background: sound.soundtype == 'gunshot' ? 'red' :
                                 sound.soundtype == 'vehicle' ? 'orange' :
                                 sound.soundtype == 'animal' ? 'green' :
                                 sound.soundtype == 'unknown' ? 'black' :
                                 'none'}">
                                <p> {{ sound.soundtype }} </p>
                            </div>
                        </td>
                        <td>
                            <Progress class="progress" :transitionDuration="1" strokeColor="white" v-bind:value="sound.probability">
                                {{ sound.probability }}%
                            </Progress>
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
        name: 'historyTable',
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
                        limit: 150,
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
                if (this.$router.currentRoute.path != '/historyData')
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
    .badgeColumn {
        align-content: center;
    }
    .badge {
        height: calc(3.5vw + 5px);
        line-height: calc(3.5vw + 5px);
        border-radius: 150px / 160px;
        font-size: calc(1.2vw + 5px);
    }
    .progress{
        line-height: 0vw;
    }
    .dashboard-geluidendata {
        width: 80%;
        height: 95%;
        position: absolute;
        overflow-x: auto;
        overflow-y: auto;
    }

    .flat-table {
        width: 100%;
        border-collapse: collapse;
        font-family: Arial;
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
        -webkit-font-smoothing: antialiased;
        padding: calc(0.5vw + 5px);
        color: white;
        text-shadow: 0 0 1px rgba(0, 0, 0, 0.1);
        font-size: calc(1.1vw + 5px);
    }

    .flat-table td {
        text-align: center;
        padding: calc(0.5vw + 5px);
        text-shadow: 0 0 1px rgba(255, 255, 255, 0.1);
        font-size: calc(1vw + 5px);
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
        max-width: 55vw;
        max-height: 10vw;
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
    @media screen and (max-width: 768px) {
        .dashboard-geluidendata {
            width: 100%;
            height: 95%;
            position: absolute;
            overflow-x: auto;
            overflow-y: auto;
        }
    }
</style>
