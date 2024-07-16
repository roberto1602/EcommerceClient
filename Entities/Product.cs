using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int IdProduct { get; set; }

        [Column("name_product")]
        public string? Name { get; set; }

        [Column("description_product")]
        public string? Description{ get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("stock")]
        public int Stock { get; set; }
    }
}
