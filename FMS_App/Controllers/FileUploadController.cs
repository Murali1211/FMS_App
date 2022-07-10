using FMS_App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FMS_App.Controllers
{
    public class FileUploadController : Controller
    {
        readonly IUploadFile _uploadFile;        
        public FileUploadController(IUploadFile uploadFile)
        {            
            _uploadFile = uploadFile;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]        
        public async Task<ActionResult> Index(IFormFile file)
        {
            try
            {
                if (await _uploadFile.UploadFile(file))
                {
                    ViewBag.Message = "File Upload Successful";
                }
                else
                {
                    ViewBag.Message = "File Upload Failed";
                }
            }
            catch (Exception ex)
            {
                //Log ex
                ViewBag.Message = "File Upload Failed";
            }
            return View();
        }      
        public IActionResult FindText(string fileName, string inputText)
        {
            bool result = _uploadFile.SearchText(fileName, inputText);
            if (result)
            {
                ViewBag.Message = "Word Matched";
            }

            return View();
        }
    }
}
