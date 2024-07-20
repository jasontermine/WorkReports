import { createRouter, createWebHistory } from 'vue-router';
import { routes } from '@/router/routes';

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
  scrollBehavior(to, _, savedPosition) {
    if (savedPosition) {
      return savedPosition;
    } else if (to.hash && to.hash.substring(0, 7) !== '#state=') {
      return {
        el: to.hash,
      };
    } else {
      return { left: 0, top: 0 };
    }
  },
});

export default router;
