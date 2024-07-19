import { defineStore } from 'pinia'
import { base } from '@/domain/api/axios'
import type { IEmployeeAssignment, IEmployeeAssignmentResponse } from '@/types/EmployeeAssignment'

const employeeAssignmentStoreState: IEmployeeAssignmentResponse = {
  status: 0,
  data: [
    {
      id: 0,
      employeeUuid: '',
      assignmentUuid: '',
      hoursWorked: 0,
      recordedAt: ''
    }
  ]
}

export const useEmployeeAssignmentStore = defineStore('EmployeeAssignmentStore', {
  state: (): IEmployeeAssignmentResponse => ({ ...employeeAssignmentStoreState }),
  actions: {
    fetchEmployeeAssignmentData(): Promise<IEmployeeAssignmentResponse> {
      const response = base
        .get<IEmployeeAssignmentResponse>('/EmployeeAssignment')
        .then((res: any) => {
          this.setEmployeeAssignmentData(res)

          return res
        })
        .catch((error) => {
          console.error(error)
        })

      return response
    },
    setEmployeeAssignmentData(data: IEmployeeAssignmentResponse): void {
      this.status = data.status
      this.data = data.data
    },
    resetEmployeeAssignment(): void {
      this.$reset()
    }
  },
  getters: {
    getEmployeeAssignmentData(state): IEmployeeAssignment[] {
      return state.data
    }
  }
})
