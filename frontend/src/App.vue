<template>
  <main>
    <WorkTable />
  </main>
</template>

<script setup lang="ts">
import { onMounted } from 'vue';
import { useEmployeeStore } from '@/store/EmployeeStore';
import { useAssignmentStore } from '@/store/AssignmentStore';
import { useEmployeeAssignmentStore } from '@/store/EmployeeAssignmentStore';
import WorkTable from '@/components/WorkTable.vue'

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
