import { h, resolveComponent } from "vue";
import { createRouter, createWebHashHistory } from "vue-router";

import DefaultLayout from "@/layouts/DefaultLayout";

const routes = [
  {
    path: "/",
    name: "Home",
    component: DefaultLayout,
    redirect: "/dashboard",
    children: [
      {
        path: "/dashboard",
        name: "Dashboard",
        component: () => import("@/views/Dashboard.vue"),
      },
      {
        path: "/theme/colors",
        name: "Colors",
        component: () => import("@/views/theme/Colors.vue"),
      },
      {
        path: "/theme/typography",
        name: "Typography",
        component: () => import("@/views/theme/Typography.vue"),
      },
    ],
  },
  {
    path: "/pages",
    redirect: "/pages/404",
    name: "Pages",
    component: {
      render() {
        return h(resolveComponent("router-view"));
      },
    },
    children: [
      {
        path: "404",
        name: "Page404",
        component: () => import("@/views/pages/Page404"),
      },
      {
        path: "500",
        name: "Page500",
        component: () => import("@/views/pages/Page500"),
      },
      {
        path: "login",
        name: "Login",
        component: () => import("@/views/pages/Login"),
      },
      {
        path: "register",
        name: "Register",
        component: () => import("@/views/pages/Register"),
      },
    ],
  },
];

const router = createRouter({
  history: createWebHashHistory(process.env.BASE_URL),
  routes,
  scrollBehavior() {
    // always scroll to top
    return { top: 0 };
  },
});

export default router;
