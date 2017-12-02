using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Proiect_AppUI.Presenter;

namespace Proiect_AppUI
{
    public partial class JocForm : Form
    {
        public PioniPresenter Presenter { get; set; }
        public List<Casuta.UserControl.Casuta> Casute { get; private set; }
        public List<string> NumeJucatori { get; set; }
        public int NumarJucatori { get; set; }

        public JocForm()
        {
            InitializeComponent();
            InitializeazaCasutele();
            AdaugaDelegatCasuta();
        }

        private void InitializeazaCasutele()
        {
            Casute = new List<Casuta.UserControl.Casuta>(72)
            {
                acasaR1,
                acasatR2,
                acasaR3,
                acasaR4,
                acasaV1,
                acasaV2,
                acasaV3,
                acasaV4,
                acasaG1,
                acasaG2,
                acasaG3,
                acasaG4,
                acasaA2,
                acasaA1,
                acasaA3,
                acasaA4,
                startAlbastru,
                casuta31,
                casuta32,
                casuta33,
                casuta34,
                casuta35,
                casuta36,
                casuta37,
                casuta38,
                casuta39,
                startRosu,
                casuta1,
                casuta2,
                casuta3,
                casuta4,
                casuta5,
                casuta6,
                casuta7,
                casuta8,
                casuta9,
                startVerde,
                casuta11,
                casuta12,
                casuta13,
                casuta14,
                casuta15,
                casuta16,
                casuta17,
                casuta18,
                casuta19,
                startGalben,
                casuta21,
                casuta22,
                casuta23,
                casuta24,
                casuta25,
                casuta26,
                casuta27,
                casuta28,
                casuta29,
                finishA1,
                finishA2,
                finishA3,
                finishA4,
                finishG1,
                finishG2,
                finishG3,
                finishG4,
                finishV1,
                finishV2,
                finishV3,
                finishV4,
                finishR1,
                finishR2,
                finishR3,
                finishR4
            };
        }

        private void AdaugaDelegatCasuta()
        {
            foreach (var casuta in Casute)
            {
                casuta.PionCliked += casuta_Click;
                casuta.PionMouseEnter += casuta_Enter;
            }
        }

        private void casuta_Click(object sender, EventArgs e)
        {
            var x = sender as Casuta.UserControl.Casuta;
            //Presenter.UserMoved();
        }

        private void casuta_Enter(object sender, EventArgs e)
        {

        }

        private void aruncaZarulBtn_Click(object sender, EventArgs e)
        {
            Presenter.ZarAruncat();
        }

        private void terminaTuraBtn_Click(object sender, EventArgs e)
        {
            Presenter.UrmatorulJucator();
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