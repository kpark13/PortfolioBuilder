using Microsoft.AspNetCore.Hosting;

// Services/UploadedImageService.cs
public class UploadedImageService
{
    private readonly IWebHostEnvironment _env;

    public UploadedImageService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IEnumerable<string> GetUploadedImages()
    {
        var folderPath = Path.Combine(_env.WebRootPath, "uploads");
        if (!Directory.Exists(folderPath))
            return Enumerable.Empty<string>();

        return Directory.GetFiles(folderPath)
            .Select(f => "/uploads/" + Path.GetFileName(f));
    }
}
