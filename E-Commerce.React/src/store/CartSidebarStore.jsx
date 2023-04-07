import { create } from "zustand";

export const CartSidebarStore = create((set) => ({
  sidebarActive: false,
  setSidebarActive: (prop) => {
    set({ sidebarActive: prop });
  },
}));
