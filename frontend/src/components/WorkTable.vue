<template>
  <div class="wrapper">
    <div class="mb-4 d-flex flex-row gap-4">
      <label for="assignment-select">Select Assignment:</label>
      <select id="assignment-select" v-model="selectedAssignmentId">
        <option v-for="assignment in assignments" :key="assignment.uuid" :value="assignment.uuid">
          {{ assignment.name }}
        </option>
      </select>

      <label for="date-range">Select Date Range:</label>
      <input type="date" v-model="startDate" />
      <input type="date" v-model="endDate" />
    </div>

    <div>
      <h2>Regie Rapport für {{ selectedAssignmentName }}</h2>
      <p v-if="startDate && endDate">Periode: {{ formattedStartDate }} bis {{ formattedEndDate }}</p>

      <table class="table">
        <thead>
          <tr>
            <th>Arbeiter</th>
            <th>Datum</th>
            <th>Anzahl Stunden</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="entry in filteredWorkHours" :key="entry.date + entry.employeeName">
            <td>{{ entry.employeeName }}</td>
            <td>{{ entry.date }}</td>
            <td>{{ entry.hours }}</td>
          </tr>
          <tr>
            <td colspan="2"><strong>Total</strong></td>
            <td>
              <strong>{{ totalHours }}</strong>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <br />
    <button id="pdfBtn" class="btn text-light" @click="onDownload(selectedAssignmentName, filteredWorkHours, totalHours)">
      PDF herunterladen
    </button>
  </div>
</template>

<script setup lang="ts">
import { ref, computed, watchEffect } from 'vue'
import { onDownload } from '@/domain/createPDF'
import { formatDate } from '@/domain/helpers'
import { useEmployeeStore } from '@/store/EmployeeStore'
import { useAssignmentStore } from '@/store/AssignmentStore'
import { useEmployeeAssignmentStore } from '@/store/EmployeeAssignmentStore'

const employeeStore = useEmployeeStore()
const assignmentStore = useAssignmentStore()
const employeeAssignmentStore = useEmployeeAssignmentStore()

const employees = computed(() => employeeStore.getEmployeeData)
const assignments = computed(() => assignmentStore.getAssignmentData)
const employeeAssignments = computed(() => employeeAssignmentStore.getEmployeeAssignmentData)

const selectedAssignmentId = ref('')

const startDate = ref('')
const endDate = ref('')

const formattedStartDate = computed(() => (startDate.value ? formatDate(startDate.value) : ''))
const formattedEndDate = computed(() => (endDate.value ? formatDate(endDate.value) : ''))

const selectedAssignmentName = computed(() => {
  const assignment = assignments.value.find((assign) => assign.uuid === selectedAssignmentId.value)
  return assignment ? assignment.name : ''
})

const filteredWorkHours = computed(() => {
  const start = startDate.value ? new Date(startDate.value) : new Date('1970-01-01')
  const end = endDate.value ? new Date(endDate.value) : new Date('2100-01-01')

  return employeeAssignments.value
    .filter((entry) => {
      const entryDate = new Date(entry.recordedAt)
      return (
        entry.assignmentUuid === selectedAssignmentId.value &&
        entryDate >= start &&
        entryDate <= end
      )
    })
    .map((entry) => {
      const employee = employees.value.find((emp) => emp.uuid === entry.employeeUuid)
      return {
        employeeName: employee ? `${employee.firstName} ${employee.lastName}` : 'Unknown',
        date: formatDate(entry.recordedAt),
        hours: entry.hoursWorked
      }
    })
})

const totalHours = computed(() => {
  return filteredWorkHours.value.reduce((sum, entry) => sum + entry.hours, 0)
})

watchEffect(() => {
  if (assignments.value.length > 0 && !selectedAssignmentId.value) {
    selectedAssignmentId.value = assignments.value[0].uuid
  }
})
</script>

<style scoped>
#pdfBtn {
  background-color: #212121;
}

#pdfBtn:hover {
  background-color: #424242;
}
</style>
