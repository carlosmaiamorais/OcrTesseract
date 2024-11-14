using Freeware;
using Ocr.API.Services.Interfaces;
using Tesseract;

namespace Ocr.API.Services
{
    public class OcrService : IOcrService
    {
        private readonly string tessDataPath = Path.Combine(Directory.GetCurrentDirectory(), "Configurations\\Files");
        private readonly string language = "por";

        public async Task<string> ExtrairTextoDeImagem(IFormFile file)
        {
            try
            {
                using var stream = new System.IO.MemoryStream();
                await file.CopyToAsync(stream);
                var fileBytes = stream.ToArray();

                using var engine = new TesseractEngine(tessDataPath, language, EngineMode.Default);
                using var img = Pix.LoadFromMemory(fileBytes);
                var page = engine.Process(img);
                return page.GetText();
            }
            catch (Exception ex)
            {
                throw;
            }
        }        
        public async Task<string> ExtrairTextoDePdf(IFormFile file)
        {
            try
            {
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                var fileBytes = stream.ToArray();

                //transformar o PDF em imagem
                var imageBytes = PdfToPngBytes(fileBytes);

                using var engine = new TesseractEngine(tessDataPath, language, EngineMode.Default);
                using var img = Pix.LoadFromMemory(imageBytes);
                var page = engine.Process(img);
                return page.GetText();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static byte[] PdfToPngBytes(byte[] file, int dpi = 300)
        {
            try
            {
                return Pdf2Png.Convert(file, 1, dpi); // 1 indica que estamos pegando a primeira página
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.GetBaseException().Message);
            }
        }

    }
}
