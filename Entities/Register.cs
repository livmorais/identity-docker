namespace project
{
    public class Register
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string? Address { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}