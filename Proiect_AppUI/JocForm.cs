using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_AppUI
{
    public partial class JocForm : Form
    {
        public JocForm()
        {
            InitializeComponent();
        }


        private void casuta_Enter(object sender, EventArgs e)
        {

        }

        private void aruncaZarulBtn_Click(object sender, EventArgs e)
        {

        }

        private void terminaTuraBtn_Click(object sender, EventArgs e)
        {

        }

        private void casuta_Click(object sender, EventArgs e)
        {

        }

        private void JocForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.None && WindowState == FormWindowState.Maximized &&
                e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }
    }
}
