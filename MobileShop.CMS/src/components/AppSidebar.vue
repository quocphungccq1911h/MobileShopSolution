<template>
    <CSidebar 
        position="fixed" 
        :unfoldable="sidebarUnfoldable" 
        :visible="sidebarVisible" 
        @visible-change="updateSideBar">
        <CSidebarBrand>
            <CIcon
                custom-class-name="sidebar-brand-full"
                :icon="logoNegative" 
                :height="35"
                />
            <CIcon
                custom-class-name="sidebar-brand-narrow" 
                :icon="sygnet"
                :height="35"
            />
        </CSidebarBrand>
        <AppSidebarNav />
        <CSidebarToggler 
            class="d-none d-lg-flex"
            @click="toggleUnfoldable"
        />
    </CSidebar>
</template>

<script>

import { computed } from 'vue';
import { useStore, mapMutations } from 'vuex';
import { logoNegative} from "@/assets/brand/logo-negative";
import { sygnet } from '@/assets/brand/sygnet';
import { AppSidebarNav } from './AppSidebarNav';
import { COMMON_MODULE, GET_SIDEBAR_UNFORDABLE, GET_SIDEBAR_VISIBLE, UPDATE_SIDEBAR_VISIBLE, TOOGLE_UNFORDABLE } from "../store/module-types/common";
export default {
    name: 'AppSidebar',
    components: {
        AppSidebarNav
    },
    setup() {
        const store = useStore();
        return {
            logoNegative,
            sygnet,
            sidebarUnfoldable: computed(() => store.getters[`${COMMON_MODULE}/${GET_SIDEBAR_UNFORDABLE}`]),
            sidebarVisible: computed(() => store.getters[`${COMMON_MODULE}/${GET_SIDEBAR_VISIBLE}`]),
        }
        
    },
    methods: {
        ...mapMutations(COMMON_MODULE, [UPDATE_SIDEBAR_VISIBLE, TOOGLE_UNFORDABLE]),
        updateSideBar() {
            this.UPDATE_SIDEBAR_VISIBLE({value: this.sidebarVisible});
        },
        toggleUnfoldable() {
            this.TOOGLE_UNFORDABLE();
        }
    }
}
</script>