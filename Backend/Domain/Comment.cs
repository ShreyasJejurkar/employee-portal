namespace Domain;

public class Comment
{
    public int CommentId { get; set; }
    public int RecipientEmployeeId { get; set; }
    public string Text { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;

    public string AuthorName { get; set; }
}