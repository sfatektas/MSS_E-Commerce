import { create } from "zustand";
import axios from "axios";
import Moment from "moment";

export const authStore = create((set) => ({
  authText: null,
  loginStatus: null,
  logoutStatus: null,
  loginFetch: async (uname, password) => {
    const response = await axios
      .post("https://e-commercemss.azurewebsites.net/api/Auth/Login", {
        username: uname,
        password: password,
      })
      .then((response) => {
        if (response.status == 200) {
          console.log("Giriş Başarılı");
          set({ authText: "Giriş başarılı, yönlendiriliyorsunuz.." });
          set({ loginStatus: response.status });
          localStorage.setItem("TOKEN", response.data.token);
          localStorage.setItem("EXPIRE DATE", response.data.expireToken);
        } else {
          console.log("Sistem Arızası");
          set({ loginStatus: "null" });
        }
      })
      .catch((error) => {
        set({ authText: error.response.data.Error });
        console.log(error.response.data.Error);
        set({ loginStatus: error.response.status });
      });
  },
  logout: async () => {
    axios
      .get(
        `https://e-commercemss.azurewebsites.net/api/Auth/Logout/${localStorage.getItem(
          "TOKEN"
        )}`,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("TOKEN")}`,
          },
        }
      )
      .then((response) => {
        if (response.status == 204) {
          console.log("Çıkış Başarılı : " + response.status);
          set({ logoutStatus: response.status });
          localStorage.removeItem("TOKEN");
          localStorage.removeItem("EXPIRE DATE");
        }
      })
      .catch((error) => {
        localStorage.removeItem("TOKEN");
        localStorage.removeItem("EXPIRE DATE");
        console.log("Çıkış hatalı");
        console.log(error);
        set({ logoutStatus: error.response });
      });
  },
}));
