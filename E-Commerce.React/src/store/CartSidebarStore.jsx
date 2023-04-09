import { create } from "zustand";

export const cartSidebarStore = create((set) => ({
  sidebarActive: false,
  setSidebarActive: (prop) => {
    set({ sidebarActive: prop });
  },
}));
