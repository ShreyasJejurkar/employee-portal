using Application.Contracts.Employee;

namespace Application.Services.EmployeeModule;

public interface IEmployeeService
{
    public void AddEmployee(CreateEmployeeRequest employeeRequest);

    public void UpdateEmployee(int employeeId, UpdateEmployeeRequest employeeRequest);

    public void DeleteEmployee(int id);

    public EmployeeResponse GetEmployeeDetailsById(int employeeId);

    public List<EmployeeResponse> GetAllEmployees(EmployeeSearchCriteria searchCriteria = null);
}
