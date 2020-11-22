using knapsackEvolutionALgorithm.Service.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace knapsackEvolutionALgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Run_Click(object sender, EventArgs e)
        {
            var common = new GettingStarted(
                    int.Parse(CapacityTextBox.Text),
                    int.Parse(EarlyPopulationTextBox.Text),
                    int.Parse(NumberOfParentsTextBox.Text),
                    int.Parse(NumberOfGenerationRepetitionsTextBox.Text),
                    new List<Item>()
                );
        }
    }
}
