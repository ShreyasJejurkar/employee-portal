using Application.Abstractions;
using Application.Contracts.Comments;
using Application.Services.EmployeeModule;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.CommentsModule;

public class CommentService : ICommentService
{
    private readonly ICommentsRepository _commentsRepository;
    private readonly IServiceProvider _serviceProvider;

    public CommentService(ICommentsRepository commentsRepository, IServiceProvider serviceProvider)
    {
        _commentsRepository = commentsRepository;
        _serviceProvider = serviceProvider;
    }

    public CommentResponse GetCommentDetailsById(int commentId)
    {
        var comment = _commentsRepository.GetCommentById(commentId);
        return comment?.ToCommentResponse();
    }

    public IEnumerable<CommentResponse> GetCommentsByEmployeeId(int employeeId)
    {
        var comment = _commentsRepository.GetCommentsByEmployeeId(employeeId);
        return comment?.Select(x => x?.ToCommentResponse());
    }

    public void InsertComment(InsertCommentRequest newComment)
    {
        var employee = _serviceProvider.GetService<IEmployeeService>().GetEmployeeDetailsById(newComment.RecipientEmployeeId);

        if (employee is null)
        {
            throw new BusinessException("Recipient Employee not found. Check employeeId");
        }

        _commentsRepository.InsertComment(newComment.ToComment());
    }

    public void UpdateComment(UpdateCommentRequest updatedComment)
    {
        _commentsRepository.UpdateComment(updatedComment.ToComment());
    }

    public void DeleteComment(int commentId)
    {
        _commentsRepository.DeleteComment(commentId);
    }
}
