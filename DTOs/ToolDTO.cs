namespace onlinetools.DTOs
{
    public class ToolDTO
    {
        public class ToolAddDTO
        {
            public required string Name { get; set; }
        }

        public class ToolEditDTO
        {
            public int Id { get; set; }
            public required string Name { get; set; }
        }
    }
}
