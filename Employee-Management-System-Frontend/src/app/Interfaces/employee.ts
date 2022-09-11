import { ReportingLineManager } from "./reporting-line-manager"

export interface Employee {
    employeeId: number
    employeeNumber: string
    name:string
    surname:string
    birthDate:Date
    salary:number
    position:string
    reportingLineManagerId:number
    reportingLineManager:ReportingLineManager

}
