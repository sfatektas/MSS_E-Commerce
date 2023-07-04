import axios from "axios";
import { Base64 } from "js-base64";
import { create } from "zustand";

export const loaderStore = create((set) => ({
  loader: true,
  setLoader: (status) => {
    set({ loader: status });
  },
}));

export const tokenStore = create((set) => ({
  tokenUsername: null,
  tokenId: null,
  tokenRole: null,
  tokenEmail: null,
  tokenExp: null,
  getTokenData: () => {
    if (localStorage.getItem("user_token")) {
      const token = localStorage.getItem("user_token");
      const startIndex = token.indexOf(".");
      const endIndex = token.lastIndexOf(".");
      const filteredToken = token.slice(startIndex, endIndex + 1);
      const trimmedPayload = filteredToken.substring(
        1,
        filteredToken.length - 1
      );
      const decodedPayload = Base64.decode(trimmedPayload);

      let tokenNameId = JSON.parse(decodedPayload).nameid;
      let tokenUserId = JSON.parse(decodedPayload).Id;
      let tokenUserRole = JSON.parse(decodedPayload).role;
      let tokenUserEmail = JSON.parse(decodedPayload).email;
      let tokenUserExp = JSON.parse(decodedPayload).exp;
      set({
        tokenUsername: tokenNameId,
        tokenId: tokenUserId,
        tokenRole: tokenUserRole,
        tokenEmail: tokenUserEmail,
        tokenExp: tokenUserExp,
      });
    }
  },
  clearTokenData: () => {
    localStorage.removeItem("user_token");
    set({
      tokenUsername: null,
      tokenId: null,
      tokenRole: null,
      tokenEmail: null,
      tokenExp: null,
    });
  },
}));

export const generalStore = create((set) => ({
  categories: null,
  options: null,

  getCategories: async () => {
    try {
      const response = await axios.get(
        "http://api.mssdev.online/api/Categories"
      );
      set({ categories: response.data });
    } catch (error) {
      console.error(error);
      throw error;
    }
  },
  getOptions: async () => {
    try {
      const response = await axios.get(
        "http://api.mssdev.online/api/siteoption"
      );
      set({ options: response.data });
      loaderStore.getState().setLoader(false);
      return response.data;
    } catch (error) {
      console.error(error);
      throw error;
    }
  },
}));

export const sliderStore = create((set) => ({
  sliders: null,
  getSliders: async () => {
    axios
      .get(`http://api.mssdev.online/api/Slider`)
      .then((response) => {
        set({ sliders: response.data });
      })
      .catch((error) => {
        console.log(error);
      });
  },
}));
