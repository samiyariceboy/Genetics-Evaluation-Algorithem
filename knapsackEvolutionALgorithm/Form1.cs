using knapsackEvolutionALgorithm.Service.Common;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies;
using System;
using System.Timers;
using System.Windows.Forms;

namespace knapsackEvolutionALgorithm
{
    public partial class Form1 : Form
    {
        private readonly System.Timers.Timer _timer;
        public Form1()
        {
            InitializeComponent();

            _timer = new System.Timers.Timer();
            _timer.Interval = 100;
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ExcutedTimeTextBox.Text = (int.Parse(ExcutedTimeTextBox.Text) + 1).ToString();
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
            if (Validation())
            { MessageBox.Show("تمامی آیتم های ورودی رو وارد کنید", "", MessageBoxButtons.OK); return; }
            var gettingStarted = new GettingStarted(
                    int.Parse(CapacityTextBox.Text),
                    int.Parse(EarlyPopulationTextBox.Text),
                    int.Parse(NumberOfParentsTextBox.Text),
                    int.Parse(NumberOfGenerationRepetitionsTextBox.Text),
                    ItemsTextBox1.Text.ConvertToItemList()
             );
            var evaluationTrain = new EvaluationTrain(gettingStarted);
            _timer.Start();
            await evaluationTrain.DoTrain();
            _timer.Stop();

            MessageBox.Show($"Fitness: {evaluationTrain.ExcetedFitness}\n");
        }

        private void EarlyPopulationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ExcutedTimeTextBox_Click(object sender, EventArgs e)
        {

        }

        private bool Validation()
        {
            if (CapacityTextBox.Text == "" || EarlyPopulationTextBox.Text == ""
                || NumberOfParentsTextBox.Text == ""
                || NumberOfGenerationRepetitionsTextBox.Text == ""
                || ItemsTextBox1.Text == "")
                return true;
            return false;
        }
    }
}
