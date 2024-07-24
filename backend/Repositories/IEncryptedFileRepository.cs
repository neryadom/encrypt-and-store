using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public interface IEncryptedFileRepository
    {
        Task<IEnumerable<EncryptedFile>> GetFiles();
        Task<EncryptedFile> GetFile(int id);
        Task AddFile(EncryptedFile file);
        Task UpdateFile(EncryptedFile file);
        Task DeleteFile(int id);
    }
}
