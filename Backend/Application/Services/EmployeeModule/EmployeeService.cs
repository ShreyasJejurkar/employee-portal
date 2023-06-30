using Application.Abstractions;
using Application.Contracts.Employee;
using Application.Services.CommentsModule;

namespace Application.Services.EmployeeModule;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly ICommentService _commentService;

    public EmployeeService(IEmployeeRepository repository, ICommentService commentService)
    {
        _repository = repository;
        _commentService = commentService;
    }

    public void AddEmployee(CreateEmployeeRequest employeeRequest)
    {
        var empDomainModel = employeeRequest.ToEmployee();

        _repository.InsertEmployee(empDomainModel);
    }

    public void DeleteEmployee(int id)
    {
        var commentsForGivenEmployee = _commentService.GetCommentsByEmployeeId(id);

        foreach (var comment in commentsForGivenEmployee)
            _commentService.DeleteComment(comment.CommentId);

        _repository.DeleteEmployee(id);
    }

    public List<EmployeeResponse> GetAllEmployees(EmployeeSearchCriteria searchCriteria = null)
    {
        var result = _repository.GetAll(searchCriteria);
        return result.Select(x => x.ToEmployeeResponse()).ToList();
    }

    public EmployeeResponse GetEmployeeDetailsById(int employeeId)
    {
        var result = _repository.GetById(employeeId);
        return result?.ToEmployeeResponse();
    }

    public void UpdateEmployee(int employeeId, UpdateEmployeeRequest employeeRequest)
    {
        _repository.UpdateEmployee(employeeId, employeeRequest.ToEmployee());
    }
}
