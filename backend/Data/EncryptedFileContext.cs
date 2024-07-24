using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class EncryptedFileContext : DbContext
    {
        public EncryptedFileContext(DbContextOptions<EncryptedFileContext> options)
            : base(options)
        {
        }

        public DbSet<EncryptedFile> EncryptedFiles { get; set; }
    }
}
