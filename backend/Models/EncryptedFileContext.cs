using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class EncryptedFileContext : DbContext
    {

        public EncryptedFileContext(DbContextOptions<EncryptedFileContext> options) : base(options)
        {
        }

        public DbSet<EncryptedFile> EncryptedFiles { get; set; } = null!;
    }
}