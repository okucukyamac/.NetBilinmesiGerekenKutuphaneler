using HangFire.BackgroundJobs;
using HangFire.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HangFire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            BackgroundJobs.RecurringJobs.ReportingJob();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignUp()
        {
            FireAndForgetJobs.EmailSendToUserJob("1234", "Sitemize Hoşgeldiniz");

            return View();
        }

        public IActionResult PictureSave()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PictureSave(IFormFile picture)
        {
            string newFileName = string.Empty;

            if (picture != null && picture.Length > 0)
            {

                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }

                string jobId = DelayedJobs.AddWaterMarkJob(newFileName, "www.mysite.com");

                BackgroundJobs.ContinuationsJobs.WriteWatermarkStatusJob(jobId, newFileName);

            }

            return View();
        }

    }
}
