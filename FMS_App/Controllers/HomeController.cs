using FMS_App.Interfaces;
using FMS_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FMS_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUploadFile _uploadFile;

        public HomeController(ILogger<HomeController> logger, IUploadFile uploadFile)
        {
            _logger = logger;
            _uploadFile = uploadFile;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult FileUpload()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> UploadFile(IFormFile file)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}