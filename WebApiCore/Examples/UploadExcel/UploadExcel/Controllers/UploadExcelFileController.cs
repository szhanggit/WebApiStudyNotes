using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadExcel.Helper;
using UploadExcel.Model;

namespace UploadExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadExcelFileController : ControllerBase
    {
        /*
         * web api core upload file with parameters c#
         https://stackoverflow.com/questions/51892706/asp-net-core-web-api-file-upload-and-form-data-multiple-parameter-passing-to-m
         */
        public UploadExcelFileController()
        {

        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public ActionResult UploadFile([FromForm] FileInputModel model)
        {
            if (model == null || model.File == null || model.File.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", model.File.FileName);
            string name = model.FileName;

            using (var stream = new FileStream(path, FileMode.Create))
            {
                var ds = ExcelHelper.ConvertFiletoDataSet(stream);
                model.File.CopyToAsync(stream);
            }

            return Ok();
        }
    }
}
