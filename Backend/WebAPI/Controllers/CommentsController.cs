using Application.Contracts.Common;
using Application.Contracts.Comments;
using Application.Services.CommentsModule;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("{id}")]
    public ActionResult<CommentResponse> Get([Required] int commentId)
    {
        var result = _commentService.GetCommentDetailsById(commentId);
        return Ok(result);
    }

    [HttpGet]
    public ActionResult<List<CommentResponse>> GetCommentsByEmployeeId(int employeeId)
    {
        var result = _commentService.GetCommentsByEmployeeId(employeeId).ToList();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult PostComment([Required] InsertCommentRequest request)
    {
        _commentService.InsertComment(request);
        return Ok(new BaseResponse() { IsSuccess = true, Message = "Comment has been created." });
    }

    [HttpPut]
    public ActionResult UpdateComment([Required] int commentId, [Required] UpdateCommentRequest request)
    {
        request.CommentId = commentId;

        _commentService.UpdateComment(request);
        return Ok(new BaseResponse() { IsSuccess = true, Message = "Comment has been updated." });
    }

    [HttpDelete("{commentId}")]
    public ActionResult DeleteComment([Required] int commentId)
    {
        _commentService.DeleteComment(commentId);
        return Ok(new BaseResponse() { IsSuccess = true, Message = "Comment has been deleted." });
    }
}
