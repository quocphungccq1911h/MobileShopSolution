import { h, resolveComponent } from "vue";
import {createRouter, createWebHashHistory} from 'vue-router';

import DefaultLayout from '@/layouts/DefaultLayout'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: DefaultLayout,
        redirect: '/dashboard',
        children: [
            {
                path: '/dashboard',
                name: 'Dashboard',
                component: () => import('./../views/Dashboard.vue'),
            },
        ]
    }
]

const router = createRouter({
    history: createWebHashHistory(process.env.BASE_URL),
    routes,
    scrollBehavior() {
      // always scroll to top
      return { top: 0 }
    },
  })

export default router   