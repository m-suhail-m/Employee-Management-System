import { Department } from "./department"
import { Position } from "./position"


export interface Employee {
    employeeId: number
    employeeNumber: string
    name:string
    surname:string
    birthDate:Date
    salary:number
    positionId:number
    position: Position
    departmentId:number
    department?:Department
    reportingLineManagerId:number
    reportingLineManager?:Employee


}
