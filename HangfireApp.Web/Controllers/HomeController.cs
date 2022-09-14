using HangfireApp.Web.BackgroundJobs;
using HangfireApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HangfireApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IWebHostEnvironment env)
        {
            _logger = logger;
            _configuration = configuration;
            _env = env;
        }

        public IActionResult Index()
        {
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
            // Üye kayıt işlemi bu metotta gerçekleşiyor.
            // Yeni üye olan kullanıcının userId'sini al

            var to = _configuration.GetSection("EmailUserName").Value;
            FireAndForgetJobs.EmailSendToUserJob(to, "Mail", "<h1>Success!</h1>");

            return View();
        }

        public IActionResult PictureSave()
        {
            RecurringJobs.ReportingJob();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PictureSave(PictureSaveVM vm)
        {
            if (ModelState.IsValid)
            {
                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(vm.Image.FileName);
                var path = Path.Combine(_env.WebRootPath, "pictures", newFileName);

                using (var stream = System.IO.File.Create(path))
                {
                    await vm.Image.CopyToAsync(stream);
                }

                string jobId = BackgroundJobs.DelayedJobs.AddWatermarkJob(newFileName, "www.ahmetsarikaya.com");
                BackgroundJobs.ContinuationJobs.WriteWatermarkStatusJob(jobId, newFileName);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}