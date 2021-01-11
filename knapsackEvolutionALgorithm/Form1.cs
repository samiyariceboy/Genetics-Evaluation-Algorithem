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
        private GettingStarted gettingStarted;

        private decimal _timeCount;
        public Form1()
        {
            InitializeComponent();

            _timer = new System.Timers.Timer();
            _timer.Interval = 10;
            _timer.Elapsed += Timer_Elapsed;
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeCount = int.Parse(ExcutedTimeTextBox.Text);
            _timeCount++;
            if(ExcutedTimeTextBox.InvokeRequired)
            {
                ExcutedTimeTextBox.Invoke(new MethodInvoker(delegate 
                {
                    ExcutedTimeTextBox.Text = _timeCount.ToString();
                }));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ItemsTextBox1.Text = "26,70\n47,78\n21,39\n42,41\n73,37\n43,55\n90,24\n80,85\n56,84\n69,75\n1,56\n73,97\n66,37\n10,77\n58,75\n38,31\n20,\n28,\n65,86\n36,60\n49,67\n64,\n61,\n1,47\n83,55\n29,51\n9,9\n92,\n72,8\n97,86";

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void Run_Click(object sender, EventArgs e)
        {
            maximumChildsTextBox.Text = "";
            ExcutedTimeTextBox.Text = "0";
            if (Validation())
            { MessageBox.Show("تمامی آیتم های ورودی رو وارد کنید", "", MessageBoxButtons.OK); return; }
            gettingStarted = new GettingStarted(
                    int.Parse(CapacityTextBox.Text),
                    int.Parse(EarlyPopulationTextBox.Text),
                    int.Parse(NumberOfParentsTextBox.Text),
                    int.Parse(NumberOfGenerationRepetitionsTextBox.Text),
                    ItemsTextBox1.Text.ConvertToItemList()
             );
            var evaluationTrain = new EvaluationTrain(gettingStarted);
            evaluationTrain.MaximumChildChanged += EvaluationTrain_MaximumChildChanged;
            evaluationTrain.TryChanged += EvaluationTrain_TryChanged;
            evaluationTrain.ParentChanged += EvaluationTrain_ParentChanged;

            _timer.Start();
            Run.Enabled = false;
            await evaluationTrain.DoTrain(gettingStarted);
            _timer.Stop();
            MessageBox.Show($"Fitness: {evaluationTrain.ExcetedFitness}\nTime: {_timeCount/100}s");
            Run.Enabled = true;
        }

        private void EvaluationTrain_ParentChanged(int changed)
        {
            if (ParentChangedTextBox.InvokeRequired)
            {
                ParentChangedTextBox.Invoke(new MethodInvoker(delegate
                {
                    ParentChangedTextBox.Text = (changed).ToString();
                }));
            }
        }

        private void EvaluationTrain_TryChanged(int changed)
        {
            if (GenerateChangedTextBox.InvokeRequired)
            {
                GenerateChangedTextBox.Invoke(new MethodInvoker(delegate
                {
                    GenerateChangedTextBox.Text = (changed).ToString();
                }));
            }
        }

        private void EvaluationTrain_MaximumChildChanged(Individual maximumChild, int parent, int Try)
        {
            if (maximumChildsTextBox.InvokeRequired)
            {
                maximumChildsTextBox.Invoke(new MethodInvoker(delegate
                {
                    maximumChildsTextBox.Text += $"Choose Fitness: {maximumChild.Fitness} | parent: {parent} | try: {Try}\n";
                }));
            }
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

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void maximumChildsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ItemsTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
