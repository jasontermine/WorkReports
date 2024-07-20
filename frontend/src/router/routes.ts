import { type RouteRecordRaw } from "vue-router";

export const routes: RouteRecordRaw[] = [
  {
    path: "/",
    name: "Home",
    component: () => import("@/pages/Home.vue"),
  },
  {
    path: "/workReports",
    name: "WorkReports",
    component: () => import("@/pages/WorkReports.vue"),
  },
];
