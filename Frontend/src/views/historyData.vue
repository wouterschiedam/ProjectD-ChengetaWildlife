<template>
  <div class="container" v-if="isLoggedIn()">
    <aside>
      <div class="top">
        <div class="logo">
          <img
            src="../../public/playground_assets/217332412_177488101085809_6155924843160933349_n-1500h.jpg"
          />
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
  }
};
</script>

<style scoped>
.container {
    height: 100%;
}
</style>
