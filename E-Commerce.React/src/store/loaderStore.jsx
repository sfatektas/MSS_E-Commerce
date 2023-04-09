import { create } from "zustand";

export const loaderStore = create((set) => ({
  loadingStatus: 0,
  setLoadingStatus: (status) => {
    set({ loadingStatus: status });
  },
}));
