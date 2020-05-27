namespace Api.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}