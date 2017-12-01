using System;

namespace Proiect_AppUI.Model
{
    public class Zar
    {
        public int AruncaZar
        {
            get { return new Random().Next(1, 7); }
        }
    }
}