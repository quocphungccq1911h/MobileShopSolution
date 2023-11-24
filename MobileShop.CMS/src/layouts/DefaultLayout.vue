<template>
    <div>
        <AppSidebar />
        <div class="wrapper d-flex flex-column min-vh-100 bg-light">
            <CContainer lg>
            <router-view />
        </CContainer>
        </div>
    </div>
</template>

<script>
import { CContainer } from '@coreui/vue';
import AppSidebar from '@/components/AppSidebar.vue';
import AppHeader from '@/components/AppHeader.vue';
import AppFooter from '@/components/AppFooter.vue';

export default {
    name:  "DefaultLayout",
    components: {
        CContainer,
        AppSidebar,
        AppHeader,
        AppFooter
    }
}
</script>