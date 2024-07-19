import { defineStore } from 'pinia'
import { base } from '@/domain/api/axios'
import type { IAssignment, IAssignmentResponse } from '@/types/Assignment'

const assignmentStoreState: IAssignmentResponse = {
  status: 0,
  data: [
    {
      uuid: "",
      name: '',
      startDate: new Date(),
      dueDate: new Date()
    }
  ]
}

export const useAssignmentStore = defineStore('AssignmentStore', {
  state: (): IAssignmentResponse => ({ ...assignmentStoreState }),
  actions: {
    fetchAssignmentData(): Promise<IAssignmentResponse> {
      const response = base
        .get<IAssignmentResponse>('/Assignment')
        .then((res: any) => {
          this.setAssignmentData(res)

          return res
        })
        .catch((error) => {
          console.error(error)
        })

      return response
    },
    setAssignmentData(data: IAssignmentResponse): void {
      this.status = data.status
      this.data = data.data
    },
    resetAssignment(): void {
      this.$reset()
    }
  },
  getters: {
    getAssignmentData(state): IAssignment[] {
      return state.data
    }
  }
})
