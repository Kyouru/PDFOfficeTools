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

namespace PDFOfficeTools.SubMenu.QuitarPw
{
    public partial class Password : Form
    {
        public string ValorRetorno { get; private set; }

        public Password()
        {
            ValorRetorno = "";
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValorRetorno = tbPassword.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cbVerPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !cbVerPassword.Checked;
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            ValorRetorno = tbPassword.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
