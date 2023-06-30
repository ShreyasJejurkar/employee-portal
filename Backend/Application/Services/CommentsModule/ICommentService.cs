using Application.Contracts.Comments;

namespace Application.Services.CommentsModule;

public interface ICommentService
{
    public CommentResponse GetCommentDetailsById(int commentId);
    public void InsertComment(InsertCommentRequest newComment);
    public IEnumerable<CommentResponse> GetCommentsByEmployeeId(int employeeId);
    public void UpdateComment(UpdateCommentRequest updatedComment);
    public void DeleteComment(int commentId);
}
