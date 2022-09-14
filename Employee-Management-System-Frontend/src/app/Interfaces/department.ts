import { Employee } from "./employee"

export interface Department {
    departmentId:number
    departmentName:string
    departmentDescription:string
    headOfDepartmentId: number
    employees: Employee[]
}
