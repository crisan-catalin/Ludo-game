using System.ComponentModel;
using System.Windows.Forms;

namespace Proiect_AppUI.View
{
    public partial class InstructiuniForm : Form
    {
        public InstructiuniForm()
        {
            InitializeComponent();
        }

        private void InstructiuniForm_Closing(object sender, CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
