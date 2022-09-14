using HangfireApp.Web.Services;

namespace HangfireApp.Web.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string AddWatermarkJob(string fileName, string watermarkText)
        {
            return Hangfire
                .BackgroundJob
                .Schedule<IWatermarkService>(x => x.ApplyWatermark(fileName, watermarkText), TimeSpan.FromSeconds(30));
        }


    }
}
