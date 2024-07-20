<template>
  <VLayout>
    <VNavigationDrawer expand-on-hover rail>
      <VList>
        <VListItem
          prepend-avatar="https://randomuser.me/api/portraits/women/85.jpg"
          subtitle="sandra_a88@gmailcom"
          title="Sandra Adams"
        ></VListItem>
      </VList>

      <VDivider />

      <VList density="compact" nav>
        <VListItem
          @click="router.push({ name: 'Home' })"
          prepend-icon="mdi-home"
          title="Home"
          value="myfiles"
        />
        <VListItem
          @click="router.push({ name: 'WorkReports' })"
          prepend-icon="mdi-file-chart"
          title="Work Reports"
        />
      </VList>
    </VNavigationDrawer>

    <v-main style="height: 250px"></v-main>
  </VLayout>
</template>

<script setup lang="ts">
import router from '@/router'
import { VDivider, VLayout, VList, VListItem, VNavigationDrawer } from 'vuetify/components'
</script>

<style scoped></style>
