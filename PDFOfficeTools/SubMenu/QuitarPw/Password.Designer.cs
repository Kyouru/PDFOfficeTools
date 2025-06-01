namespace PDFOfficeTools.SubMenu.QuitarPw
{
    partial class Password
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
            tbPassword = new TextBox();
            cbVerPassword = new CheckBox();
            btEnter = new Button();
            SuspendLayout();
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.Location = new Point(33, 32);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(214, 27);
            tbPassword.TabIndex = 0;
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.KeyDown += tbPassword_KeyDown;
            // 
            // cbVerPassword
            // 
            cbVerPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbVerPassword.AutoSize = true;
            cbVerPassword.Location = new Point(262, 38);
            cbVerPassword.Name = "cbVerPassword";
            cbVerPassword.Size = new Size(18, 17);
            cbVerPassword.TabIndex = 1;
            cbVerPassword.UseVisualStyleBackColor = true;
            cbVerPassword.CheckedChanged += cbVerPassword_CheckedChanged;
            // 
            // btEnter
            // 
            btEnter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btEnter.Location = new Point(299, 31);
            btEnter.Name = "btEnter";
            btEnter.Size = new Size(64, 29);
            btEnter.TabIndex = 2;
            btEnter.Text = "Enter";
            btEnter.UseVisualStyleBackColor = true;
            btEnter.Click += btEnter_Click;
            // 
            // Password
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(388, 92);
            Controls.Add(btEnter);
            Controls.Add(cbVerPassword);
            Controls.Add(tbPassword);
            Name = "Password";
            Text = "Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbPassword;
        private CheckBox cbVerPassword;
        private Button btEnter;
    }
}