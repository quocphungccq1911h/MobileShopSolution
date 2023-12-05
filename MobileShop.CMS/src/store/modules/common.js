import {
  TOOGLE_SIDE_BAR,
  UPDATE_SIDEBAR_VISIBLE,
  GET_SIDEBAR_VISIBLE,
  GET_SIDEBAR_UNFORDABLE,
  TOOGLE_UNFORDABLE,
} from "../module-types/common";

export default {
  state: {
    sidebarVisible: true,
    sidebarUnfoldable: false,
  },
  getters: {
    [GET_SIDEBAR_VISIBLE]: state => {
      return state.sidebarVisible;
    },
    [GET_SIDEBAR_UNFORDABLE]: state => {
      return state.sidebarUnfoldable;
    },
  },
  mutations: {
    [TOOGLE_SIDE_BAR](state) {
      state.sidebarVisible = !state.sidebarVisible;
    },
    [TOOGLE_UNFORDABLE](state) {
      state.sidebarUnfoldable = !state.sidebarUnfoldable;
    },
    [UPDATE_SIDEBAR_VISIBLE](state, payload) {
      state.sidebarVisible = payload.value;
    },
  },
  actions: {},
  modules: {},
  namespaced: true,
};
