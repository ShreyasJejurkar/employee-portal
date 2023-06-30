using Application.Contracts.Employee;
using Domain;

namespace Application.Services.EmployeeModule;

public static class EmployeeExtensions
{
    public static Employee ToEmployee(this CreateEmployeeRequest request)
    {
        return new Employee
        { 
            Name = request.Name,
            Address = request.Address,
            DateOfJoining = request.DateOfJoining,
            DepartmentName = request.DepartmentName,
            JobTitle = request.JobTitle,
            Salary = new Salary()
            {
                Amount = request.Salary.Amount,
                SalaryRecurrence = request.Salary.SalaryRecurrence,
            },
            LineManagerId = request.LineManagerId,
        };
    }

    public static EmployeeResponse ToEmployeeResponse(this Employee employee)
    {
        return new EmployeeResponse
        {
            Address = employee.Address,
            DateOfJoining = employee.DateOfJoining,
            DepartmentName = employee.DepartmentName,
            Id = employee.Id,
            JobTitle = employee.JobTitle,
            Name = employee.Name,
            Salary = new Salary()
            {
                Amount = employee.Salary.Amount,
                SalaryRecurrence = employee.Salary.SalaryRecurrence,
            },
            LineManagerId = employee.LineManagerId
        };
    }

    public static Employee ToEmployee(this UpdateEmployeeRequest employee)
    {
        return new Employee
        {
            Address = employee.Address,
            DateOfJoining = employee.DateOfJoining,
            DepartmentName = employee.DepartmentName,
            JobTitle = employee.JobTitle,
            Name = employee.Name,
            Salary = new Salary()
            {
                Amount = employee.Salary.Amount,
                SalaryRecurrence = employee.Salary.SalaryRecurrence
            }
        };
    }
}
