using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Proiect_AppUI
{
    public partial class JocForm : Form
    {
        private List<Casuta.UserControl.Casuta> _casute;

        public JocForm()
        {
            InitializeComponent();
            InitializeazaCasutele();
        }

        private void InitializeazaCasutele()
        {
            _casute = new List<Casuta.UserControl.Casuta>(72)
            {
                casuta1,
                casuta2,
                casuta3,
                casuta4,
                casuta5,
                casuta6,
                casuta7,
                casuta8,
                casuta9,
                casuta10,
                casuta11,
                casuta12,
                casuta13,
                casuta14,
                casuta15,
                casuta16,
                casuta17,
                casuta18,
                casuta19,
                casuta20,
                casuta21,
                casuta22,
                casuta23,
                casuta24,
                casuta25,
                casuta26,
                casuta27,
                casuta28,
                casuta29,
                casuta30,
                casuta31,
                casuta32,
                casuta33,
                casuta34,
                casuta35,
                casuta36,
                casuta37,
                casuta38,
                casuta39,
                casuta40,
                casuta41,
                casuta42,
                casuta43,
                casuta44,
                casuta45,
                casuta46,
                casuta47,
                casuta48,
                casuta49,
                casuta50,
                casuta51,
                casuta52,
                casuta53,
                casuta54,
                casuta55,
                casuta56,
                casuta57,
                casuta58,
                casuta59,
                casuta60,
                casuta61,
                casuta62,
                casuta63,
                casuta64,
                casuta65,
                casuta66,
                casuta67,
                casuta68,
                casuta69,
                casuta70,
                casuta71,
                casuta72
            };

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
