import { create } from "zustand";
import axios from "axios";

export const authStore = create((set) => ({
  authText: null,
  loginStatus: null,

  loginFetch: async (uname, password) => {
    try {
      const response = await axios.post(
        "http://api.mssdev.online/api/Auth/Login",
        {
          username: uname,
          password: password,
        }
      );
      set({
        authText: "Giriş başarılı, yönlendiriliyorsunuz..",
        loginStatus: 200,
      });
      localStorage.setItem("user_token", response.data.token);
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
      const token = localStorage.getItem("user_token");
      const tokenData = {
        tokenString: token,
      };
      const response = await axios.post(
        `http://api.mssdev.online/api/Auth/LogOut`,
        tokenData,
        {
          headers: { Authorization: `Bearer ${token}` },
        }
      );
      localStorage.removeItem("user_token");
      set({
        authText: null,
        loginStatus: null,
      });
      // set({ logoutStatus: response.status });
    } catch (error) {
      //Token localstorage'de kullanıcı eliyle bozulduğu zaman API'den hata dönüyor.
      //Hata olsun ya da olmasın veriler localstorage'den siliniyor.
      localStorage.removeItem("user_token");
      console.log(error);
      // set({ logoutStatus: error.code });
    }
  },
}));
