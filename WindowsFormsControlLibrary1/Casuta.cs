using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casuta.UserControl
{
    public partial class Casuta: System.Windows.Forms.UserControl
    {
        public TipCasuta TipCasuta { get; set; }
        public bool EsteOcupata { get; set; }

        public Casuta()
        {
            InitializeComponent();
        }
    }
}
