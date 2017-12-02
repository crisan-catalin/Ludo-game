using System;
using System.Collections.Generic;
using System.Security.Policy;
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
            InitializeazaPozitieCasute();
            InitializeazaListaDeCasute();
            AdaugaDelegatCasuta();
        }

        private void InitializeazaPozitieCasute()
        {
            acasaA1.SeteazaPozitieCasuta(-1, -1, -1, -6);
            acasaA2.SeteazaPozitieCasuta(-1, -1, -1, -6);
            acasaA3.SeteazaPozitieCasuta(-1, -1, -1, -6);
            acasaA4.SeteazaPozitieCasuta(-1, -1, -1, -6);
            acasaG1.SeteazaPozitieCasuta(-1, -1, -6, -1);
            acasaG2.SeteazaPozitieCasuta(-1, -1, -6, -1);
            acasaG3.SeteazaPozitieCasuta(-1, -1, -6, -1);
            acasaG4.SeteazaPozitieCasuta(-1, -1, -6, -1);
            acasaR1.SeteazaPozitieCasuta(-6, -1, -1, -1);
            acasaR3.SeteazaPozitieCasuta(-6, -1, -1, -1);
            acasaR4.SeteazaPozitieCasuta(-6, -1, -1, -1);
            acasatR2.SeteazaPozitieCasuta(-6, -1, -1, -1);
            acasaV1.SeteazaPozitieCasuta(-1, -6, -1, -1);
            acasaV2.SeteazaPozitieCasuta(-1, -6, -1, -1);
            acasaV3.SeteazaPozitieCasuta(-1, -6, -1, -1);
            acasaV4.SeteazaPozitieCasuta(-1, -6, -1, -1);
            startRosu.SeteazaPozitieCasuta(0, 30, 20, 10);
            casuta1.SeteazaPozitieCasuta(1, 31, 21, 11);
            casuta2.SeteazaPozitieCasuta(2, 32, 22, 12);
            casuta3.SeteazaPozitieCasuta(3, 33, 23, 13);
            casuta4.SeteazaPozitieCasuta(4, 34, 24, 14);
            casuta5.SeteazaPozitieCasuta(5, 35, 25, 15);
            casuta6.SeteazaPozitieCasuta(6, 36, 26, 16);
            casuta7.SeteazaPozitieCasuta(7, 37, 27, 17);
            casuta8.SeteazaPozitieCasuta(8, 38, 28, 18);
            casuta9.SeteazaPozitieCasuta(9, 39, 29, 19);
            startVerde.SeteazaPozitieCasuta(10, 0, 30, 20);
            casuta11.SeteazaPozitieCasuta(11, 1, 31, 21);
            casuta12.SeteazaPozitieCasuta(12, 2, 32, 22);
            casuta13.SeteazaPozitieCasuta(13, 3, 33, 23);
            casuta14.SeteazaPozitieCasuta(14, 4, 34, 24);
            casuta15.SeteazaPozitieCasuta(15, 5, 35, 25);
            casuta16.SeteazaPozitieCasuta(16, 6, 36, 26);
            casuta17.SeteazaPozitieCasuta(17, 7, 37, 27);
            casuta18.SeteazaPozitieCasuta(18, 8, 38, 28);
            casuta19.SeteazaPozitieCasuta(19, 9, 39, 29);
            startGalben.SeteazaPozitieCasuta(20, 10, 0, 30);
            casuta21.SeteazaPozitieCasuta(21, 11, 1, 31);
            casuta22.SeteazaPozitieCasuta(22, 12, 2, 32);
            casuta23.SeteazaPozitieCasuta(23, 13, 3, 33);
            casuta24.SeteazaPozitieCasuta(24, 14, 4, 34);
            casuta25.SeteazaPozitieCasuta(25, 15, 5, 35);
            casuta26.SeteazaPozitieCasuta(26, 16, 6, 36);
            casuta27.SeteazaPozitieCasuta(27, 17, 7, 37);
            casuta28.SeteazaPozitieCasuta(28, 18, 8, 38);
            casuta29.SeteazaPozitieCasuta(29, 19, 9, 39);
            startAlbastru.SeteazaPozitieCasuta(30, 20, 10, 0);
            casuta31.SeteazaPozitieCasuta(31, 21, 11, 1);
            casuta32.SeteazaPozitieCasuta(32, 22, 12, 2);
            casuta33.SeteazaPozitieCasuta(33, 23, 13, 3);
            casuta34.SeteazaPozitieCasuta(34, 24, 14, 4);
            casuta35.SeteazaPozitieCasuta(35, 25, 15, 5);
            casuta36.SeteazaPozitieCasuta(36, 26, 16, 6);
            casuta37.SeteazaPozitieCasuta(37, 27, 17, 7);
            casuta38.SeteazaPozitieCasuta(38, 28, 18, 8);
            casuta39.SeteazaPozitieCasuta(39, 29, 19, 9);
            finishA1.SeteazaPozitieCasuta(-1, -1, -1, 40);
            finishA2.SeteazaPozitieCasuta(-1, -1, -1, 41);
            finishA3.SeteazaPozitieCasuta(-1, -1, -1, 42);
            finishA4.SeteazaPozitieCasuta(-1, -1, -1, 43);
            finishG1.SeteazaPozitieCasuta(-1, -1, 40, -1);
            finishG2.SeteazaPozitieCasuta(-1, -1, 41, -1);
            finishG3.SeteazaPozitieCasuta(-1, -1, 42, -1);
            finishG4.SeteazaPozitieCasuta(-1, -1, 43, -1);
            finishR1.SeteazaPozitieCasuta(40, -1, -1, -1);
            finishR2.SeteazaPozitieCasuta(41, -1, -1, -1);
            finishR3.SeteazaPozitieCasuta(42, -1, -1, -1);
            finishR4.SeteazaPozitieCasuta(43, -1, -1, -1);
            finishV1.SeteazaPozitieCasuta(-1, 40, -1, -1);
            finishV2.SeteazaPozitieCasuta(-1, 41, -1, -1);
            finishV3.SeteazaPozitieCasuta(-1, 42, -1, -1);
            finishV4.SeteazaPozitieCasuta(-1, 43, -1, -1);
        }

        private void InitializeazaListaDeCasute()
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
                casuta.PionMouseLeave += casuta_Leave;
            }
        }

        private void casuta_Click(object sender, EventArgs e)
        {
            var casutaSelectata = sender as Casuta.UserControl.Casuta;
            if (casutaSelectata != null)
            {
                Presenter.IncearcaSaMutiPionDin(casutaSelectata);
            }
        }

        private void casuta_Enter(object sender, EventArgs e)
        {
            var casutaSelectata = sender as Casuta.UserControl.Casuta;
            if (casutaSelectata != null)
            {
                Presenter.IncearcaSaMarcheziUrmatoareaPozitie(casutaSelectata);
            }
        }

        private void casuta_Leave(object sender, EventArgs e)
        {
            var casutaSelectata = sender as Casuta.UserControl.Casuta;
            if (casutaSelectata != null)
            {
                Presenter.IncearcaSaDemarcheziUrmatoareaPozitie(casutaSelectata);
            }
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