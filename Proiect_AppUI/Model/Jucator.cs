using System.Collections.Generic;
using System.Drawing;
using Proiect_AppUI.Properties;

namespace Proiect_AppUI.Model
{
    public class Jucator
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public Culoare Culoare { get; set; }
        public List<Pion> Pioni { get; set; }
        public List<Casuta.UserControl.Casuta> CasuteStart { get; set; }

        public Jucator(int id, string nume, Culoare culoareJucator, List<Casuta.UserControl.Casuta> casuteStart)
        {
            Id = id;
            Nume = nume;
            Culoare = culoareJucator;
            CasuteStart = casuteStart;
            InitializeazaPioni();
        }

        public void InitializeazaPioni()
        {
            Pioni = new List<Pion>(Constants.Constants.NumarPioni);
            var imaginePion = GetImaginePion(Culoare);

            for (int i = 0; i < Constants.Constants.NumarPioni; i++)
            {
                Pioni.Add(new Pion(i, imaginePion, Constants.Constants.PozitieStart, CasuteStart[i]));
            }
        }

        private Image GetImaginePion(Culoare culoareJucator)
        {
            switch (culoareJucator)
            {
                case Culoare.Rosu:
                    return new Bitmap(Resources.pawn_red);
                case Culoare.Verde:
                    return new Bitmap(Resources.pawn_green);
                case Culoare.Albastru:
                    return new Bitmap(Resources.pawn_blue);
                case Culoare.Galben:
                    return new Bitmap(Resources.pawn_yellow);
                default:
                    return null;
            }
        }
    }
}