using System;

namespace backend.Models
{
    public class EncryptedFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] EncryptedContent { get; set; }
        public string EncryptionKey { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
