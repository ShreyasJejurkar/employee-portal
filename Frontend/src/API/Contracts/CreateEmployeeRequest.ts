export interface CreateEmployeeRequest {
    name: string;
    jobTitle: string;
    dateOfJoining: string;
    departmentName: string;
    address: string;
    salary: Salary;
    lineManagerId: number;
}

export interface Salary {
    amount: number;
    salaryRecurrence: SalaryRecurrence;
}

export enum SalaryRecurrence {
    Monthly,
    Annually
}