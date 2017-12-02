using System.Drawing;

namespace Proiect_AppUI.Model
{
    public class Pion
    {
        public int Id { get; set; }
        public Image Imagine { get; set; }
        public int PozitiaCurenta { get; set; }
        public Casuta.UserControl.Casuta Acasa { get; }
        public Casuta.UserControl.Casuta CasutaCurenta { get; set; }

        public Pion(int id, Image imagine, int pozitiaCurenta, Casuta.UserControl.Casuta acasa)
        {
            Id = id;
            Imagine = imagine;
            PozitiaCurenta = pozitiaCurenta;
            Acasa = acasa;
            CasutaCurenta = acasa;
            CasutaCurenta.ImaginePion.BackgroundImage = imagine;
            CasutaCurenta.EsteOcupata = true;
        }
    }
}