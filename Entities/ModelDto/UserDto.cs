namespace Entities.ModelDto
{
    public class UserDto
    {
        public int IdUsuario { get; set; }
        public string? NumberIdentification { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int IdRole { get; set; }
    }
}
