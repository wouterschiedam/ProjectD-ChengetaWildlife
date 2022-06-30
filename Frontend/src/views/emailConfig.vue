<template>
    <div class="login-container">
        <div class="login-container1">
            <h1 class="login-text">Email notificatie instellingen</h1>
            <div class="login-container2">
               

                <!-- <input
                    style="width: 40%"               
                    type="checkbox"
                    value="receive_mail"
                    checked="true:null"                   
                /> -->
        
            
                <input type="checkbox" id="checkbox" v-model="receive_mail" @onclick="EmailChoice()">
                <label for="checkbox">{{ checked }}</label>



                <a style="margin-bottom: 5%">{{ errormessage }}</a>
                <button class="login-button button" @click="login()">
                    Inloggen
                </button>
            </div>
        </div>
        <app-footer rootClassName="footer-root-class-name1"></app-footer>
    </div>
</template>

<script>
import AppFooter from "../components/footer";
import router from "../router";
import axios from "axios";
var VueCookie = require("vue-cookie");
export default {
    name: "Login",
    components: {
        AppFooter,
    },
    data() {
        return {
            Loggedin: false,
            errormessage: "",
            message_email: "",
            message_password: "",
            receive_mail: false
        };
    },
    methods: {
        validateEmail: function () {
            const re =
                /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(
                String(document.getElementById("email").value).toLowerCase()
            );
        },
        login: function () {
            if (!this.validateEmail()) {
                this.errormessage = "Voer een geldig e-mail adres in";
                return;
            }
            if (document.getElementById("password").value == "") {
                this.errormessage = "Voer een wachtwoord in";
                return;
            }
            var bodyFormData = new FormData();
            bodyFormData.append(
                "email",
                document.getElementById("email").value
            );
            bodyFormData.append(
                "password",
                document.getElementById("password").value
            );
            axios.post("/api/auth/login", bodyFormData).then((response) => {
                this.errormessage = response.data.message;
                if (response.data.success == true) {
                    this.$store.commit('setAuth', true);
                    this.$store.commit('setsuperUser', response.data.superuser);
                    localStorage.setItem("token", decodeURI(response.data.token), {
                        expire: "2h",
                    });
                    this.$router.replace({ name: "dashboard" });
                    // router.push({
                    //   name: "dashboard",
                    //   params: {Loggedin : true, superUser: this.$cookie.get('superUser')},
                    // });
                }
            });
        },
    },
    metaInfo: {
        title: "Log in - Chengeta wildlife",
        meta: [
            {
                property: "og:title",
                content: "Log in - Chengeta wildlife",
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