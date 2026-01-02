using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms_Implicits
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void LociButton_Click(object sender, EventArgs e)
        {
            Hide();
            Form PlotterForm = new GraphPlotter();
            PlotterForm.ShowDialog();
            Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RevisionButton_Click(object sender, EventArgs e)
        {
            Hide();
            Revision revisionform = new Revision();
            revisionform.ShowDialog();
            Show();
        }
    }
}
