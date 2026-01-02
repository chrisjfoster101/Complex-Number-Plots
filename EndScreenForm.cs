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
    public partial class EndScreenForm : Form
    {
        Revision revisionForm;
        public EndScreenForm(int score, Revision mainForm)
        {
            InitializeComponent();
            label2.Text = $"{score}/10";
            revisionForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            revisionForm.returnToMenu = true;
            Close();
        }
    }
}
