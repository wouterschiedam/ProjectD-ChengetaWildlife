<template>
  <div class="login-container">
    <div class="login-container1">
      <h1 class="login-text">Log in</h1>
      <div class="login-container2">
        <input type="text" id="email" placeholder="Email" class="login-textinput input" />
        <input
          id="password"
          type="text"
          placeholder="Wachtwoord"
          class="login-textinput1 input"
        />
        <a>{{errormessage}}</a>
        <button class="login-button button" @click="login()">Inloggen</button>
      </div>
    </div>
    <app-footer rootClassName="footer-root-class-name1"></app-footer>

  </div>
</template>

<script>
import AppHeader from "../components/header";
import AppFooter from "../components/footer";
import router from "../router";
import axios from "axios";
export default {
  name: "Login",
  components: {
    AppHeader,
    AppFooter,
  },
  data() {
    return {
      errormessage: "",
      message_email: "",
      message_password: "",
    };
  },
  methods: {
    Account: function(){
      router.push({name: "newUser"}); 
    },
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
      bodyFormData.append("email", document.getElementById("email").value);
      bodyFormData.append(
        "password",
        document.getElementById("password").value
      );
      axios.post("/api/auth/login", bodyFormData).then((response) => {
        this.errormessage = response.data.message;
        if (response.data.twoFAenabled == true) {
          router.push({
            name: "dashboard",
          });
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
  box-shadow: 0 20px 25px -5px rgba(0,0,0,0.1),0 10px 10px -5px rgba(0,0,0,0.04);
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
  margin: auto;
  display: flex;
  position: absolute;
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
