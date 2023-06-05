import axios from "axios";
import { create } from "zustand";

export const favoriteStore = create((set) => ({
  favoriteItems: null,
  getFavoriteItems: async (tokenId, tokenRole) => {
    if (localStorage.getItem("user_token") != null) {
      if (tokenRole == "customer") {
        axios
          .get(`http://api.mssdev.online/api/Users/${tokenId}/favoriteproducts`)
          .then((response) => {
            set({ favoriteItems: response.data });
            console.log(response.data)
          })
          .catch((error) => {
            console.log(error);
            Z;
          });
      }
    }
  },
}));
