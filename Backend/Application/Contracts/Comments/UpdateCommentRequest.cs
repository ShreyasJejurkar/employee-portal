using System.ComponentModel.DataAnnotations;

namespace Application.Contracts.Comments;

public class UpdateCommentRequest
{
    [Required]
    public int CommentId { get; set; }

    [Required]
    public string Text { get; set; }
}
