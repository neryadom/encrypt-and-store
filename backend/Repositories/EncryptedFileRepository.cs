using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class EncryptedFileRepository : IEncryptedFileRepository
    {
        private readonly EncryptedFileContext _context;

        public EncryptedFileRepository(EncryptedFileContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EncryptedFile>> GetFiles()
        {
            return await _context.EncryptedFiles.ToListAsync();
        }

        public async Task<EncryptedFile> GetFile(int id)
        {
            return await _context.EncryptedFiles.FindAsync(id);
        }

        public async Task AddFile(EncryptedFile file)
        {
            _context.EncryptedFiles.Add(file);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFile(EncryptedFile file)
        {
            _context.Entry(file).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFile(int id)
        {
            var file = await _context.EncryptedFiles.FindAsync(id);
            if (file != null)
            {
                _context.EncryptedFiles.Remove(file);
                await _context.SaveChangesAsync();
            }
        }
    }
}
