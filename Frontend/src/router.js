import Vue from 'vue'
import Router from 'vue-router'
import Meta from 'vue-meta'
var VueCookie = require('vue-cookie');
import Login from './views/login'
import Dashboard from './views/dashboard'
import HistoryData from './views/historyData'

import newUser from './views/newUser'
import './style.css'

Vue.use(Router)
Vue.use(Meta)
Vue.use(VueCookie)

export default new Router({
  mode: 'history',
  routes: [
    {
      name: 'Log in',
      path: '/',
      component: Login,
      props: true
    },
    {
      name: 'dashboard',
      path: '/dashboard',
      component: Dashboard,
      props: true
    },
    {
      name: 'newUser',
      path: '/newUser',
      component: newUser,
      props: true
    },
    {
      name: 'historyData',
      path: '/historyData',
      component: HistoryData,
      props: true
    }
  ],
})

