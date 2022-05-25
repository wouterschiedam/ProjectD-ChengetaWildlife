import Vue from 'vue'
import Router from 'vue-router'
import Meta from 'vue-meta'

import Sound from './views/sound'
import Map from './views/map'
import Login from './views/login'
import Allsounds from './views/allsounds'
import Home from './views/home'
import twoFAsetup from './views/twoSetup'
import twoFAverify from './views/twoVerify'
import './style.css'

Vue.use(Router)
Vue.use(Meta)
export default new Router({
  mode: 'history',
  routes: [
    {
      name: 'Sound',
      path: '/sound',
      component: Sound,
    },
    {
      name: 'Map',
      path: '/map',
      component: Map,
    },
    {
      name: 'Log in',
      path: '/login',
      component: Login,
      props: true,
    },
    {
      name: 'All sounds',
      path: '/sound1',
      component: Allsounds,
    },
    {
      name: 'Home',
      path: '/',
      component: Home,
    },
    {
      name: '2FAsetup',
      path: '/2FAsetup',
      component: twoFAsetup,
      props: true,
    },
    {
      name: '2FAverify',
      path: '/2FAverify',
      component: twoFAverify,
      props: true,
    }
  ],
})
