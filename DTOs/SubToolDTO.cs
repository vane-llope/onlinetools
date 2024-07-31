namespace onlinetools.DTOs
{
    public class SubToolAddDTO
    {
        public required string Name { get; set; }
        public required string RouteName { get; set; }
        public string Tags { get; set; }
        public int ToolId { get; set; }
    }

    public class SubToolEditDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string RouteName { get; set; }
        public string Tags { get; set; }
        public int ToolId { get; set; }

    }
}
