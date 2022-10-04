<template>
  <div class="login-container">
    <div class="login-container1">
      <h1 class="login-text">Nieuw account aanmaken</h1>
      <div class="login-container2">
          <h2>Voornaam</h2>
          <input
          style="width: 40%"
          type="text"
          id="name"
          placeholder="Voornaam"
          class="login-textinput input"
        />
        <h2>Email</h2>
        <input
          style="width: 40%"
          type="text"
          id="email"
          placeholder="Email"
          class="login-textinput input"
        />
        <h2>Wachtwoord</h2>
        <input
          style="width: 40%"
          id="password"
          type="password"
          placeholder="Wachtwoord"
          class="login-textinput1 input"
        />
        <h2>Wachtwoord herhalen</h2>
        <input
          style="width: 40%"
          id="password1"
          type="password"
          placeholder="Wachtwoord"
          class="login-textinput1 input"
        />
        <h2>Superuser</h2>
        <select
          v-model="issuperUser"
          class="login-textinput1 input"
          style="width: 40%"
        >
          <option value="false" @click="issuperUser = 'false'">Nee</option>
          <option value="true" @click="issuperUser = 'true'">Ja</option>
        </select>
        <a id="error" style="margin-bottom: 1%; display: none;">{{ errormessage }}</a>
        <button class="login-button button" @click="sendToServer()">Account aanmaken</button>
      </div>
    </div>
    <app-footer rootClassName="footer-root-class-name1"></app-footer>
  </div>
</template>

<script>
import AppFooter from "../components/footer";
import router from "../router";
import axios from "axios";
export default {
  name: "newUser",
  components: {
    AppFooter,
  },
  props: ["Loggedin", "superUser"],
  data() {
    return {
      created: false,
      issuperUser: "",
      isLoggedin: false,
      errormessage: "",
      message_email: "",
      message_password: "",
    };
  },
  methods: {
    passwordCheck() {
      if (document.getElementById("password").value != document.getElementById("password1").value) {
        document.getElementById("error").style.display = "block";
        this.errormessage = "De ingevoerde wachtwoorden komen niet overeen";
        return false;
      } else {
        return true;
      }
    },
    nameCheck() {
      if (document.getElementById("name").value != "") {
        return true;
      } else {
        document.getElementById("error").style.display = "block";
        this.errormessage = "U heeft geen naam ingevuld";
        return false;
      }
    },
    isSuperUser() {
      if (this.issuperUser == "") {
        document.getElementById("error").style.display = "block";
        this.errormessage = "U heeft geen superuser geselecteerd";
        return false;
      }
      return true;
    },
    validateEmail() {
      const re =
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      if (!re.test(String(document.getElementById("email").value).toLowerCase())) {
        document.getElementById("error").style.display = "block";
        this.errormessage = "Het ingevoerde email adress is niet geldig";
        return false;
      } else {
        return true;
      }
      ////// validateNumber()
    },
    async sendToServer() {
      if (this.nameCheck() && this.passwordCheck() && this.validateEmail() && this.isSuperUser()) {
        var bodyFormData = new FormData();
        bodyFormData.append("Name", document.getElementById("name").value);
        bodyFormData.append("Email", document.getElementById("email").value);
        bodyFormData.append("Telefoonnumer", document.getElementById("phonenumber").value);
        bodyFormData.append("Superuser", this.issuperUser);
        bodyFormData.append("Password", document.getElementById("password").value);
        bodyFormData.append("oauth", localStorage.getItem("token"));
        await axios
          .post("/api/auth/createNewUser", bodyFormData)
          .then(
            (Response) =>
              (this.created = Response.data.userCreated)
          );
        if (this.created) {
          alert("Account is succesvol aangemaakt!")
          this.$router.replace({
            name: "dashboard",
           
          });
        } 
        else {
          document.getElementById("error").style.display = "flex";
          this.errormessage = "U heeft geen rechten om een nieuw account aan te maken.";
        }
      }
    }
  },
  
  metaInfo: {
    title: "New user - Chengeta wildlife",
    meta: [
      {
        property: "og:title",
        content: "New user - Chengeta wildlife",
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
  height: 454px;
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
  margin-top: 2%;
  align-items: center;
  margin-left: auto;
  margin-right: auto;
  margin-bottom: auto;
  flex-direction: column;
}
.login-container2 h2{
  color: #000000;
  font-size: 1.2em;
}
.login-textinput {
  margin-bottom: var(--dl-space-space-unit);
  padding-bottom: var(--dl-space-space-halfunit);
  color: black;
  margin-bottom: 0px;
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
