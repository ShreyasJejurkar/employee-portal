import axios from "axios";
import { useEffect, useState } from "react";
import { EmployeeRoutes } from "../API/Constants/routes";
import { EmployeeResponse } from "../API/Contracts/EmployeeResponse";
import { Link } from "react-router-dom";
import { SalaryRecurrence } from "../API/Contracts/CreateEmployeeRequest";


const EmployeeList = () => {
    const [employees, setEmployees] = useState<EmployeeResponse[]>([]);

    useEffect(() => {
        getAllEmployees();
    }, []);

    const getAllEmployees = () => {
        axios.get(EmployeeRoutes.GetAllEmployees).then((response) => {
            if (response.status == 200) {
                setEmployees(response.data);
            }
            else {
                alert("Error calling API");
            }
        });
    }

    const handleDelete = (id: number) => {
        axios.delete(EmployeeRoutes.DeleteEmployee(id)).then((response) => {
            if (response.status == 200) {
                alert("Employee deleted");
                getAllEmployees();
            }
            else {
                alert("Error calling API");
            }
        });
    }

    return (
        <>
            <button><Link to={`/employee/create`}>Add employee</Link></button>

            <table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Job Title</th>
                        <th>Salary</th>
                        <th>Department</th>
                        <th>Employee address</th>
                        <th>Operations</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        employees.map((employee) => {
                            return (
                                <tr key={employee.id}>
                                    <td>{employee.id}</td>
                                    <td>{employee.name}</td>
                                    <td>{employee.jobTitle}</td>
                                    <td>{employee.salary.amount + "/" + SalaryRecurrence[employee.salary.salaryRecurrence]}</td>
                                    <td>{employee.departmentName}</td>
                                    <td>{employee.address}</td>
                                    <td><button><Link to={`/employee/${employee.id}`}>View details</Link></button></td>
                                    <td><button onClick={() => handleDelete(employee.id)}>DELETE</button></td>
                                </tr>
                            )
                        })
                    }
                </tbody>
            </table>
        </>
    )
}

export default EmployeeList;