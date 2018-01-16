using System;
using System.Runtime.CompilerServices;

namespace Proiect_AppUI.Model
{
    public class Zar
    {
        private Random _random;

        public int AruncaZar()
        {
            if (_random == null)
            {
                _random = new Random();
            }

            return _random.Next(1, 7);
        }
    }
}