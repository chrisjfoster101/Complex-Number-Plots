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
    public partial class GraphPlotter : Form
    {
        public GraphPlotter()
        {
            InitializeComponent();
            SetUpInequalities();
            string equation;
            if (RHS.Text[0] == '-')
            {
                equation = LHS.Text + "+(" + RHS.Text.Substring(1) + ")";
            }
            else
            {
                equation = LHS.Text + "-(" + RHS.Text + ")";
            }
            LociGenerator loci = new LociGenerator(new ComplexNum(double.Parse(XBox.Text), double.Parse(YBox.Text)), double.Parse(SizeBox.Text));
            GraphPlot.Image = loci.Generate(equation, InequalityBox.Text);
        }


        private void SetUpInequalities()
        {
            InequalityBox.Items.Add("=");
            InequalityBox.Items.Add("≤");
            InequalityBox.Items.Add("≥");
            InequalityBox.Items.Add("<");
            InequalityBox.Items.Add(">");
            InequalityBox.SelectedIndex = 0;
        }
        private void PlotButton_Click(object sender, EventArgs e)
        {
            ErrorLabel.Hide();
            LoadingLabel.Visible = true;
            Update();
            string equation;
            if (RHS.Text[0] == '-')
            {
                equation = LHS.Text + "+(" + RHS.Text.Substring(1) + ")";
            }
            else
            {
                equation = LHS.Text + "-(" + RHS.Text + ")";
            }
            LociGenerator loci = new LociGenerator(new ComplexNum(double.Parse(XBox.Text), double.Parse(YBox.Text)), double.Parse(SizeBox.Text));
            try
            {
                GraphPlot.Image = loci.Generate(equation, InequalityBox.Text);
            }
            catch (EquationException)
            {
                ErrorLabel.Text = "Error with your equation";
                ErrorLabel.Show();
            }
            LoadingLabel.Visible = false;
        }
    }
}
