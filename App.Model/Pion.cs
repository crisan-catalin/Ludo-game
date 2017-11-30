using System.Drawing;
using System.Windows.Forms;

namespace App.Model
{
    public class Pion
    {
        private int id;
        private Image imagine;
        private int pozitiaCurenta;
        private Casuta.UserControl.Casuta acasa;
        private Casuta.UserControl.Casuta casutaCurenta;

        public Pion(int id, Image imagine, int pozitiaCurenta, Casuta.UserControl.Casuta acasa)
        {
            this.id = id;
            this.imagine = imagine;
            this.pozitiaCurenta = pozitiaCurenta;
            this.acasa = acasa;
            casutaCurenta = acasa;
            casutaCurenta.ImaginePion.Image = imagine;
        }
    }
}