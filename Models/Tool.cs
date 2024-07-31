using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace onlinetools.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<SubTool> SubTools { get; set; }
    }

    public class ToolConfiguration : IEntityTypeConfiguration<Tool>
    {
        public void Configure(EntityTypeBuilder<Tool> builder)
        {
            builder.ToTable("Tools");

            builder.HasKey(x => x.Id);

        }
    }
}
