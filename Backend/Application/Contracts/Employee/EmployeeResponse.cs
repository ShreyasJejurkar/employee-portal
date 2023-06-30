using Domain;

namespace Application.Contracts.Employee;

public class EmployeeResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string JobTitle { get; set; }
    public DateTime DateOfJoining { get; set; }
    public string DepartmentName { get; set; }
    public int LineManagerId { get; set; }
    public string Address { get; set; }
    public Salary Salary { get; set; } = new();
}
