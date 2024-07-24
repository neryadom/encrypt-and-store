using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptedFileController : ControllerBase
    {
        private readonly IEncryptedFileRepository _repository;

        public EncryptedFileController(IEncryptedFileRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EncryptedFile>>> GetFiles()
        {
            return Ok(await _repository.GetFiles());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EncryptedFile>> GetFile(int id)
        {
            var file = await _repository.GetFile(id);
            if (file == null)
            {
                return NotFound();
            }
            return Ok(file);
        }

        [HttpPost]
        public async Task<ActionResult<EncryptedFile>> PostFile(EncryptedFile file)
        {
            // Encryption logic can be added here
            await _repository.AddFile(file);
            return CreatedAtAction(nameof(GetFile), new { id = file.Id }, file);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFile(int id, EncryptedFile file)
        {
            if (id != file.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateFile(file);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            await _repository.DeleteFile(id);
            return NoContent();
        }
    }
}
    