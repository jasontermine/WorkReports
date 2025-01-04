import type { IServerResponse } from "@/types/ServerResponse"

export interface IEmployee {
  uuid: string
  firstName: string
  lastName: string
  age: number
}

export interface IEmployeeResponse extends IServerResponse {
	data: IEmployee[]
}
