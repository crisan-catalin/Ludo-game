using System;

namespace Casuta.UserControl
{
    public partial class Casuta : System.Windows.Forms.UserControl
    {
        public bool EsteOcupata { get; set; }
        public int PozitieRosu { get; set; }
        public int PozitieVerde { get; set; }
        public int PozitieAlbastru { get; set; }
        public int PozitieGalben { get; set; }
        public event EventHandler PionCliked;

        public Casuta()
        {
            InitializeComponent();
        }

        protected virtual void OnPionClicked(EventArgs e)
        {
            PionCliked?.Invoke(this, e);
        }

        private void imaginePion_Click(object sender, EventArgs e)
        {
            OnPionClicked(e);
        }
    }
}