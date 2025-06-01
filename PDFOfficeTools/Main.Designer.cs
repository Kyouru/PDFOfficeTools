namespace BasicStyle
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnTop = new Panel();
            lbActual = new Label();
            btnMinimizar = new Button();
            btnMaximizar = new Button();
            btnCerrar = new Button();
            pnLeft = new Panel();
            btn3 = new Button();
            btn2 = new Button();
            btn1 = new Button();
            pnIcon = new Panel();
            label1 = new Label();
            pnMain = new Panel();
            pnTop.SuspendLayout();
            pnLeft.SuspendLayout();
            pnIcon.SuspendLayout();
            SuspendLayout();
            // 
            // pnTop
            // 
            pnTop.BackColor = Color.SteelBlue;
            pnTop.Controls.Add(lbActual);
            pnTop.Controls.Add(btnMinimizar);
            pnTop.Controls.Add(btnMaximizar);
            pnTop.Controls.Add(btnCerrar);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(193, 0);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(774, 40);
            pnTop.TabIndex = 1;
            pnTop.MouseDown += pnTop_MouseDown;
            // 
            // lbActual
            // 
            lbActual.AutoSize = true;
            lbActual.Location = new Point(6, 9);
            lbActual.Name = "lbActual";
            lbActual.Size = new Size(0, 23);
            lbActual.TabIndex = 3;
            // 
            // btnMinimizar
            // 
            btnMinimizar.BackColor = Color.Transparent;
            btnMinimizar.Dock = DockStyle.Right;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Image = PDFOfficeTools.Properties.Resources.icons8_minimize_window_50;
            btnMinimizar.Location = new Point(669, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(35, 40);
            btnMinimizar.TabIndex = 2;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnMaximizar
            // 
            btnMaximizar.BackColor = Color.Transparent;
            btnMaximizar.Dock = DockStyle.Right;
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.FlatStyle = FlatStyle.Flat;
            btnMaximizar.Image = PDFOfficeTools.Properties.Resources.icons8_maximize_window_50;
            btnMaximizar.Location = new Point(704, 0);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(35, 40);
            btnMaximizar.TabIndex = 1;
            btnMaximizar.UseVisualStyleBackColor = false;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.Dock = DockStyle.Right;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Image = PDFOfficeTools.Properties.Resources.icons8_close_window_50;
            btnCerrar.Location = new Point(739, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(35, 40);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // pnLeft
            // 
            pnLeft.Controls.Add(btn3);
            pnLeft.Controls.Add(btn2);
            pnLeft.Controls.Add(btn1);
            pnLeft.Controls.Add(pnIcon);
            pnLeft.Dock = DockStyle.Left;
            pnLeft.Location = new Point(0, 0);
            pnLeft.Name = "pnLeft";
            pnLeft.Size = new Size(193, 594);
            pnLeft.TabIndex = 0;
            // 
            // btn3
            // 
            btn3.BackColor = Color.MidnightBlue;
            btn3.Dock = DockStyle.Top;
            btn3.FlatAppearance.BorderSize = 0;
            btn3.FlatStyle = FlatStyle.Flat;
            btn3.ForeColor = Color.White;
            btn3.Location = new Point(0, 265);
            btn3.Name = "btn3";
            btn3.Size = new Size(193, 45);
            btn3.TabIndex = 5;
            btn3.Text = "Quitar Pw PDF";
            btn3.UseVisualStyleBackColor = false;
            btn3.Click += btn3_Click;
            // 
            // btn2
            // 
            btn2.BackColor = Color.MidnightBlue;
            btn2.Dock = DockStyle.Top;
            btn2.FlatAppearance.BorderSize = 0;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.ForeColor = Color.White;
            btn2.Location = new Point(0, 220);
            btn2.Name = "btn2";
            btn2.Size = new Size(193, 45);
            btn2.TabIndex = 4;
            btn2.Text = "Unir PDFs";
            btn2.UseVisualStyleBackColor = false;
            btn2.Click += btn2_Click;
            // 
            // btn1
            // 
            btn1.BackColor = Color.MidnightBlue;
            btn1.Dock = DockStyle.Top;
            btn1.FlatAppearance.BorderSize = 0;
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.ForeColor = Color.White;
            btn1.Location = new Point(0, 175);
            btn1.Name = "btn1";
            btn1.Size = new Size(193, 45);
            btn1.TabIndex = 3;
            btn1.Text = "EML a PDF";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += btn1_Click;
            // 
            // pnIcon
            // 
            pnIcon.BackColor = Color.SteelBlue;
            pnIcon.Controls.Add(label1);
            pnIcon.Dock = DockStyle.Top;
            pnIcon.Location = new Point(0, 0);
            pnIcon.Name = "pnIcon";
            pnIcon.Size = new Size(193, 175);
            pnIcon.TabIndex = 2;
            pnIcon.MouseDown += pnIcon_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 74);
            label1.Name = "label1";
            label1.Size = new Size(118, 23);
            label1.TabIndex = 0;
            label1.Text = "Foto/Icono";
            // 
            // pnMain
            // 
            pnMain.Dock = DockStyle.Fill;
            pnMain.Location = new Point(193, 40);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(774, 554);
            pnMain.TabIndex = 2;
            // 
            // Main
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(967, 594);
            Controls.Add(pnMain);
            Controls.Add(pnTop);
            Controls.Add(pnLeft);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlLight;
            Name = "Main";
            Text = "Form1";
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnLeft.ResumeLayout(false);
            pnIcon.ResumeLayout(false);
            pnIcon.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnTop;
        private Button btnCerrar;
        private Panel pnLeft;
        private Panel pnIcon;
        private Button btnMaximizar;
        private Button btnMinimizar;
        private Panel pnMain;
        private Button btn2;
        private Button btn1;
        private Button btn3;
        private Label lbActual;
        private Label label1;
    }
}
