using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Http;
using PDFOfficeTools.SubMenu.EML2PDF;
using System.Globalization;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;

namespace BasicStyle.SubMenu
{
    public partial class EML2PDF : Form
    {
        public EML2PDF()
        {
            InitializeComponent();
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            // Directorio de logs
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            Directory.CreateDirectory(logDirectory); // Crea la carpeta si no existe

            // Generar nombre del archivo con la fecha de hoy
            string logFileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";
            string logPath = Path.Combine(logDirectory, logFileName);

            StringBuilder resultadoLog = new StringBuilder();
            int cont = 1;
            if (tbListaEml.Text != "")
            {
                inputPath.Text = inputFolder.SelectedPath;
                // Verificar si la carpeta seleccionada no está vacía
                if (Directory.GetFiles(inputPath.Text, "*.eml").Length > 0)
                {
                    // Procesar los archivos EML en la carpeta seleccionada
                    try
                    {
                        string[] filePaths = tbListaEml.Lines;
                        int totalArchivos = filePaths.Length;
                        // Configurar la barra de progreso
                        progressBar.Minimum = 0;
                        progressBar.Maximum = totalArchivos - 1;
                        progressBar.Value = 0;
                        progressBar.Visible = true;
                        foreach (string filePath in filePaths)
                        {
                            btnProcesar.Text = "Procesando " + cont + "/" + (tbListaEml.Lines.Length - 1);
                            if (cont <= progressBar.Maximum)
                            {
                                progressBar.Value = cont;
                                Application.DoEvents(); // Permite actualizar la UI en tiempo real
                            }
                            if (!string.IsNullOrWhiteSpace(filePath))
                            {
                                string trimmedPath = filePath.Trim();
                                bool exists = File.Exists(trimmedPath);
                                bool isEml = Path.GetExtension(trimmedPath).Equals(".eml", StringComparison.OrdinalIgnoreCase);
                                if (isEml)
                                {
                                    convertirEMLaPDF(trimmedPath);
                                }
                                resultadoLog.AppendLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {Path.GetFileName(trimmedPath)}: {(exists ? "Procesado" : "No existe")}");
                                // Actualizar barra de progreso

                            }
                            cont++;
                        }
                        // Guardar el log en el archivo
                        File.AppendAllText(logPath, resultadoLog.ToString() + Environment.NewLine);
                        btnProcesar.Text = "Procesar";
                        progressBar.Visible = false;
                        MessageBox.Show("Proceso completado. Log guardado en:\n" + logPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar los archivos: " + ex.Message);
                        btnProcesar.Text = "Procesar";
                    }
                }
                else
                {
                    // Si no hay archivos EML, mostrar un mensaje de error
                    MessageBox.Show("No se encontraron archivos EML en la carpeta seleccionada.");
                }
            }
        }

        private void btnInputFolder_Click(object sender, EventArgs e)
        {
            inputFolder.Description = "Seleccione una carpeta";
            inputFolder.ShowNewFolderButton = true;
            DialogResult result = inputFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                int count = 0;
                string folderPath = inputFolder.SelectedPath;
                inputPath.Text = folderPath;
                string[] emlFiles = Directory.GetFiles(folderPath, "*.eml");
                tbListaEml.Text = "";
                foreach (string file in emlFiles)
                {
                    tbListaEml.Text += file + Environment.NewLine;
                    count++;
                }
                //MessageBox.Show("Se encontró " + count + " .eml");
            }
        }


        private void convertirEMLaPDF(string rutaEml)
        {
            SelectPdf.GlobalProperties.HtmlEngineFullPath = AppDomain.CurrentDomain.BaseDirectory + "Select.Html.dep";
            string emlPath = rutaEml; // Cambia la ruta según necesites
            string htmlPath = rutaEml.Replace(".eml", ".html");
            string pdfPath = rutaEml.Replace(".eml", ".pdf");

            // Cargar el archivo EML
            var message = MimeMessage.Load(emlPath);

            // Extraer el cuerpo en formato HTML
            StringBuilder htmlBuilder = new StringBuilder();

            // Agregar la cabecera con información
            htmlBuilder.AppendLine("<html><head>");
            htmlBuilder.AppendLine("<style>");
            htmlBuilder.AppendLine("div { margin-left: 20px; font-family: 'Aptos', sans-serif; }");
            htmlBuilder.AppendLine("</style></head><body>");
            htmlBuilder.AppendLine("<div>"); // Contenedor con margen
            htmlBuilder.AppendLine($"<br><strong>De:</strong> {message.From}<br>");
            htmlBuilder.AppendLine($"<strong>Enviado el:</strong> {message.Date.ToString("dddd, dd 'de' MMMM 'de' yyyy HH:mm", new CultureInfo("es-ES"))}<br>");
            htmlBuilder.AppendLine($"<strong>Para:</strong> {message.To}<br>");
            htmlBuilder.AppendLine($"<strong>Asunto:</strong> {message.Subject}<br><hr><br>");
            htmlBuilder.AppendLine("</div>");
            htmlBuilder.AppendLine("</body></html>");

            // Obtener contenido del cuerpo del mensaje
            var textPart = message.HtmlBody ?? message.TextBody;
            if (textPart != null)
            {
                htmlBuilder.AppendLine(textPart);
            }
            htmlBuilder.AppendLine("</body></html>");

            // Procesar imágenes en Base64
            Dictionary<string, string> imagenesBase64 = new Dictionary<string, string>();
            RecorrerPartes(message.Body, imagenesBase64);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlBuilder.ToString());
            var imgNodes = doc.DocumentNode.SelectNodes("//img");
            if (imgNodes != null)
            {
                foreach (HtmlNode imgNode in imgNodes)
                {
                    string src = imgNode.GetAttributeValue("src", "error");
                    String[] parts = src.Split("@");
                    string contentId = parts[0].Replace("<|>", "");
                    contentId = contentId.Replace("cid:", "");
                    //imgNode.SetAttributeValue("src", "data:image/jpeg;base64," + imagenesBase64[contentId]);
                    try
                    {
                        htmlBuilder.Replace(src, "data:image/jpeg;base64," + imagenesBase64[contentId]);
                    }
                    catch
                    {

                    }
                }
            }

            // Reemlazar imágenes encontradas
            foreach (var img in imagenesBase64)
            {
                Console.WriteLine($"<img src='data:image/png;base64,{img}' />");
            }
            //MessageBox.Show(htmlBody);
            if (!string.IsNullOrEmpty(htmlBuilder.ToString()))
            {
                File.WriteAllText(htmlPath, htmlBuilder.ToString());
                HtmlToPdfConverter.ConvertHtmlToPdf(htmlPath, pdfPath);
                File.Delete(htmlPath);
                //PdfDocument pdf = PdfGenerator.GeneratePdf(htmlBody, PdfSharp.PageSize.A4);
                //pdf.Save(pdfPath);
                //Console.WriteLine("Conversión completada: " + htmlPath);
            }
            else
            {
                //Console.WriteLine("El archivo EML no contiene contenido HTML.");
            }
        }
        static void RecorrerPartes(MimeEntity entity, Dictionary<string, string> imagenesBase64)
        {
            if (entity is Multipart multipart)
            {
                foreach (var part in multipart)
                {
                    RecorrerPartes(part, imagenesBase64);
                }
            }
            else if (entity is MimePart mimePart && mimePart.ContentType.MediaType.StartsWith("image"))
            {
                using (var memoryStream = new MemoryStream())
                {
                    mimePart.Content.DecodeTo(memoryStream);
                    string base64String = Convert.ToBase64String(memoryStream.ToArray());
                    String[] parts = mimePart.ContentId.Split("@");
                    string contentId = parts[0].Replace("<|>", "");
                    imagenesBase64.Add(contentId, base64String);
                }
            }
        }

    }

}
