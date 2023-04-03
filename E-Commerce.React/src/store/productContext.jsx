import { create } from "zustand";


export const useJsonState = create((set) => ({
  jsonState: [],
  setJsonState: (json) => set(() => ({ jsonState: json })),
}));
