using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("document_upload")]
    public class DocumentUpload
    {
        [Key]
        [Column("document_id")]
        public int? IdDocument { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("route")]
        public string? Route { get; set; }
       // public IFormFile? DocumentFile { get; set; }
    }
}
