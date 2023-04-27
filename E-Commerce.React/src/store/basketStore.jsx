import axios from "axios";
import { Base64 } from "js-base64";
import { create } from "zustand";

export const basketStore = create((set) => ({
  basketItems: null,
  getBasketItems: async () => {
    if (localStorage.getItem("user_token") != null) {
      const token = localStorage.getItem("user_token");
      const startIndex = token.indexOf(".");
      const endIndex = token.lastIndexOf(".");
      const filteredToken = token.slice(startIndex, endIndex + 1);
      const trimmedPayload = filteredToken.substring(
        1,
        filteredToken.length - 1
      );
      const decodedPayload = Base64.decode(trimmedPayload);

      let tokenUserName = JSON.parse(decodedPayload).nameid;
      let userName = tokenUserName;

      if (userName) {
        axios
          .get(
            `https://e-commercemss.azurewebsites.net/api/baskets/${userName}`,
            {
              headers: {
                Authorization: `Bearer ${localStorage.getItem("user_token")}`,
              },
            }
          )
          .then((response) => {
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
