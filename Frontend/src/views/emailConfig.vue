<template>
    <div class="login-container">
        <div class="login-container1">             
            <h1 class="login-text">Instellingen wijzigen</h1>
            <div class="login-container2">
               <h2 class="login-text">Wilt u nieuwe data binnen krijgen via uw e-mail?</h2>

            <select v-model="issuperUser" class="login-textinput1 input" style="width: 40%">
            <option value="false" @click="receive_mail = 'false'"  >Nee</option>
            <option value="true" @click="receive_mail = 'true'" >Ja</option>
            </select>              
                <button class="login-button button" @click="BackToMain(receive_mail, )">
                     Klaar!
                </button>
                <h2>Email</h2>
                <input
                style="width: 40%"
                type="text"
                id="email"
                placeholder="Email"
                class="login-textinput input"
                />
            </div>  
        </div>
        <app-footer rootClassName="footer-root-class-name1"></app-footer>
    </div>
</template>

<script>
import AppFooter from "../components/footer";
import router from "../router";
import axios from "axios";
//import store from "C:\Users\esat6\Documents\GitHub\ProjectD-ChengetaWildlife\Frontend\src\store.js";
var VueCookie = require("vue-cookie");
export default {
    name: "emailConfig",
    components: {
        AppFooter,
    },
    data() {
        return {
            receive_mail: '',
            config_mail: ''
        };
    },
    methods: {                    
        BackToMain: function (receive_mail, mailadress) {
            if (receive_mail){
                console.log(mailadress);
            }
            if (!receive_mail){
                console.log(mailadress);
            }
            this.$router.replace({ name: "dashboard" });
        },
        isSuperUser() {
            if (this.issuperUser == "") {
                document.getElementById("error").style.display = "block";
                this.errormessage = "U heeft geen superuser geselecteerd";
                return false;
      }
      return true;
    },
    },
    metaInfo: {
        title: "Email Config - Chengeta wildlife",
        meta: [
            {
                property: "og:title",
                content: "Email Config - Chengeta wildlife",
            },
        ],
    },
};
</script>
<style scoped>
.login-container {
    width: 100%;
    height: auto;
    display: flex;
    min-height: 100vh;
    align-items: center;
    flex-direction: column;
    justify-content: flex-start;
    background-color: #c3c5c9;
}
.login-container1 {
    top: 0px;
    left: 0px;
    right: 0px;
    width: 531px;
    bottom: 0px;
    height: 354px;
    margin: auto;
    display: flex;
    z-index: 100;
    position: absolute;
    max-width: 80%;
    box-shadow: 0 20px 25px -5px rgba(0, 0, 0, 0.1),
        0 10px 10px -5px rgba(0, 0, 0, 0.04);
    align-items: flex-start;
    border-radius: var(--dl-radius-radius-radius75);
    flex-direction: column;
    background-color: #d9d9da;
}
.login-text {
    color: #000000;
    align-self: center;
}
.login-container2 {
    top: 0px;
    left: 0px;
    right: 0px;
    width: 100%;
    bottom: 0px;
    height: 30%;
    display: flex;
    align-self: center;
    margin-top: auto;
    align-items: center;
    margin-left: auto;
    margin-right: auto;
    margin-bottom: auto;
    flex-direction: column;
}
.login-textinput {
    margin-bottom: var(--dl-space-space-unit);
    padding-bottom: var(--dl-space-space-halfunit);
    color: black;
}
.login-textinput1 {
    margin-bottom: var(--dl-space-space-unit);
    color: black;
}
.login-button {
    color: #ffffff;
    transition: 0.3s;
    border-color: #dadada;
    background-color: #3a65ff;
}
.login-button:hover {
    transform: scale(1.1);
    cursor: pointer;
}
@media (max-width: 479px) {
    .login-container1 {
        width: 100%;
    }
}
</style>