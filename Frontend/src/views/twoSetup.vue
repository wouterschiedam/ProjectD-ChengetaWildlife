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
      <h1 class="login-text">2 Staps verificatie</h1>
        <img class="login-text" :src="qrcode" />
        <h5 class="login-text">{{qrcodeManual}}</h5>
      <div class="login-container2">
        <input type="text" placeholder="PIN-code" id="PIN" class="login-textinput input" />

        <a class="h3-error">{{ errormessage }}</a>
        <button class="login-button button" @click="login()">Verifiëren</button>
      </div>
    </div>
    <app-footer rootClassName="footer-root-class-name1"></app-footer>
  </div>
</template>

<script>
import AppHeader from '../components/header'
import AppFooter from '../components/footer'
import axios from 'axios';
import router from "../router";
export default {
  name: 'Login',
  components: {
    AppHeader,
    AppFooter,
  },
  props: ['id','email', 'password'],
  data(){
    return{
      token: '',
      errormessage: '',
      isVerified: false,
      qrcodeManual: '',
      qrcode: '',
      Id: '',
      email: '',
      password: '',
      
      
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
      login : async function(){
      let token = "";
      var bodyFormData = new FormData();
      bodyFormData.append("id", this.id);
      bodyFormData.append("token_input", document.getElementById("PIN").value)
      bodyFormData.append("email", this.email);
      bodyFormData.append("password", this.password);
      console.log(bodyFormData)
      await axios.post("/api/auth/2FAverify", bodyFormData).then((Response) =>
        {isVerified = Response.data.isCorrectPIN,
        token = Response.data.token,
        errormessage = Response.data.error})
      if(isVerified){
        VueCookieNext.setCookie("token", decodeURI(token), {expire :"2h"});
        router.push({
          name: "Home"
        })
      }
    
    }
  },
  mounted(){
    var bodyFormData = new FormData();
    bodyFormData.append("email", this.email);
    bodyFormData.append("id", this.id);
    bodyFormData.append("password", this.password)
    axios.post('/api/auth/2FA', bodyFormData).then(response => {
      this.qrcodeManual = response.data.qrCodeManual
      this.qrcode = response.data.qrCodeImageUrl
    })
    router.push({
      name: "Home"
    })
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
