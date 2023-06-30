import { useParams } from "react-router-dom";
import { CommentsRoutes, EmployeeRoutes } from "../API/Constants/routes";
import axios from "axios";
import { useEffect, useState } from "react";
import { CommentResponse, EmployeeResponse } from "../API/Contracts/EmployeeResponse";
import { SalaryRecurrence } from "../API/Contracts/CreateEmployeeRequest";

const EmployeeDetails = () => {
    const [employee, setEmployee] = useState<EmployeeResponse>();
    const [comments, setComments] = useState<CommentResponse>();
    
    const { id } = useParams();
    
    const getEmployeeDetails = () => {
        
        if (id == null) return;
        
        axios.get(EmployeeRoutes.GetEmployeeById(Number(id))).then((response) => {
            if (response.status == 200) {
                setEmployee(response.data);
            }
            else {
                alert("Error calling API");
            }
        });
    }

    const getCommentsForEmployee = () => {
        
        if (id == null) return;
        
        axios.get(CommentsRoutes.GetCommentsByEmployeeId(Number(id))).then((response) => {
            if (response.status == 200) {
                setComments(response.data);
            }
            else {
                alert("Error calling API");
            }
        });
    }

    
    useEffect(() => {
        getEmployeeDetails();
        getCommentsForEmployee();
    });

    return (
        <>
            <h1>Employee Details</h1>
            <h4>Name : {employee?.name}</h4>
            <h4>Address : {employee?.address}</h4>
            <h4>Job title : {employee?.jobTitle}</h4>
            <h4>Salary : {employee?.salary.amount}</h4>
            <h4>Salary recurrence : {SalaryRecurrence[employee?.salary.salaryRecurrence ?? 0]}</h4>
            <h4>Department name : {employee?.departmentName}</h4>
            <h4>Line manager Id : {employee?.lineManagerId}</h4>
            <h4>Date of joining : {employee?.dateOfJoining}</h4>
        </>
    )
}

export default EmployeeDetails;