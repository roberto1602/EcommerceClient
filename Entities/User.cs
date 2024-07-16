using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("usuario")]
    public class User
    {
        [Key]
        [Column("usuario_id")]
        public int IdUsuario { get; set; }

        [Column("identification")]
        public string? NumberIdentification { get; set; }

        [Column("username")]
        public string? Username { get; set; }

        [Column("contrasena")]
        public string? Password { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("role_id")]
        public int IdRole { get; set; }
    }
}
