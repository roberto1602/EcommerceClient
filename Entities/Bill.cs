using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("bill")]
    public class Bill
    {
        [Key]
        [Column("bill_id")]
        public int BillId { get; set; }

        [Column("client_id")]
        public int IdClient { get; set; }

        [Column("company_name")]
        public string? CompanyName { get; set; }

        [Column("nit")]
        public string? Nit { get; set; }

        [Column("code")]
        public string? Code { get; set; }
    }
}
