using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace knapsackEvolutionALgorithm.Presentation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void KnapsakProblem_Click(object sender, EventArgs e)
        {
             var knapsakProblem = new Form1();
            knapsakProblem.ShowDialog();
        }

        private void MinimumPointFunctionsProblem_Click(object sender, EventArgs e)
        {
            var minimumFunctions = new MinimumPointFunctions();
            minimumFunctions.ShowDialog();
        }
    }
}
