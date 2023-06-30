using Domain;

namespace Application.Abstractions;

public interface ICommentsRepository
{
    public Comment GetCommentById(int commentId);
    public void InsertComment(Comment newComment);
    public IEnumerable<Comment> GetCommentsByEmployeeId(int employeeId);
    public void UpdateComment(Comment comment);
    public void DeleteComment(int id);
}
