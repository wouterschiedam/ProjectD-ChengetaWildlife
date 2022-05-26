import Vue from 'vue'
import Router from 'vue-router'
import Meta from 'vue-meta'
var VueCookie = require('vue-cookie');
import Login from './views/login'
import Dashboard from './views/dashboard'
import test from './views/testdashboard'
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
    },
    {
      name: 'dashboard',
      path: '/dashboard',
      component: Dashboard,
    },
    {
      name: 'test',
      path: '/test',
      component: test,
    }
  ],
})
