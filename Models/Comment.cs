using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace onlinetools.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public int SubToolId { get; set; }
        public SubTool SubTool { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Content)
              .HasMaxLength(1000);

            builder.HasOne(e => e.SubTool).WithMany(c => c.Comments);
            builder.HasOne(e => e.User).WithMany(c => c.Comments).OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
