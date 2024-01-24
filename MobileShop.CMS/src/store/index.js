import { createStore } from "vuex";



import common from '@/store/modules/common';

import { COMMON_MODULE } from "./module-types/common";
import PRODUCT_MODULE from '@/store/modules/product';

const store = createStore({
    modules: {
        PRODUCT_MODULE
    }
});
store.registerModule(COMMON_MODULE, common);

export default store;