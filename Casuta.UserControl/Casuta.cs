using System;

namespace WindowsFormsControlLibrary1
{
    public partial class Casuta : System.Windows.Forms.UserControl
    {
        public bool EsteOcupata { get; set; }
        public int PozitieRosu { get; private set; }
        public int PozitieVerde { get; private set; }
        public int PozitieAlbastru { get; private set; }
        public int PozitieGalben { get; private set; }
        public event EventHandler PionCliked;
        public event EventHandler PionMouseEnter;
        public event EventHandler PionMouseLeave;

        public Casuta()
        {
            InitializeComponent();
        }

        public void SeteazaPozitieCasuta(int pozitieRosu, int pozitieVerde, int pozitieGalben, int pozitieAlbastru)
        {
            PozitieRosu = pozitieRosu;
            PozitieVerde = pozitieVerde;
            PozitieAlbastru = pozitieAlbastru;
            PozitieGalben = pozitieGalben;
        }

        protected virtual void OnPionClicked(EventArgs e)
        {
            PionCliked?.Invoke(this, e);
        }

        protected virtual void OnPionMouseEnter(EventArgs e)
        {
            PionMouseEnter?.Invoke(this, e);
        }

        protected virtual void OnPionMouseLeave(EventArgs e)
        {
            PionMouseLeave?.Invoke(this,e);
        }

        private void imaginePion_Click(object sender, EventArgs e)
        {
            OnPionClicked(e);
        }

        private void imaginePion_MouseEnter(object sender, EventArgs e)
        {
            OnPionMouseEnter(e);
        }

        private void imaginePion_MouseLeave(object sender, EventArgs e)
        {
            OnPionMouseLeave(e);
        }
    }
}