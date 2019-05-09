using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Annotations;
using System;
using System.IO;
using System.Text;

namespace PdfHelper
{
    public class PdfExtensions
    {
        public static void Base64ToPdf(string base64string, string filepath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var pdf = new PdfDocument();
            var page = new PdfPage();
            pdf.AddPage(page);

            var gfx = XGraphics.FromPdfPage(page);
            var img = XImage.FromStream(new MemoryStream(Convert.FromBase64String(base64string)));
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            gfx.DrawImage(img, 0, 0, img.PixelWidth, img.PixelHeight);

            pdf.Save(filepath);
        }
    }
}
