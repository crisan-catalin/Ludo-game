using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Proiect_AppUI.Presenter;
using Proiect_AppUI.Properties;

namespace Proiect_AppUI
{
    public partial class ConfigurareJocForm : Form
    {
        public ConfigurareJocForm()
        {
            InitializeComponent();
        }

        private void nrJucatoriTrckBr_ValueChanged(object sender, EventArgs e)
        {
            int numarJucatori = nrJucatoriTrckBr.Value;
            trackBarLbl.Text = numarJucatori.ToString();
            InitializeazaTextFieldNume();
        }

        private void InitializeazaTextFieldNume()
        {
            switch (nrJucatoriTrckBr.Value)
            {
                case 2:
                    numeJ3TextField.Enabled = false;
                    numeJ4TextField.Enabled = false;
                    numeJ3TextField.BackColor = SystemColors.InactiveBorder;
                    numeJ3TextField.Text = "";
                    numeJ4TextField.BackColor = SystemColors.InactiveBorder;
                    numeJ4TextField.Text = "";
                    break;
                case 3:
                    numeJ3TextField.Enabled = true;
                    numeJ4TextField.Enabled = false;
                    numeJ3TextField.BackColor = Color.White;
                    numeJ3TextField.Text = Resources.placeholder_nume_jucator_galben;
                    numeJ4TextField.BackColor = SystemColors.InactiveBorder;
                    numeJ4TextField.Text = "";
                    break;
                case 4:
                    numeJ3TextField.Enabled = true;
                    numeJ4TextField.Enabled = true;
                    numeJ3TextField.BackColor = Color.White;
                    numeJ3TextField.Text = Resources.placeholder_nume_jucator_galben;
                    numeJ4TextField.BackColor = Color.White;
                    numeJ4TextField.Text = Resources.placeholder_nume_jucator_albastru;
                    break;
            }
        }

        private void SeteazaNumeJucatori(JocForm joc)
        {
            switch (nrJucatoriTrckBr.Value)
            {
                case 2:
                    joc.NumeJucatoriRosu = numeJ1TextField.Text;
                    joc.NumeJucatoriVerde = numeJ2TextField.Text;
                    joc.NumeJucatoriAlbastru = "";
                    joc.NumeJucatoriGalben = "";
                    break;
                case 3:
                    joc.NumeJucatoriRosu = numeJ1TextField.Text;
                    joc.NumeJucatoriVerde = numeJ2TextField.Text;
                    joc.NumeJucatoriGalben = numeJ3TextField.Text;
                    joc.NumeJucatoriAlbastru = "";
                    break;
                case 4:
                    joc.NumeJucatoriRosu = numeJ1TextField.Text;
                    joc.NumeJucatoriVerde = numeJ2TextField.Text;
                    joc.NumeJucatoriGalben = numeJ3TextField.Text;
                    joc.NumeJucatoriAlbastru = numeJ4TextField.Text;
                    break;
            }
        }

        private void SeteazaListaJucatori(JocForm joc)
        {
            joc.NumeJucatori = new List<string>(nrJucatoriTrckBr.Value);
            switch (nrJucatoriTrckBr.Value)
            {
                case 2:
                    joc.NumeJucatori.Add(numeJ1TextField.Text);
                    joc.NumeJucatori.Add(numeJ2TextField.Text);
                    break;
                case 3:
                    joc.NumeJucatori.Add(numeJ1TextField.Text);
                    joc.NumeJucatori.Add(numeJ2TextField.Text);
                    joc.NumeJucatori.Add(numeJ3TextField.Text);
                    break;
                case 4:
                    joc.NumeJucatori.Add(numeJ1TextField.Text);
                    joc.NumeJucatori.Add(numeJ2TextField.Text);
                    joc.NumeJucatori.Add(numeJ3TextField.Text);
                    joc.NumeJucatori.Add(numeJ4TextField.Text);
                    break;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            IncepeJocul();
        }

        private void IncepeJocul()
        {
            JocForm joc = new JocForm();

            if (fullscreenChckBox.Checked)
            {
                joc.FormBorderStyle = FormBorderStyle.None;
                joc.WindowState = FormWindowState.Maximized;
                joc.TopMost = true;
            }

            SeteazaNumeJucatori(joc);
            SeteazaListaJucatori(joc);
            joc.NumarJucatori = nrJucatoriTrckBr.Value;

            new PioniPresenter(joc);

            joc.Closed += (s, args) =>
            {
                var x = s as JocForm;
                if (x != null && x.JocNou)
                {
                    Show();
                }
                else
                {
                    Close();
                }
            };
            joc.Show();
            Hide();
        }
    }
}