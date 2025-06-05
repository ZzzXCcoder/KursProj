namespace KursProj.Services
{
    public class UploadFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadFileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> Upload(IFormFile file)
        {
            List<string> validExtensions = new List<string> { ".jpg", ".png", ".mp4", ".mov", ".avi", ".mkv" };

            string extention = Path.GetExtension(file.FileName).ToLower();

            if (!validExtensions.Contains(extention))
            {
                return $"Extention is not valid. Allowed extentions: {string.Join(", ", validExtensions)}";
            }

            long size = file.Length;
            if (size > 1024 * 1024 * 1024)
            {
                return "Maximum size can be 1Gb";
            }

            string fileName = Guid.NewGuid().ToString() + extention;
            string uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "..", "Uploads");
            string filePath = Path.Combine(uploadsFolder, fileName);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return filePath;
            }
            catch (Exception ex)
            {
                return $"Error saving file: {ex.Message}";
            }
        }
    }
}