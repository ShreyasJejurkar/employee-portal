using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Comments;

public class CommentResponse
{
    public int CommentId { get; set; }
    public int RecipientEmployeeId { get; set; }
    public string Text { get; set; }
    public DateTime DateCreated { get; set; }
    public string AuthorName { get; set; }
}