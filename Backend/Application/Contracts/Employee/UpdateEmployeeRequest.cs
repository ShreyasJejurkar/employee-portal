using Domain;

namespace Application.Contracts.Employee;

public class UpdateEmployeeRequest
{
    public string Name { get; set; }
    public string JobTitle { get; set; }
    public DateTime DateOfJoining { get; set; }
    public string DepartmentName { get; set; }
    public string Address { get; set; }
    public Salary Salary { get; set; } = new();
}
