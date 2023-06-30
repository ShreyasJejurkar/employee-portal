using Application.Contracts.Common;
using Application.Contracts.Employee;
using Application.Services.EmployeeModule;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<EmployeeResponse>> Get(string name = null, string jobTitle = null, double salary = 0, string departmentName = null, string address = null)
    {
        var searchCriteria = new EmployeeSearchCriteria
        {
            Address = address,
            DepartmentName = departmentName,
            JobTitle = jobTitle,
            Name = name,
            Salary = salary
        };

        var result = _service.GetAllEmployees(searchCriteria);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<EmployeeResponse> Get([Required] int id)
    {
        if (id == 0)
        {
            return BadRequest(new { error = "Employee Id cannot be zero." });
        }

        var result = _service.GetEmployeeDetailsById(id);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateEmployee(CreateEmployeeRequest request)
    {
        _service.AddEmployee(request);
        return Ok(new BaseResponse() { IsSuccess = true, Message = "Employee has been created sucessfully." });
    }

    [HttpPut]
    public IActionResult UpdateEmployee([Required] int id, UpdateEmployeeRequest request)
    {
        _service.UpdateEmployee(id, request);
        return Ok(new BaseResponse() { IsSuccess = true, Message = "Employee has been updated sucessfully." });
    }

    [HttpDelete]
    public ActionResult<BaseResponse> DeleteEmployee([Required] int id) 
    {
        _service.DeleteEmployee(id);
        return Ok(new BaseResponse() { IsSuccess = true, Message = "Employee has been deleted sucessfully." });
    }
}
