<template>
    <div>
        <h2 style=" color: black">Laatste update: {{ this.counter }}s</h2>
        <label>Filter</label>
        <div class="select">
            <select v-model:where="filter" @change="GetSounds">
                <option value="">time</option>
                <option value="gunshot">gunshot</option>
                <option value="probability">probability</option>
            </select>
        </div>
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
                            <Progress class="progress" id="bigScreen" :radius="30" :transitionDuration="1" strokeColor="white" v-bind:value="sound.probability">
                                {{ sound.probability }}%
                            </Progress>
                            <Progress class="progress" id="smallScreen" :radius="20" :transitionDuration="1" strokeColor="white" v-bind:value="sound.probability">
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
    import store from "../store";
    import Vuex from "vuex";
    export default {
    name: 'dashboardTable',
    components: {
        Progress
    },
   
    data() {
        return {
            sounds: [],
            timer: 0,
            counter: 0,
            counterWeek: 0,
            filter: '',
            pid: [],
            pidPlaceHolder: ""
        }
    },
    methods: {
        GetSounds() {
            var whereFilter = this.filter == 'gunshot' ? "WHERE soundtype='gunshot'" : ""
            var orderFilter = this.filter == 'probability' ? "probability DESC, time" : "time"

            this.counter = 0;
            axios.get("api/auth/mqttdata", {
                params: {
                        order: orderFilter,
                        where: whereFilter
                    },
                })
                .then((response) => {
                    this.sounds = response.data;
                    this.$store.commit('Updatedata', this.sounds);
                })
                .catch(function (error) {
                    console.log(error);
                    alert(error);
                });
        },
        SetTopPid() {
            axios.get("api/auth/mqttdata/pid")
            .then((response) => {
                
                // this.pidPlaceHolder = response.data[0].pid;
                this.pid = response.data[0].pid;
                this.$store.commit('OldData',this.pid);
            })
            .catch(function (error) {
                    console.log("settopid");
                    console.log(error);
                    alert(error);
                });          
        },
        CheckNewData() {
            axios.get("api/auth/mqttdata/pid")
            .then((response) => {
                this.pidPlaceHolder = response.data[0].pid;
                if (this.pidPlaceHolder != this.pid){
                    axios.get("api/auth/mqttdata/last")
                    .then((response) =>{
                        var bodyFormData = new FormData();
                        var text = "\nTime: " + new Date(response.data[0].time * 1000).toLocaleDateString("en-NL") + "\nId: " + response.data[0].pid + "\nLat: " + response.data[0].latitude +
                         "\nLong: " + response.data[0].longitude + "\nType: " + response.data[0].soundtype + "\nProbability: " + response.data[0].probability;
                        console.log(text);// kan weg evt..
                        bodyFormData.append('message', text);
                        axios.post("api/mail/send", bodyFormData);
                    })
                    this.$store.commit('OldData',this.pidPlaceHolder);               
                }
            }).catch(function (error) {
                    console.log("settopnewid");
                    console.log(error);
                    alert(error);
                });  
        },
        SendWeeklyReport(){
            axios.get("api/auth/mqttdata/message")
            .then((response) => {
                this.reportMsg = response.data;
                // console.log(this.reportMsg);//test regel..
                var bodyFormData = new FormData();
                bodyFormData.append('message', this.reportMsg);
                axios.post("api/mail/send", bodyFormData);// bewust zelfde naam als regel 131
            }).catch(function (error) {
                    console.log(error);
                });        
        }
    },
    mounted() {
        this.GetSounds();
        this.SetTopPid();
        this.timer = setInterval(() => {
            if (this.$router.currentRoute.path != '/dashboard')// weekly report moet eigen timer krijgen die niet gecleared wordt
                clearInterval(this.timer);
                if (this.counter < 9) {
                    this.counter += 1;
                }
                if(this.counter > 8){
                    this.GetSounds();
                    this.CheckNewData();
                    this.SendWeeklyReport();
                    
                }
            }, 1000);

        //  this.timer2 = setInterval(() => {
        //     if (this.counterWeek < (60*60*24*7)){ //1 week
        //             this.counterWeek += 1;
        //         }
        //     else{
        //         this.counterWeek = 1;
        //         this.SendWeeklyReport();
        //     }                               
        //  },1000)
    }
}
</script>

<style scoped>
    label {
        font-size: calc(1vw + 10px);
        color: black;
    }
    div {
        font-family: Arial;
        font-size: calc(0.5vw + 10px);
    }
    .select select {
        background-color: #336ca6;
        color: white;
        box-shadow: 0 5px 25px rgba(0, 0, 0, 0.2);
        -webkit-appearance: button;
        cursor: pointer;
        margin-bottom: 1%;
        padding: 5px;
    }

    .badgeColumn {
        align-content: center;
    }

    .badge {
        height: calc(2vw + 18px);
        line-height: calc(2vw + 18px);
        border-radius: 150px / 160px;
    }
    .progress {
        line-height: 0vw;
    }

    .dashboard-geluidendata {
        width: 80%;
        height: 60%;
        position: absolute;
        overflow-x: auto;
        overflow-y: auto;
    }

    .flat-table {
        width: 100%;
        border-collapse: collapse;
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
        padding: calc(0.5vw + 3px);
        color: white;
        text-shadow: 0 0 1px rgba(0, 0, 0, 0.1);
    }

    .flat-table td {
        text-align: center;
        padding: calc(0.5vw + 3px);
        text-shadow: 0 0 1px rgba(255, 255, 255, 0.1);
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
        max-width: calc(130px + 12vw);
        max-height: 10vw;
    }

    ::-webkit-scrollbar {
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
            height: 50%;
            position: absolute;
            overflow-x: auto;
            overflow-y: auto;
        }
        #bigScreen {
            display: none;
        }
    }
    @media only screen and (min-width: 768px) {
        #smallScreen {
            display: none;
        }
    }
</style>
