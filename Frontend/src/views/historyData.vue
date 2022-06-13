<template>
  <div class="container" v-if="isLoggedIn()">
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
    <HistoryTable/>
  </div>
</template>

<script
  type="text/javascript"
  src="node_modules/vuejs/dist/vue.min.js"
></script>
<script
  type="text/javascript"
  src="node_modules/vue-simple-search-dropdown/dist/vue-simple-search-dropdown.min.js"
></script>
<script type="text/javascript">
Vue.use(Dropdown);
</script>

<script>
import axios from "axios";
import HistoryTable from "../components/historyTable";

export default {
  name: "HistoryData",
  components: {
      HistoryTable
  },
  data() {
    return {
      sounds: [],
      pid: 0,
      latitude: "",
      longitude: "",
      soundtype: "",
      probability: 0,
      sound: "",
      time: 0,
      timer: "",
    };
  },
  methods: {
    dashboard() {
      this.$router.push('/dashboard');
    },
    Logout() {
      this.$cookie.delete("token");
      this.$cookie.delete("superUser");
      this.$router.push("/");
    },
    async isLoggedIn() {
      return this.LoggedIn;
    },
    Sidebaropen() {
      var sideMenu = document.getElementById("sidebar");
      sideMenu.style.display = "block";
    },
    Sidebarclose() {
      const mediaQuery = window.matchMedia('(max-width: 768px)')
      if(mediaQuery){
        var sideMenu = document.getElementById("sidebar");
        sideMenu.style.display = "none";

      }
    },
  }
};
</script>

<style scoped>
.container {
    height: 100%;
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
    height: 0;
    width: 98%;
    grid-template-columns: 100%;
    margin: 0;
    margin-left: 5px;
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
  .burger-menu{
    margin-top: 5px;
    left: 0;
    padding: 5px;
    display: block; 
  }
}
</style>
