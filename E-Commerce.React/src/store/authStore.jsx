import { create } from "zustand";
import axios from "axios";

export const authStore = create((set) => ({
  authText: null,
  loginStatus: null,
  logoutStatus: null,

  loginFetch: async (uname, password) => {
    try {
      const response = await axios.post(
        "https://e-commercemss.azurewebsites.net/api/Auth/Login",
        {
          username: uname,
          password: password,
        }
      );

      if (response.status === 200) {
        console.log("Giriş Başarılı");
        set({
          authText: "Giriş başarılı, yönlendiriliyorsunuz..",
          loginStatus: 200,
        });
        localStorage.setItem("TOKEN", response.data.token);
        localStorage.setItem("EXPIRE DATE", response.data.expireToken);
      } else {
        console.log("Sistem Arızası");
        set({ loginStatus: null });
      }
    } catch (error) {
      console.log(error.response.data.Error);
      set({
        authText: error.response.data.Error,
        loginStatus: error.response.status,
      });
    }
  },

  logout: async () => {
    try {
      const token = localStorage.getItem("TOKEN");
      const response = await axios.get(
        `https://e-commercemss.azurewebsites.net/api/Auth/Logout/${token}`,
        {
          headers: { Authorization: `Bearer ${token}` },
        }
      );

      if (response.status === 204) {
        console.log("Çıkış Başarılı : " + response.status);
        set({ logoutStatus: response.status });
        localStorage.removeItem("TOKEN");
        localStorage.removeItem("EXPIRE DATE");
      }
    } catch (error) {
      console.log("Çıkış hatalı : " + error.response);
      console.log(error);
      set({ logoutStatus: error.response.status });
    }
  },
}));
