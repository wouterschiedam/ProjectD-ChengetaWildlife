<template>
  <div class="login-container">
    <div class="login-image">
      <app-header></app-header>
      <img
        alt="image"
        src="/playground_assets/gray-vector.svg"
        class="login-image1"
      />
      <div class="login-bg"></div>
    </div>
    <div class="login-container1">
      <h1 class="login-text">Nieuw account aanmaken</h1>
      <div class="login-container2">
        <input type="text" placeholder="Voornaam" id="Naam" class="login-textinput input" />
        <input type="text" placeholder="Email" id="Email" class="login-textinput input" />
        <input type="text" placeholder="Telefoon Nummer" id="PhoneNumber" class="login-textinput input" />
        <input type="text" placeholder="Wachtwoord" id="wachtwoord" class="login-textinput input" />
        <input type="text" placeholder="Wachtwoord herhalen" id="wachtwoord2" class="login-textinput input" />
        <a class="h3-error">{{ errormessage }}</a>
        <button class="login-button button" @click="login()">Account aanmaken</button>
      </div>
    </div>
    <app-footer rootClassName="footer-root-class-name1"></app-footer>
  </div>
</template>

<script>
import AppFooter from '../components/footer'
import axios from 'axios';
// import { VueCookieNext } from "vue-cookie-next";
import router from "../router";

export default {
  name: 'Login',
  components: {
    AppFooter,
  },
  data(){
    return{
      verified: '',
      token: '',
      errormessage: '',
      isSuperUser: false, ///////////
    }
  },
  metaInfo: {
    title: 'Log in - Chengeta wildlife',
    meta: [
      {
        property: 'og:title',
        content: 'Log in - Chengeta wildlife',
      },
    ],
  },
  methods: {
    passwordCheck: function(){
      if(document.getElementById("wachtwoord").value != document.getElementById("wachtwoord2").value){
        this.errormessage = 'Wachtwoorden komen niet overeen';
        return false
      }
      return true
    },
    nameCheck: function(){
      if(document.getElementById("Naam").value == ''){
        this.errormessage = 'Vul een voornaam in';
        return false;
      }
      return true
    },
    validateEmail: function() {
      const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      if (!re.test(String(Email.value).toLowerCase())) {
        this.errormessage = "Het ingevoerde email adress is niet geldig";
        return false;
      }
      else {
        return true;
      }
    },
    createAccount: async function(){
      if(this.nameCheck() && this.nameCheck() && this.validateEmail()){
        var bodyFormData = new FormData();
        bodyFormData.append("Name", document.getElementById("Naam").value);
        bodyFormData.append("Email", document.getElementById("Email").value);
        bodyFormData.append("PhoneNumber", document.getElementById("PhoneNumber").value);
        bodyFormData.append("Password", document.getElementById("wachtwoord").value);
        bodyFormData.append("Superuser", this.isSuperUser);
        bodyFormData.append("oauth", VueCookieNext.getCookie("token"));
        axios.post("api/auth/createnewUser", bodyFormData).then(Response)
      }
    }
  }
}
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
  background-color: var(--dl-color-pimary-900);
}
.login-image {
  flex: 0 0 auto;
  width: 100%;
  height: 500px;
  display: flex;
  position: relative;
  align-items: center;
  flex-direction: column;
  background-size: cover;
  background-image: url("https://images.unsplash.com/photo-1499336315816-097655dcfbda?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1000&q=80");
}
.login-image1 {
  left: auto;
  right: auto;
  width: 100%;
  bottom: -1px;
  z-index: 100;
  position: absolute;
  object-fit: cover;
}
.login-bg {
  top: auto;
  flex: 0 0 auto;
  left: auto;
  right: 0px;
  width: 100%;
  bottom: auto;
  height: 100%;
  display: flex;
  opacity: 0.5;
  position: absolute;
  align-items: flex-start;
  flex-direction: column;
  background-color: var(--dl-color-gray-black);
}
.login-container1 {
  flex: 0 0 auto;
  width: 770px;
  height: 40%;
  display: flex;
  z-index: 100;
  max-width: 80%;
  box-shadow: 0 20px 25px -5px rgba(0,0,0,0.1),0 10px 10px -5px rgba(0,0,0,0.04);
  margin-top: -12rem;
  align-items: flex-start;
  border-radius: var(--dl-radius-radius-radius75);
  margin-bottom: var(--dl-space-space-fiveunits);
  flex-direction: column;
  background-color: var(--dl-color-gray-white);
}
.login-text {
  color: #000000;
  align-self: center;
}
.login-container2 {
  width: 100%;
  height: 222px;
  display: flex;
  margin-top: var(--dl-space-space-tripleunit);
  align-items: center;
  margin-bottom: var(--dl-space-space-tripleunit);
  flex-direction: column;
}
.login-textinput {
  margin-bottom: var(--dl-space-space-unit);
  padding-bottom: var(--dl-space-space-halfunit);
}
.login-textinput1 {
  margin-bottom: var(--dl-space-space-unit);
}
.login-button {
  color: #ffffff;
  transition: 0.3s;
  border-color: #dadada;
  background-color: #3a65ff;
}
.login-button:hover {
  transform: scale(1.1);
}

@media(max-width: 479px) {
  .login-container1 {
    width: 100%;
  }
}
</style>
