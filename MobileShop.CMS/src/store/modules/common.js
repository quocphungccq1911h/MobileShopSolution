import { TOOGLE_SIDE_BAR } from "../module-types/common";

export default {
  state: {
    sidebarVisible: "",
    sidebarUnfoldable: false,
  },
  mutations: {
    [TOOGLE_SIDE_BAR](state) {
      state.sidebarVisible = !state.sidebarVisible;
    },
    toggleUnfoldable(state) {
      state.sidebarUnfoldable = !state.sidebarUnfoldable;
    },
    updateSidebarVisible(state, payload) {
      state.sidebarVisible = payload.value;
    },
  },
  actions: {},
  modules: {},
  namespaced: true,
};
