using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("rol")]
    public class Role
    {
        [Key]
        [Column("role_id")]
        public int IdRole { get; set; }

        [Column("name_rol")]
        public string? Name { get; set; }
    }
}