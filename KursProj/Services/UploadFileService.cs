using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KursProj.Services
{
    public class UploadFileService
    {
        private readonly string _uploadsFolder;

        public UploadFileService(IConfiguration configuration)
        {
            _uploadsFolder = configuration["UploadsPath"];
        }

        public async Task<string> Upload(IFormFile file)
        {
            List<string> validExtensions = new List<string> { ".jpg", ".png", ".mp4", ".mov", ".avi", ".mkv", ".html" };

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
            string filePath = Path.Combine(_uploadsFolder, fileName);

            if (!Directory.Exists(_uploadsFolder))
            {
                Directory.CreateDirectory(_uploadsFolder);
            }

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                // Возвращаем относительный путь для фронта и БД!
                return $"/Uploads/{fileName}";
            }
            catch (Exception ex)
            {
                return $"Error saving file: {ex.Message}";
            }
        }
    }
}