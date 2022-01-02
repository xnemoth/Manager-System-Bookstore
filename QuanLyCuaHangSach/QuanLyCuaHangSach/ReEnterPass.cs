using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class ReEnterPass : Form
    {
        public string pass;
        public ReEnterPass()
        {
            InitializeComponent();
        }

        private void btnrepass_Click(object sender, EventArgs e)
        {
            pass = tbxrepass.Text;
            tbxrepass.Text = "";
            this.Close();
        }

        private void tbxrepass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnrepass.Focus();
        }
    }
}
