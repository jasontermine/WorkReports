import { defineStore } from 'pinia'
import { base } from '@/domain/api/axios'
import type { IEmployee, IEmployeeResponse } from '@/types/Employee'

const employeeStoreState: IEmployeeResponse = {
  status: 0,
  data: [
    {
      uuid: '',
      firstName: '',
      lastName: '',
      age: 0
    }
  ]
}

export const useEmployeeStore = defineStore('EmployeeStore', {
  state: (): IEmployeeResponse => ({ ...employeeStoreState }),
  actions: {
    fetchEmployeeData(): Promise<IEmployeeResponse> {
      const response = base
        .get<IEmployeeResponse>('/Employee')
        .then((res: any) => {
          this.setEmployeeData(res)

          return res
        })
        .catch((error) => {
          console.error(error)
        })

      return response
    },
    setEmployeeData(data: IEmployeeResponse): void {
      this.status = data.status
      this.data = data.data
    },
    resetEmployee(): void {
      this.$reset()
    }
  },
  getters: {
    getEmployeeData(state): IEmployee[] {
      return state.data
    }
  }
})
