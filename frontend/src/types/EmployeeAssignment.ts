export interface IEmployeeAssignment {
  id: number
  employeeUuid: string
  assignmentUuid: string
  hoursWorked: number
  recordedAt: string
}

export interface IEmployeeAssignmentResponse {
  status: number
  data: IEmployeeAssignment[]
}
