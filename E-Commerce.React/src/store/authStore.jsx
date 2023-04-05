import { create } from "zustand";
import axios from "axios";

export const authStore = create((set) => ({
  user: null,
  loginStatus: null,

  loginFetch: async (uname, password) => {
    const response = await axios
      .post("https://e-commercemss.azurewebsites.net/api/Auth/Login", {
        username: uname,
        password: password,
      })
      .then((response) => {
        // console.log(response.data.token);
        set({ loginStatus: "Giriş Başarılı, yönlendiriliyorsunuz" });
        localStorage.setItem("TOKEN", response.data.token);
      })
      .catch((error) => {
        set({ loginStatus: error.response.data.Error });
      });
  },
  logout: () => {
    set({ user: null });
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
      // .then((response) => {
      //   console.log("Çıkış Başarılı");
      //   console.log(response);
      // });
    localStorage.removeItem("TOKEN");
  },
}));
