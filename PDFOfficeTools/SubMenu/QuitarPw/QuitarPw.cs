
using PdfSharp.Pdf.IO;
using System.Text;

namespace BasicStyle.SubMenu
{
    public partial class QuitarPW : Form
    {
        public QuitarPW()
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
            PDFOfficeTools.SubMenu.QuitarPw.Password pwForm = new PDFOfficeTools.SubMenu.QuitarPw.Password();
            pwForm.ShowDialog();
            if (pwForm.ValorRetorno != "")
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
                    if (Directory.GetFiles(inputPath.Text, "*.pdf").Length > 0)
                    {
                        // Procesar los archivos PDF en la carpeta seleccionada
                        try
                        {
                            string[] filePaths = tbListaEml.Lines;
                            foreach (string filePath in filePaths)
                            {
                                btnProcesar.Text = "Procesando " + cont + "/" + (tbListaEml.Lines.Length - 1);
                                if (!string.IsNullOrWhiteSpace(filePath))
                                {
                                    string trimmedPath = filePath.Trim();
                                    bool exists = File.Exists(trimmedPath);
                                    bool isPdf = Path.GetExtension(trimmedPath).Equals(".pdf", StringComparison.OrdinalIgnoreCase);
                                    if (isPdf)
                                    {
                                        quitarPasswordPDF(trimmedPath, pwForm.ValorRetorno);
                                    }
                                    resultadoLog.AppendLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {Path.GetFileName(trimmedPath)}: {(exists ? "Procesado" : "No existe")}");
                                }
                                cont++;
                            }
                            // Guardar el log en el archivo con la fecha actual
                            File.WriteAllText(logPath, resultadoLog.ToString());
                            btnProcesar.Text = "Procesar";
                            MessageBox.Show($"Proceso completado. Log guardado en:\n{logPath}");
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
            else
            {
                MessageBox.Show("Contraseña Vacia.");
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
                string[] emlFiles = Directory.GetFiles(folderPath, "*.pdf");
                tbListaEml.Text = "";
                foreach (string file in emlFiles)
                {
                    tbListaEml.Text += file + Environment.NewLine;
                    count++;
                }
                //MessageBox.Show("Se encontró " + count + " .eml");
            }
        }
        private void quitarPasswordPDF (string rutaPdf, string password)
        {
            string outputFile = rutaPdf;
            try
            {
                PdfSharp.Pdf.PdfDocument document = PdfReader.Open(rutaPdf, password, PdfDocumentOpenMode.Import);

                // Eliminamos la protección estableciendo claves vacías
                /*
                document.SecuritySettings.UserPassword = "";
                document.SecuritySettings.OwnerPassword = "";
                document.SecuritySettings.PermitExtractContent = true;
                document.SecuritySettings.PermitModifyDocument = true;
                document.SecuritySettings.PermitAnnotations = true;
                document.SecuritySettings.PermitFormsFill = true;
                document.SecuritySettings.PermitPrint = true;
                */
                PdfSharp.Pdf.PdfDocument newDocument = new PdfSharp.Pdf.PdfDocument();
                foreach (PdfSharp.Pdf.PdfPage page in document.Pages)
                {
                    newDocument.AddPage(page);
                }

                //newDocument.Save("C:\\Users\\KYOURU-PC\\Downloads\\output.pdf");
                newDocument.Save(outputFile);
                Console.WriteLine("PDF desbloqueado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}
