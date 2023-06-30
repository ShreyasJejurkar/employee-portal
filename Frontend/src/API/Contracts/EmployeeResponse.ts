import { Salary } from "./CreateEmployeeRequest";

export interface EmployeeResponse {
    id: number;
    name: string;
    jobTitle: string;
    dateOfJoining: string;
    departmentName: string;
    lineManagerId: number;
    address: string;
    salary: Salary;
}

export interface CommentResponse {
    commentId: number;
    recipientEmployeeId: number;
    text: string;
    dateCreated: string;
    authorName: string;
}