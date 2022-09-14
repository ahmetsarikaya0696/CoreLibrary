using Hangfire;
using HangfireApp.Web.Services;

namespace HangfireApp.Web.BackgroundJobs
{
    public class RecurringJobs
    {
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate<IEmailReportService>(x => x.ReportEmail(), Cron.Minutely());
        }
    }
}
