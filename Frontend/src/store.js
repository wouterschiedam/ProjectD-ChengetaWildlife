import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);
export default new Vuex.Store({
    state: {
        authenticated: false,
        superUser: false,
        email: "",
        sounds: [],
        listMail: []
    },
    mutations: {
        setAuth(state, status) {
            state.authenticated = status;
        },
        setEmail(state, status) {
            state.email = status;
        },
        setsuperUser(state, status){
            state.superUser = status
        },
        Updatedata(state, data){
            state.sounds = data
        },
        UpdateMail(state, data){
            state.listMail = data
        }
    },
})