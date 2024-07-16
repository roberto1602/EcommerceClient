using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ContexMain(DbContextOptions<ContexMain> options) : DbContext(options)
    {
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Client> Clients { get; set; }  
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DocumentUpload> DocumentUploads { get; set; }
    }
}
