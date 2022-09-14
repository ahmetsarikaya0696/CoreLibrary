using HangfireApp.Web.Services;

namespace HangfireApp.Web.BackgroundJobs
{
    public class FireAndForgetJobs
    {
        public static void EmailSendToUserJob(string to, string subject, string body)
        {
            Hangfire.BackgroundJob.Enqueue<IEmailService>(x => x.SendEmail(to, subject, body));
        }
    }
}
