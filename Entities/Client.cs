using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("client")]
    public class Client
    {
        [Key]
        [Column("client_id")]
        public int IdClient { get; set; }

        [Column("number_document")]
        public string? NumberDocument { get; set; }

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("email")]
        public string? Email { get; set; }
    }
}