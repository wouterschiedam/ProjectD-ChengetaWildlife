import Vue from 'vue'
import Router from 'vue-router'
import Meta from 'vue-meta'

import Login from './views/login'
import Allsounds from './views/allsounds'
import Dashboard from './views/dashboard'
import Map from './views/map'
import Sound from './views/sound'
import './style.css'

Vue.use(Router)
Vue.use(Meta)
export default new Router({
  mode: 'history',
  routes: [
    {
      name: 'Log in',
      path: '/',
      component: Login,
    },
    {
      name: 'All sounds',
      path: '/sound1',
      component: Allsounds,
    },
    {
      name: 'dashboard',
      path: '/dashboard',
      component: Dashboard,
    },
    {
      name: 'Map',
      path: '/map',
      component: Map,
    },
    {
      name: 'Sound',
      path: '/sound',
      component: Sound,
    },
  ],
})
