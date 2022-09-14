import { Employee } from "./employee"

export interface Position {
    positionId:number
    positionName:string
    positionDescription:string
    employees: Employee[]
}
