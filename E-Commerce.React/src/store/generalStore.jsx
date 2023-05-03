import axios from "axios";
import { Base64 } from "js-base64";
import { create } from "zustand";

export const loaderStore = create((set) => ({
  loader: true,
  setLoader: (status) => {
    set({ loader: status });
  },
}));

export const generalStore = create((set) => ({
  categories: null,
  options: null,

  getCategories: async () => {
    try {
      const response = await axios.get(
        "https://e-commercemss.azurewebsites.net/api/Categories"
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
        "https://e-commercemss.azurewebsites.net/api/siteoption"
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
