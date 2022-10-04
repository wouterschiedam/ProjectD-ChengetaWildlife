<template>
    <div class="login-container">
        <div class="login-container1">             
            <h1 class="login-text">Nummers die SMS-notificaties ontvangen</h1>
            <div class="login-text">
                    <table>
                            <thead>
                                <tr>
                                    <th>Telefoonnummers:</th>
                                </tr>
                            </thead>
                            <tbody v-for="number in listNumber" :key="number">
                                <tr>
                                    <td>
                                        {{ number.number }}
                                    </td>
                                </tr>
                            </tbody>
                    </table>
    
                </div>
                <div class = "enter_number">
                    <input
                        style="width: 40%"
                        type="text"
                        id="phonenumber"
                        placeholder="Phone"
                        class="login-textinput input"
                    /> 
                    <button class="add-button button4" @click="AddNumber()">Toevoegen</button>
                    <button class="del-button button4" @click="Remove()">Verwijderen</button>
                </div>               
        </div>
        <app-footer rootClassName="footer-root-class-name1"></app-footer>
    </div>
</template>

<script>
import AppFooter from "../components/footer";
import router from "../router";
import axios from "axios";
import store from "../store";
import { stringifyStyle } from "@vue/shared";
var VueCookie = require("vue-cookie");
export default {
    name: "phoneConfig",
    components: {
        AppFooter,
    },
    data() {
        return {
            listNumber: [],
        };
    },
    methods: {                    
        BackToMain: function (receive_sms, phonenumber) {
            if (receive_sms){
                console.log(phonenumber);
            }
            if (!receive_sms){
                console.log(phonenumber);
            }
            this.$router.replace({ name: "dashboard" });
        },
        ShowNotif: function(){
            axios.get("api/sms/return")
                .then((response) => {
                    this.listNumber = response.data;
                    this.$store.commit('UpdatePhone', this.listPhone);
                    console.log("Updated numbers");
                })
                .catch(function (error) {
                    console.log(error);
                    alert(error);
                });
        },
        Remove: function(){
            var bodyFormData = new FormData();
            bodyFormData.append('Phone', document.getElementById("phonenumber").value);
                    axios.post("api/sms/del", bodyFormData)
                        .then(response => {
                            console.log(response);
                            alert("SMS notificaties uitgezet!");
                            this.$router.replace({ name: "dashboard" });
                        })
                        .catch(error => {
                            console.error(error);
                        });
        },
        AddNumber: function() {
            var bodyFormData = new FormData();
            bodyFormData.append('Phone', document.getElementById("phonenumber").value);
                    axios.post("api/sms/update", bodyFormData)
                        .then(response => {
                            console.log(response);
                            alert("SMS notificaties aangezet!");
                            this.$router.replace({ name: "dashboard" });
                        })
                        .catch(error => {
                            console.error(error);
                        });
        },
    },
    mounted() {
        this.ShowNotif();
    },
    metaInfo: {
        title: "SMS Config - Chengeta wildlife",
        meta: [
            {
                property: "og:title",
                content: "SMS Config - Chengeta wildlife",
            },
        ],
    },
};
</script>
<style scoped>
.enter_number {
    width: 100%;
    height: auto;
    display: flex;
    min-height: 100vh;
    align-items: center;
    flex-direction: column;
    justify-content: flex-start;
}
.button4 {
    background-color: #00bcd4;
    color: white;
    border: none;
    border-radius: 5px;
    padding: 10px;
    font-size: 16px;
    font-family: sans-serif;
    cursor: pointer;
    margin: 5px;
    size: 100px;
}
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
.del-button{
    color: #ffffff;
    transition: 0.3s;
    border-color: #dadada;
    background-color: #ff683a;
}
.add-button{
    color: #ffffff;
    transition: 0.3s;
    border-color: #dadada;
    background-color: #62cc1b;
}
.login-button:hover {
    transform: scale(1.1);
    cursor: pointer;
}
.del-button:hover {
    transform: scale(1.1);
    cursor: pointer;
}
.add-button:hover {
    transform: scale(1.1);
    cursor: pointer;
}
@media (max-width: 479px) {
    .login-container1 {
        width: 100%;
    }
}
</style>