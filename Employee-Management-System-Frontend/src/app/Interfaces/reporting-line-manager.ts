import { Employee } from "./employee";

export interface ReportingLineManager extends Employee{
    reportingLineManagerId:number
    employees: Employee[]
}
