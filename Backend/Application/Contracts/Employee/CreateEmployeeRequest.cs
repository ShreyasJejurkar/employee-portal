using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Contracts.Employee;

public class CreateEmployeeRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string JobTitle { get; set; }

    [Required]
    public DateTime DateOfJoining { get; set; }

    [Required]
    public string DepartmentName { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public int LineManagerId { get; set; }

    [Required]
    public Salary Salary { get; set; }
}
