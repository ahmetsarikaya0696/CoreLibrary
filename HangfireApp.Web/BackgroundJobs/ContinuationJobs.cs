using HangfireApp.Web.Services;

namespace HangfireApp.Web.BackgroundJobs
{
    public class ContinuationJobs
    {
        public static void WriteWatermarkStatusJob(string id, string fileName)
        {
            Hangfire.BackgroundJob.ContinueJobWith<IWatermarkInformService>(id, x => x.Inform(fileName));
        }
    }
}
