export interface IAssignment {
  uuid: string
  name: string
  startDate: Date
  dueDate: Date
}

export interface IAssignmentResponse {
	status: number
	data: IAssignment[]
}
