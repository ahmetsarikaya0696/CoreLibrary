using System.Drawing;

namespace HangfireApp.Web.Services
{
    public class WatermarkService : IWatermarkService
    {
        private readonly IWebHostEnvironment _env;

        public WatermarkService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void ApplyWatermark(string fileName, string waterMarkText)
        {
            string path = Path.Combine(_env.WebRootPath, "pictures", fileName);

            using (var bitmap = Bitmap.FromFile(path))
            {
                using (var tempBitmap = new Bitmap(bitmap.Width, bitmap.Height))
                {
                    using (var grp = Graphics.FromImage(tempBitmap))
                    {
                        grp.DrawImage(bitmap, 0, 0);
                        var font = new Font(FontFamily.GenericMonospace, 25, FontStyle.Bold);
                        var color = Color.FromArgb(0, 0, 0);
                        var brush = new SolidBrush(color);
                        var point = new Point(20, bitmap.Height - 50);

                        grp.DrawString(waterMarkText, font, brush, point);

                        tempBitmap.Save(Path.Combine(_env.WebRootPath, "pictures", "watermarks", fileName));
                    }
                }
            }
        }
    }
}
