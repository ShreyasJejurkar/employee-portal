namespace Application.Contracts.Employee;

public class EmployeeSearchCriteria
{
    public string Name { get; set; }
    public string JobTitle { get; set; }
    public DateTime DateOfJoining { get; set; }
    public string DepartmentName { get; set; }
    public string LineManagerName { get; set; }
    public string Address { get; set; }
    public double Salary { get; set; }
}
