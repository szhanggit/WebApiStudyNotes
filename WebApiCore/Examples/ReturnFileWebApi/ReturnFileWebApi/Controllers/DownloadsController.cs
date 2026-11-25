using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReturnFileWebApi.Interface;

namespace ReturnFileWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadsController : ControllerBase
    {
        private readonly IFileService _fileService;
        private const string MimeType = "image/png";
        private const string FileName = "CM-Logo.png";

        /*
         https://code-maze.com/aspnetcore-web-api-return-file/
         https://hifimov.co/videos/37/4E4uDcQYy9w/net-core-downloads/how-to-generate-and-download-excel-file-in-asp-net-core-6-0-web-api
         */

        public DownloadsController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("images-byte")]
        public IActionResult ReturnByteArray()
        {
            var image = _fileService.GetImageAsByteArray();

            return File(image, MimeType, FileName);
        }

        [HttpGet("images-stream")]
        public IActionResult ReturnStream()
        {
            var image = _fileService.GetImageAsStream();

            return File(image, MimeType, FileName);
        }
    }
}
