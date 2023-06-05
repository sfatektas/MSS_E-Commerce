import axios from "axios";
import { create } from "zustand";

export const basketStore = create((set) => ({
  basketItems: null,
  getBasketItems: async (tokenUsername, tokenRole) => {
    if (localStorage.getItem("user_token") != null) {
      if (tokenUsername && tokenRole == "customer") {
        axios
          .get(`http://api.mssdev.online/api/baskets/${tokenUsername}`, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem("user_token")}`,
            },
          })
          .then((response) => {
            console.log(response.data)
            set({ basketItems: response.data.basketItemsWithInclude });
          })
          .catch((error) => {
            console.error(error);
          });
      }
    }
  },
}));

export const cartSidebarStore = create((set) => ({
  sidebarActive: false,
  setSidebarActive: (prop) => {
    set({ sidebarActive: prop });
  },
}));
