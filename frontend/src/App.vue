<template>
  <SideNav class="position-absolute" />

  <RouterView />
</template>

<script setup lang="ts">
import { onMounted } from 'vue';
import { useEmployeeStore } from '@/store/EmployeeStore';
import { useAssignmentStore } from '@/store/AssignmentStore';
import { useEmployeeAssignmentStore } from '@/store/EmployeeAssignmentStore';
import SideNav from '@/components/SideNav.vue'

const employeeStore = useEmployeeStore();
const assignmentStore = useAssignmentStore();
const employeeAssignmenStore = useEmployeeAssignmentStore();

onMounted(() => {
  employeeStore.fetchEmployeeData();
  assignmentStore.fetchAssignmentData();
  employeeAssignmenStore.fetchEmployeeAssignmentData();
});
</script>

<style scoped></style>
