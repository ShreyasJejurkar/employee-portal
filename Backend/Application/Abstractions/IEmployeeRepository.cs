using Application.Contracts.Employee;
using Domain;

namespace Application.Abstractions;

public interface IEmployeeRepository
{
    public IEnumerable<Employee> GetAll(EmployeeSearchCriteria searchCriteria = null);
    public Employee GetById(int id);
    public void InsertEmployee(Employee employee);
    public void UpdateEmployee(int employeeId, Employee employee);
    public void DeleteEmployee(int id);
}
