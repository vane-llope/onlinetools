using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace onlinetools.Models
{
    public class SubTool
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string RouteName { get; set; }
        public string Tags { get; set; }
        public int ToolId { get; set; }
        public Tool Tool { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }

    public class SubToolConfiguration : IEntityTypeConfiguration<SubTool>
    {
        public void Configure(EntityTypeBuilder<SubTool> builder)
        {
            builder.ToTable("SubTools");
            builder.HasKey(x => x.Id);
            builder.HasIndex(p => p.RouteName).IsUnique();
            builder.HasOne(e => e.Tool).WithMany(c => c.SubTools);
        }
    }
}

