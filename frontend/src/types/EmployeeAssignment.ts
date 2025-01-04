import type { IServerResponse } from "@/types/ServerResponse"

export interface IEmployeeAssignment {
  id: number
  employeeUuid: string
  assignmentUuid: string
  hoursWorked: number
  recordedAt: string
}

export interface IEmployeeAssignmentResponse extends IServerResponse {
  data: IEmployeeAssignment[]
}
