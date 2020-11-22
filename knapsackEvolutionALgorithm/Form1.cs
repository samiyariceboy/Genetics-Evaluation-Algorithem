using knapsackEvolutionALgorithm.Service.Common;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies;
using System;
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

        private async void Run_Click(object sender, EventArgs e)
        {
            var gettingStarted = new GettingStarted(
                    int.Parse(CapacityTextBox.Text),
                    int.Parse(EarlyPopulationTextBox.Text),
                    int.Parse(NumberOfParentsTextBox.Text),
                    int.Parse(NumberOfGenerationRepetitionsTextBox.Text),
                    ItemsTextBox1.Text.ConvertToItemList()
             );
            var evaluationTrain = new EvaluationTrain(gettingStarted);
            await evaluationTrain.DoTrain();
        }

        private void EarlyPopulationTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
