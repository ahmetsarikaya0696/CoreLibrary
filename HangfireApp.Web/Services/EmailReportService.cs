using System.Diagnostics;

namespace HangfireApp.Web.Services
{
    public class EmailReportService : IEmailReportService
    {
        public void ReportEmail()
        {
            Debug.WriteLine("Rapor email olarak gönderildi");
        }
    }
}
