using E_Commerce.Business.Interfaces.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        readonly IStorage _storage;

        public FilesController(IStorage storage)
        {
            _storage = storage;
        }

        [HttpGet("{path}")]
        public async Task<IActionResult> GetOneFile(string path)
        {

            var fileTupple = _storage.GetFile(path);

            return File(fileTupple.data, $"image/{fileTupple.imagetype}");
        }
        // File Upload olmaması lazım ben kendim service bazında uppload işlemini yapmam gerekli .
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            var guid = Guid.NewGuid().ToString();
            IFormFile file = Request.Form.Files.FirstOrDefault();
            bool isComplate = await _storage.UploadFile(guid, file);
            return StatusCode(201);
        }
    }
}
