import { create } from "zustand";
import axios from "axios";

export const authStore = create((set) => ({
  loginStatus: null,
  logoutStatus: null,
  loginFetch: async (uname, password) => {
    const response = await axios
      .post("https://e-commercemss.azurewebsites.net/api/Auth/Login", {
        username: uname,
        password: password,
      })
      .then((response) => {
        console.log("Giriş Başarılı");
        if (response.status == 200) {
          set({ loginStatus: response.status });
          setTimeout(() => {
            set({ loginStatus: response.status });
            localStorage.setItem("TOKEN", response.data.token);
          }, 2000);
        } else {
          set({ loginStatus: "null" });
        }
      })
      .catch((error) => {
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
        }
      })
      .catch((error) => {
        console.log("Çıkış hatalı");
        console.log(error);
        set({ logoutStatus: error.response });
      });
  },
}));
