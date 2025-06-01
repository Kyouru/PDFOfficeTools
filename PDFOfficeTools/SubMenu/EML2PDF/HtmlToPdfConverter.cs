using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFOfficeTools.SubMenu.EML2PDF
{
    class HtmlToPdfConverter
    {
        public static void ConvertHtmlToPdf(string htmlPath, string outputPath)
        {
            string htmlContent = File.ReadAllText(htmlPath);
            HtmlToPdf converter = new HtmlToPdf();
            //PdfDocument doc = converter.ConvertUrl(htmlPath);
            PdfDocument doc = converter.ConvertHtmlString(htmlContent);
            doc.Save(outputPath);
            doc.Close();
        }
    }
}
