using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    joc.numeJRosuLbl.Text = numeJ1TextField.Text;
                    joc.numeJVerdeLbl.Text = numeJ2TextField.Text;
                    joc.numeJGalbenLbl.Text = "";
                    joc.numeJAlbastruLbl.Text = "";
                    break;
                case 3:
                    joc.numeJRosuLbl.Text = numeJ1TextField.Text;
                    joc.numeJVerdeLbl.Text = numeJ2TextField.Text;
                    joc.numeJGalbenLbl.Text = numeJ3TextField.Text;
                    joc.numeJAlbastruLbl.Text = "";
                    break;
                case 4:
                    joc.numeJRosuLbl.Text = numeJ1TextField.Text;
                    joc.numeJVerdeLbl.Text = numeJ2TextField.Text;
                    joc.numeJGalbenLbl.Text = numeJ3TextField.Text;
                    joc.numeJAlbastruLbl.Text = numeJ4TextField.Text;
                    break;
            }
        }


        private void startBtn_Click(object sender, EventArgs e)
        {
            JocForm joc = new JocForm();

            if (fullscreenChckBox.Checked)
            {
                joc.FormBorderStyle = FormBorderStyle.None;
                joc.WindowState = FormWindowState.Maximized;
                joc.TopMost = true;
            }

            SeteazaNumeJucatori(joc);

            joc.Closed += (s, args) => Close();
            joc.Show();
            Hide();
        }
    }
}
