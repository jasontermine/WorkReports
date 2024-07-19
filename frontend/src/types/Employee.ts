export interface IEmployee {
  uuid: string
  firstName: string
  lastName: string
  age: number
}

export interface IEmployeeResponse {
	status: number
	data: IEmployee[]
}
