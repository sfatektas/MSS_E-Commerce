import { create } from "zustand";

export const loaderStore = create((set) => ({
  isLoading: true,
  setIsLoading: (prop) => {
    set({ isLoading: prop });
  },
}));
