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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void FrmSpl_Load(object sender, EventArgs e)
        {
            timer1.Interval = 4000;
            timer1.Start();
        }

        private void t1_tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }
    }
}
