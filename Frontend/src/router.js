import Vue from "vue";
import Vuex from "vuex";
import Router from "vue-router";
import store from "./store";
import Meta from "vue-meta";
var VueCookie = require("vue-cookie");
import Login from "./views/login";
import Dashboard from "./views/dashboard";
import HistoryData from "./views/historyData";
import newUser from "./views/newUser";
import "./style.css";

Vue.use(Router);
Vue.use(Meta);
Vue.use(Vuex)
Vue.use(VueCookie);



export default new Router({
    mode: "history",
    routes: [
        {
            name: "Log in",
            path: "/",
            component: Login,
        },
        {
            name: "dashboard",
            path: "/dashboard",
            component: Dashboard,
            beforeEnter: (to, from, next) => {
              console.log(store.state.authenticated)
                if (store.state.authenticated) {
                    next();
                } else {
                    next({name: "Log in"});
                }
            },
        },
        {
            name: "newUser",
            path: "/newUser",
            component: newUser,
            beforeEnter: (to, from, next) => {
              if (localStorage.getItem('token') != null && store.state.superUser) {
                  next();
              } else {
                  next({name: "Log in"});
              }
          },
        },
        {
            name: "historyData",
            path: "/historyData",
            component: HistoryData,
            beforeEnter: (to, from, next) => {
              if (store.state.authenticated) {
                  next();
              } else {
                  next({name: "Log in"});
              }
          },
        },
    ],
});
