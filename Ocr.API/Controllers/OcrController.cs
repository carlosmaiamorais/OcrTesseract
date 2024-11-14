using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ocr.API.Services;
using Ocr.API.Services.Interfaces;

namespace Ocr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        private readonly IOcrService _ocrService;
        public OcrController(IOcrService ocrService)
        {
            _ocrService = ocrService;
        }

        [HttpPost("image")]        
        public async Task<IActionResult> ExtrairTextoDeImagem(IFormFile file)
        {            
            var resposta = await _ocrService.ExtrairTextoDeImagem(file);
            return Ok(resposta);
        }

        [HttpPost("pdf")]
        public async Task<IActionResult> ExtrairTextoDePdf(IFormFile file)
        {
            var resposta = await _ocrService.ExtrairTextoDePdf(file);
            return Ok(resposta);
        }
    }
}
