using Application;
using Application.Abstractions;
using Domain;

namespace Infrastructure.Implementions;

public class InMemoryCommentsRepository : ICommentsRepository
{
    private static readonly List<Comment> CommentsTable = new();
    private static int _count = 0;

    public Comment GetCommentById(int commentId)
    {
        return CommentsTable.FirstOrDefault(x => x.CommentId == commentId);
    }

    public IEnumerable<Comment> GetCommentsByEmployeeId(int employeeId)
    {
        return CommentsTable.Where(x => x.RecipientEmployeeId == employeeId).ToList();
    }

    public void InsertComment(Comment newComment)
    {
        newComment.CommentId = _count + 1;

        CommentsTable.Add(newComment);

        _count++;
    }

    public void UpdateComment(Comment comment)
    {
        var exisitingComment = CommentsTable.FirstOrDefault(x => x.CommentId == comment.CommentId);

        if (exisitingComment is null) 
        {
            throw new BusinessException("Comment with Id does not exists");
        }

        CommentsTable.SingleOrDefault(x => x.CommentId == comment.CommentId).Text = comment.Text;
    }

    public void DeleteComment(int id)
    {
        CommentsTable.Remove(GetCommentById(id));
    }
}
