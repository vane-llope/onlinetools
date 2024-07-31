namespace onlinetools.DTOs
{
    public class UserRegisterDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class UserLoginDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class UserResultDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Token { get; set; }
    }

    public class UserEditDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Password { get; set; }
        public required bool IsAdmin { get; set; }
    }

}
