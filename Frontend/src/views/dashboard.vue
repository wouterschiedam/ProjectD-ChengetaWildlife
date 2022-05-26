<template>
  <div class="dashboard-container">
    <app-header1 rootClassName="header1-root-class-name"></app-header1>
    <div class="dashboard-container1">
      <div class="dashboard-map"></div>
      <div class="dashboard-sidebar">
        <div class="dashboard-container2">
          <span class="dashboard-text">Dashboard</span>
          <span class="dashboard-text1">Historische data</span>
        </div>
      </div>
      <div class="dashboard-geluidendata"></div>
    </div>
    <app-footer rootClassName="footer-root-class-name3"></app-footer>
  </div>
</template>

<script>
import AppHeader1 from '../components/header1'
import AppFooter from '../components/footer'

export default {
  name: 'Dashboard',
  components: {
    AppHeader1,
    AppFooter,
  },
  metaInfo: {
    title: 'dashboard - Chengeta wildlife',
    meta: [
      {
        property: 'og:title',
        content: 'dashboard - Chengeta wildlife',
      },
    ],
  },
}
</script>

<style scoped>
.dashboard-container {
  width: 100%;
  display: flex;
  overflow: auto;
  min-height: 100vh;
  align-items: center;
  flex-direction: column;
  background-color: #D9D9D9;
}
.dashboard-container1 {
  width: 100%;
  height: 100%;
  display: flex;
  position: relative;
  align-items: flex-start;
  background-color: #D9D9D9;
}
.dashboard-map {
  top: 0px;
  flex: 0 0 auto;
  left: 200px;
  width: 977px;
  height: 517px;
  display: flex;
  position: absolute;
  align-self: flex-end;
  align-items: flex-start;
  flex-direction: column;
}
.dashboard-sidebar {
  flex: 0 0 auto;
  width: 200px;
  height: 912px;
  display: flex;
  position: relative;
  align-items: flex-start;
  flex-direction: column;
  background-color: #efefef;
}
.dashboard-container2 {
  width: 200px;
  height: 232px;
  display: flex;
  position: relative;
  align-items: flex-start;
  flex-direction: column;
}
.dashboard-text {
  top: var(--dl-space-space-unit);
  left: 59px;
  align-self: center;
}
.dashboard-text1 {
  top: var(--dl-space-space-tripleunit);
  left: 40px;
  position: absolute;
  align-self: center;
}
.dashboard-geluidendata {
  flex: 0 0 auto;
  left: 200px;
  width: 984px;
  bottom: 0px;
  height: 371px;
  display: flex;
  position: absolute;
  align-items: flex-start;
  flex-direction: column;
}
@media(max-width: 991px) {
  .dashboard-map {
    width: 776px;
  }
  .dashboard-geluidendata {
    width: 775px;
  }
}
@media(max-width: 767px) {
  .dashboard-map {
    width: 563px;
  }
  .dashboard-geluidendata {
    width: 565px;
  }
}
@media(max-width: 479px) {
  .dashboard-map {
    width: 280px;
  }
  .dashboard-sidebar {
    width: 143px;
    padding-right: 0px;
  }
  .dashboard-text {
    align-self: flex-start;
  }
  .dashboard-text1 {
    left: 0px;
  }
  .dashboard-geluidendata {
    width: 282px;
  }
}
</style>
