using System.ComponentModel.DataAnnotations;

namespace Application.Contracts.Comments;

public class InsertCommentRequest
{
    [Required]
    public int RecipientEmployeeId { get; set; }

    [Required]
    public string Text { get; set; }

    [Required]
    public DateTime DateCreated { get; set; } = DateTime.Now;

    [Required]
    public string AuthorName { get; set; }
}
