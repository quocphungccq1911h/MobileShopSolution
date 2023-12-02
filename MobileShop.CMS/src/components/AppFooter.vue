<template>
    <CFooter>
        <div>
            <a href="https://cms-mobileshop.vercel.app/" target="_blank">CMS.MobileShop</a>
            <span class="ms-1">&copy; {{ new Date().getFullYear() }} Demo </span>
        </div>
        <div class="ms-auto">
            <span class="me-1" target="_blank">Powered by</span>
            <a href="https://coreui.io/vue">CoreUI</a>
        </div>
    </CFooter>
</template>

<script>
export default {
    name: 'AppFooter'
}
</script>