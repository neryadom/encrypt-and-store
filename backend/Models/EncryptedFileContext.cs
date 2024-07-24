using Microsoft.EntityFrameworkCore;
using backend.Models; // Adjust this to the correct namespace of the EncryptedFile class

namespace Models
{
    public class EncryptedFileContext : DbContext
    {

        public EncryptedFileContext(DbContextOptions<EncryptedFileContext> options)
         : base(options)
        {
        }

        public DbSet<EncryptedFile> EncryptedFiles { get; set; } = null!;
    }
}