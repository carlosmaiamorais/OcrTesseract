namespace Ocr.API.Services.Interfaces
{
    public interface IOcrService
    {
        Task<string> ExtrairTextoDeImagem(IFormFile file);
        Task<string> ExtrairTextoDePdf(IFormFile file);
    }
}
