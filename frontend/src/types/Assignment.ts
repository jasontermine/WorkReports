import type { IServerResponse } from "@/types/ServerResponse"

export interface IAssignment {
  uuid: string
  name: string
  startDate: Date
  dueDate: Date
}

export interface IAssignmentResponse extends IServerResponse {
	data: IAssignment[]
}
