using Application.Contracts.Comments;
using Domain;

namespace Application.Services.CommentsModule;

public static class CommentExtensions
{
    public static CommentResponse ToCommentResponse(this Comment comment)
    {
        return new CommentResponse
        {
            //AuthorName = comment.Author.Name,
            CommentId = comment.CommentId,
            DateCreated = comment.DateCreated,
            RecipientEmployeeId = comment.RecipientEmployeeId,
            Text = comment.Text
        };
    }

    public static Comment ToComment(this InsertCommentRequest request)
    {
        return new Comment
        {
            AuthorName = request.AuthorName,
            DateCreated = request.DateCreated,
            RecipientEmployeeId = request.RecipientEmployeeId,
            Text = request.Text
        };
    }

    public static Comment ToComment(this UpdateCommentRequest request)
    {
        return new Comment
        {
            CommentId = request.CommentId,
            Text = request.Text
        };
    }
}

