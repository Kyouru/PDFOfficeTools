namespace BasicStyle.SubMenu
{
    partial class EML2PDF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            inputFolder = new FolderBrowserDialog();
            inputPath = new TextBox();
            label1 = new Label();
            btnInputFolder = new Button();
            btnProcesar = new Button();
            tbListaEml = new TextBox();
            SuspendLayout();
            // 
            // inputFolder
            // 
            inputFolder.Description = "Seleccione la carpeta donde se encuentren los EMLs";
            // 
            // inputPath
            // 
            inputPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inputPath.Font = new Font("Century Gothic", 9F);
            inputPath.Location = new Point(104, 18);
            inputPath.Name = "inputPath";
            inputPath.Size = new Size(352, 26);
            inputPath.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 18);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 1;
            label1.Text = "Input:";
            // 
            // btnInputFolder
            // 
            btnInputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnInputFolder.FlatStyle = FlatStyle.Flat;
            btnInputFolder.Image = PDFOfficeTools.Properties.Resources.icons8_search_24;
            btnInputFolder.Location = new Point(472, 12);
            btnInputFolder.Name = "btnInputFolder";
            btnInputFolder.Size = new Size(44, 35);
            btnInputFolder.TabIndex = 2;
            btnInputFolder.UseVisualStyleBackColor = true;
            btnInputFolder.Click += btnInputFolder_Click;
            // 
            // btnProcesar
            // 
            btnProcesar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProcesar.FlatStyle = FlatStyle.Flat;
            btnProcesar.Location = new Point(522, 12);
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size(235, 35);
            btnProcesar.TabIndex = 3;
            btnProcesar.Text = "Procesar";
            btnProcesar.UseVisualStyleBackColor = true;
            btnProcesar.Click += btnProcesar_Click;
            // 
            // tbListaEml
            // 
            tbListaEml.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbListaEml.Enabled = false;
            tbListaEml.Font = new Font("Century Gothic", 9F);
            tbListaEml.Location = new Point(33, 68);
            tbListaEml.Multiline = true;
            tbListaEml.Name = "tbListaEml";
            tbListaEml.ScrollBars = ScrollBars.Both;
            tbListaEml.Size = new Size(724, 345);
            tbListaEml.TabIndex = 4;
            tbListaEml.WordWrap = false;
            // 
            // EML2PDF
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(tbListaEml);
            Controls.Add(btnProcesar);
            Controls.Add(btnInputFolder);
            Controls.Add(label1);
            Controls.Add(inputPath);
            Font = new Font("Century Gothic", 12F);
            ForeColor = SystemColors.ControlLight;
            Name = "EML2PDF";
            Text = "Sub1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog inputFolder;
        private TextBox inputPath;
        private Label label1;
        private Button btnInputFolder;
        private Button btnProcesar;
        private TextBox tbListaEml;
    }
}