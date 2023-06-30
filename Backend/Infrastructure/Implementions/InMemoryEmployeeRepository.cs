using Application;
using Application.Abstractions;
using Application.Contracts.Employee;
using Domain;

namespace Infrastructure.Implementions;

public class InMemoryEmployeeRepository : IEmployeeRepository
{
    private static readonly List<Employee> EmployeeTable = new();
    private static int _count = 0;

    public IEnumerable<Employee> GetAll(EmployeeSearchCriteria searchCriteria)
    {
        var query = EmployeeTable.AsQueryable();

        if (searchCriteria.Name is not null)
        {
            query = query.Where(x => x.Name.Contains(searchCriteria.Name, StringComparison.OrdinalIgnoreCase));
        }

        if (searchCriteria.Address is not null)
        {
            query = query.Where(x => x.Address.Contains(searchCriteria.Address));
        }

        if (searchCriteria.DepartmentName is not null)
        {
            query = query.Where(x => x.DepartmentName.Contains(searchCriteria.DepartmentName));
        }

        if (searchCriteria.JobTitle is not null)
        {
            query = query.Where(x => x.JobTitle.Contains(searchCriteria.JobTitle));
        }

        if (searchCriteria.LineManagerName is not null)
        {
            var lineManager = EmployeeTable.FirstOrDefault(x => x.Name == searchCriteria.LineManagerName);

            query = query.Where(x => x.LineManagerId == lineManager.Id);
        }

        if (searchCriteria.Salary > 0)
        {
            query = query.Where(x => x.Salary.Amount == searchCriteria.Salary);
        }

        if (searchCriteria.DateOfJoining != DateTime.MinValue)
        {
            query = query.Where(x => x.DateOfJoining == searchCriteria.DateOfJoining);
        }

        return query.ToList();
    }

    public Employee GetById(int id)
    {
        return EmployeeTable.FirstOrDefault(x => x.Id == id);
    }

    public void InsertEmployee(Employee employee)
    {
        if (EmployeeTable.Count != 0)
        {
            var lineManger = EmployeeTable.FirstOrDefault(x => x.Id == employee.LineManagerId);

            if (lineManger is null)
            {
                throw new BusinessException("Line manager does not exists.");
            }
        }


        employee.Id = _count + 1;

        EmployeeTable.Add(employee);

        _count++;
    }

    public void UpdateEmployee(int employeeId, Employee employee)
    {
        var existingEmploye = EmployeeTable.FirstOrDefault(x => x.Id == employeeId);

        if (existingEmploye is null)
        {
            throw new BusinessException("Employee with ID does not exists");
        }

        EmployeeTable.SingleOrDefault(x => x.Id == employeeId).Name = employee.Name;
        EmployeeTable.SingleOrDefault(x => x.Id == employeeId).Address = employee.Address;
        EmployeeTable.SingleOrDefault(x => x.Id == employeeId).DateOfJoining = employee.DateOfJoining;
        EmployeeTable.SingleOrDefault(x => x.Id == employeeId).DepartmentName = employee.DepartmentName;
    }

    public void DeleteEmployee(int id)
    {
        EmployeeTable.Remove(GetById(id));
    }
}
