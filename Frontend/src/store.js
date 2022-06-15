import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);
export default new Vuex.Store({
    state: {
        authenticated: false,
        superUser: false,
        sounds: []
    },
    mutations: {
        setAuth(state, status) {
            state.authenticated = status;
        },
        setsuperUser(state, status){
            state.superUser = status
        },
        Updatedata(state, data){
            state.sounds = data
        }
    },
})