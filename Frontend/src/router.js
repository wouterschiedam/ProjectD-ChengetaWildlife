import Vue from 'vue'
import Router from 'vue-router'
import Meta from 'vue-meta'

import Sound from './views/sound'
import Map from './views/map'
import Login from './views/login'
import Allsounds from './views/allsounds'
import Home from './views/home'
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
  ],
})
