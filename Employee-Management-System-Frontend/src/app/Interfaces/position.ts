import { Employee } from "./employee"

export interface Position {
    positionId:number
    positionName:string
    positionDescription:string
    hasReportingLineManager:boolean
    hasDepartment:boolean
    employees: Employee[]
}
