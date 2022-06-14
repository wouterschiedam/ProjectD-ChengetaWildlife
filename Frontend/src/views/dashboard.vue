<template>
    <div class="container">
        <div class="burger-menu">
            <button id="menubtn" @click="Sidebaropen()">
                <span class="material-icons-sharp">menu</span>
            </button>
        </div>
        <aside id="sidebar">
            <div class="top">
                <div class="logo">
                    <img
                        src="../../public/playground_assets/217332412_177488101085809_6155924843160933349_n-1500h.jpg"
                    />
                    <h2>Chengeta</h2>
                </div>
                <div class="close" id="closee-btn">
                    <span class="material-icons-sharp" @click="Sidebarclose()">close</span>
                </div>
            </div>
            <div class="sidebar">
                <a >
                    <span class="material-icons-sharp">grid_view</span>
                    <h3>Dashboard</h3>
                </a>
                <a @click="fullScreenView()">
                    <span class="material-icons-sharp">fullscreen</span>
                    <h3>Fullscreen</h3>
                </a>
                <a @click="printMapHtml()">
                    <span class="material-icons-sharp">print</span>
                    <h3>Print map</h3>
                </a>
                <a @click="historyData()">
                    <span class="material-icons-sharp">work_history</span>
                    <h3>Historische data</h3>
                </a>
                <a v-if="this.$store.state.superUser" @click="Account()">
                    <span class="material-icons-sharp">person_add</span>
                    <h3>Nieuw account</h3>
                </a>
                <a @click="Togglemap()">
                    <span class="material-symbols-outlined">map</span>
                    <h3>Toggle map</h3>
                </a>
                <a @click="Logout()">
                    <span class="material-icons-sharp">logout</span>
                    <h3>Uitloggen</h3>
                </a>
            </div>
        </aside>
        <!-- MAIN - MAP -->
        <main>
            <div v-if="current" >
                <Markermap/>
            </div>
            <div v-if="!current">
                <heatmap/>
            </div>
            <!-- MAIN - DATA -->
            <DashboardTable />
        </main>
        <!-- TOP -->
    </div>
</template>

<script>
import Progress from "easy-circular-progress";
import AppFooter from "../components/footer";
import DashboardTable from "../components/dashboardTable";
import Markermap from "../components/Markermap";
import heatmap from "../components/heatmap";
import html2canvas from "html2canvas";  
import axios from "axios";
import router from "../router";
var VueCookie = require("vue-cookie");

export default {
    name: "dashboard",
    components: {
        AppFooter,
        DashboardTable,
        Progress,
        Markermap,
        heatmap


    },
    props: ["superUser"],
    data() {
        return {
            LoggedIn: null,
            sounds: [],
            point: null,
            current: true,
            timer: "",
        };
    },
    methods: {
        Togglemap() {
            if (this.current) {
                this.current = false;
            } else{
                this.current = true;
            }
            console.log(this.current);
        },
        historyData() {
            this.$router.replace({ name: "historyData" });
        },
        Account: function () {
            router.push({
                name: "newUser",
                params: { LoggedIn: this.LoggedIn, superUser: this.superUser },
            });
        },
        Logout() {
            this.$cookie.delete("token");
            this.$store.commit("setsuperUser", false);
            this.$store.commit("setAuth", false);
            this.$router.replace({ name: "Log in" });
        },
        Sidebaropen() {
            var sideMenu = document.getElementById("sidebar");
            sideMenu.style.display = "block";
        },
        Sidebarclose() {
            const mediaQuery = window.matchMedia("(max-width: 768px)");
            if (mediaQuery) {
                var sideMenu = document.getElementById("sidebar");
                sideMenu.style.display = "none";
            }
        },     
        fullScreenView() {
            if(this.current){
                var mapId = document.getElementById("map");
                mapId.requestFullscreen();
            }
            if(!this.current){
                var heatmapId = document.getElementById("heatmap");
                heatmapId.requestFullscreen();
            }

        },
        printMapHtml() {
            if(this.current){
                var screenshotTarget = document.getElementById("map");
            }
            if(!this.current){
                var screenshotTarget = document.getElementById("heatmap");
            }
            html2canvas(screenshotTarget, {
                useCORS: true,
                allowTaint: true,
            }).then((canvas) => {
                const base64image = canvas.toDataURL("image/png");
                var temp_link = document.createElement("a");
                temp_link.href = base64image;
                temp_link.download = "map.png";
                temp_link.click();
            });
        },
    },
    metaInfo: {
        title: "Dashboard - Chengeta wildlife",
        meta: [
            {
                property: "og:title",
                content: "Dashboard - Chengeta wildlife",
            },
        ],
    },
    created() {

        //reload every 60 seconds
        // const counter = setInterval(() => {
        //   this.GetSounds();
        // }, 60000);
        // this.countDownTimer();
    },
    mounted() {
        //this.GetSounds();
    },
    beforeDestroy() {
        //this.cancelAutoUpdate();
    },
};
</script>

<style>
.dashboard-heatmap {
    flex: 0 0 auto;
    width: 100%;
    height: 516px;
    position: relative;
    align-items: flex-start;
    flex-direction: column;
    display: flex;
}
.dashboard-map {
    flex: 0 0 auto;
    width: 100%;
    height: 517px;
    display: flex;
    position: relative;
    align-items: flex-start;
    flex-direction: column;
}
/* LEGEND */
.legend span,
.legend label {
    display: block;
    width: 50px;
    height: 18px;
    float: left;
    background-color: white;
    padding: 5px;
    text-align: center;
    font-size: 100%;
    color: black;
}
/* STYLING DATA */
main {
    width: 100%;
}


/* STYLING SIDEBAR */
a {
    color: var(--color-dark);
}
img {
    display: block;
    width: 100%;
}
h1 {
    font-weight: 800;
    font-size: 1.8rem;
}
h2 {
    font-size: 1.4rem;
}
h3 {
    font-size: 0.87rem;
}
h4 {
    font-size: 0.8rem;
}
h5 {
    font-size: 0.77rem;
}
small {
    font-size: 0.75rem;
}
.container {
    display: grid;
    width: 98%;
    margin: 0 auto;
    gap: 1.8rem;
    grid-template-columns: 14rem 82% auto;
}
aside {
    height: 100vh;
    background: var(--color-light);
}
aside .top {
    background: white;
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-top: 1.4rem;
}
aside .logo {
    display: flex;
    gap: 0.8rem;
}
aside .logo img {
    width: 2.5rem;
    height: 2.5rem;
}
aside .close {
    display: none;
}
aside .sidebar {
    background: white;
    display: flex;
    flex-direction: column;
    position: relative;
    height: 86vh;
    top: 3rem;
}
aside h3 {
    font-weight: 600;
}
aside .sidebar a {
    display: flex;
    color: var(--color-dark);
    margin-left: 2rem;
    gap: 1rem;
    align-items: center;
    position: relative;
    height: 3.7rem;
    transition: all 300ms ease;
    cursor: pointer;
}
aside .sidebar a span {
    font-size: 1.6rem;
    transition: all 300ms ease;
}
aside .sidebar a:last-child {
    position: absolute;
    bottom: 2rem;
    width: 100%;
}
aside .sidebar a.active {
    background: var(--color-light);
    color: var(--color-primary);
    margin-left: 0;
}
aside .sidebar a.active:before {
    content: "";
    width: 6px;
    height: 100%;
    background: var(--color-primary);
}
aside .side a.active span {
    color: var(--color-primary);
    margin-left: calc(1rem - 3px);
}
aside .sidebar a:hover {
    color: var(--color-primary);
}
aside .sidebar a:hover span {
    margin-left: 1rem;
}
/* TOP */
.burger-menu {
    display: none;
}

@media screen and (max-width: 820px) {
    .container {
        width: 94%;
        grid-template-columns: 10rem 88% auto;
        margin-left: 1%;
    }
    aside .logo h2 {
        display: none;
    }
    aside .sidebar h3 {
        display: none;
    }
    aside .sidebar h3 {
        width: 5.6rem;
    }
    aside .sidebar h3 {
        position: relative;
        margin-top: 1.8rem;
    }
    .dashboard-map {
        width: 95%;
    }
}
@media screen and (max-width: 768px) {
    .container {
        width: 98%;
        grid-template-columns: 100%;
        margin: 0;
        margin-left: 5px;
        gap: 0;
    }
    aside {
        position: fixed;
        left: 0;
        background: white;
        width: 18rem;
        z-index: 3;
        box-shadow: 1rem 3rem 4rem var(--color-light);
        height: 100vh;
        padding-right: 0.2rem;
        display: none;
    }
    aside .logo {
        margin-left: 1rem;
    }
    aside .logo h2 {
        display: inline;
    }
    aside .sidebar h3 {
        display: inline;
        margin-top: 0;
        width: 100px;
    }
    aside .sidebar a {
        width: 100%;
        height: 3.4rem;
    }
    aside .close {
        display: inline-block;
        cursor: pointer;
    }
    .top {
        display: flex;
    }
    .top button {
        background: transparent;
    }
    .dashboard-map {
        width: 95%;
    }
    .burger-menu {
        margin-top: 5px;
        left: 0;
        padding: 5px;
        display: block;
    }
}
</style>
