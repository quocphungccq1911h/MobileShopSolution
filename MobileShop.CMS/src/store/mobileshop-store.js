import { createStore } from "vuex";

const COMMON_MODULE = {
    state: {
        check: false,
    },
    mutations: {

    },
    actions: {},
    modules: {},
}

const store = createStore({
    modules: {
        COMMON_MODULE
    }
})

export default store;