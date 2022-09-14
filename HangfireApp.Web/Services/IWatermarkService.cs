namespace HangfireApp.Web.Services
{
    public interface IWatermarkService
    {
        void ApplyWatermark(string fileName, string waterMarkText);
    }
}
