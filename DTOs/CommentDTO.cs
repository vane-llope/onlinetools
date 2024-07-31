

using onlinetools.Models;

namespace onlinetools.DTOs
{
    public class CommentDTO
    {
        public required string Content { get; set; }
        public int SubToolId { get; set; }
        public int UserId { get; set; }
    }

    public class CommentSendDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int SubToolId { get; set; }
        public SubTool SubTool { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
