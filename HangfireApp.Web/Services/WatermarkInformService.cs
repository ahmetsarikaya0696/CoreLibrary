using System.Diagnostics;

namespace HangfireApp.Web.Services
{
    public class WatermarkInformService : IWatermarkInformService
    {
        public void Inform(string fileName)
        {
            Debug.WriteLine($"{fileName} adlı resim dosyasına watermark eklendi.");
        }
    }
}
