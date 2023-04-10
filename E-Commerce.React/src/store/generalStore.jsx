import axios from "axios";
import { create } from "zustand";

export const generalStore = create((set) => ({
  loader: true,
  categories: null,
  options: null,
  setLoader: (status) => {
    set({ loader: status });
  },
  getCategories: async () => {
    try {
      const response = await axios
        .get("https://e-commercemss.azurewebsites.net/api/Categories");
      set({ categories: response.data, loader: false });
      return response.data;
    } catch (error) {
      console.error("Kategorileri alma hatası:", error.message);
      throw error;
    }
  },
  getOptions: async () => {
    try {
      const response = await axios
        .get("https://e-commercemss.azurewebsites.net/api/siteoption");
      set({ options: response.data, loader: false  });
      return response.data;
    } catch (error) {
      console.error("Site seçeneklerini alma hatası:", error.message);
      throw error;
    }
  },
}));
