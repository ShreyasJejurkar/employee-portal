import axios from "axios";
import { CreateEmployeeRequest, SalaryRecurrence } from "../API/Contracts/CreateEmployeeRequest";
import { EmployeeRoutes } from "../API/Constants/routes";
import { useNavigate } from 'react-router-dom';

const CreateEmployee = () => {
    
    const navigate = useNavigate();
    
    const onFormSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        console.log(e.target);
        console.log('Form submitted');
        
        const createEmployeeRequest: CreateEmployeeRequest = {
            name: e.currentTarget.Name.value,
            jobTitle: e.currentTarget.JobTitle.value,
            departmentName: e.currentTarget.Department.value,
            salary: {
                amount: e.currentTarget.Salary.value,
                salaryRecurrence: Number(e.currentTarget.SalaryRecurrence.value) as SalaryRecurrence
            },
            address: e.currentTarget.Address.value,
            lineManagerId: e.currentTarget.LineManagerId.value,
            dateOfJoining: new Date().toISOString()
        };
        
        axios.post(EmployeeRoutes.CreateEmployee, createEmployeeRequest).then((response) => {
            if(response.status == 200) {
                alert("Employee created");
                navigate("/");
            }
            else {
                alert("Error calling API");
            }
        });
    }

    return (
      <>
        <h1>Create Employee</h1>

        <h2>Enter employee details below</h2>
            <form onSubmit={onFormSubmit}>
                <span>Name : </span><input type="text" name="Name"/><br /><br />
                <span>Job title : </span><input type="text" name="JobTitle" /><br /><br />
                <span>Department : </span><input type="text" name="Department"/><br /><br />
                <span>Salary : </span><input type="number" name="Salary"/>
                <select name="SalaryRecurrence">
                    <option value="1">Annually</option>
                    <option value="0">Monthly</option>
                    </select>
                    <br /><br />
                <span>Address : </span><input type="number" name="Address"/><br /><br />
                <span>Line manager id : </span><input type="number" name="LineManagerId"/><br /><br />
                <button type="submit">Add employee</button>
            </form>
      </>  
    );
}

export default CreateEmployee;