using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Entities.Common;
using knapsackEvolutionALgorithm.Service.Entities.Functions;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Trains;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace knapsackEvolutionALgorithm.Presentation
{
    public partial class MinimumPointFunctions : Form
    {
        public MinimumPointFunctions()
        {
            InitializeComponent();
        }

        private void MinimumPointFunctions_Load(object sender, EventArgs e)
        {
            LoadImageFunctions();
        }

        private void EarlyPopulationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        #region CustomMethods
        private void LoadImageFunctions()
        {
            var path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            var customPath = Path.Combine(path, "Common\\StaticFiles\\Images");
            FunctionPicture1.ImageLocation = $"{customPath}\\Function1.jpg";
            FunctionPicture1.SizeMode = PictureBoxSizeMode.AutoSize;
            FunctionPicture2.ImageLocation = $"{customPath}\\Function2.jpg";
            FunctionPicture2.SizeMode = PictureBoxSizeMode.AutoSize;
            FunctionPicture3.ImageLocation = $"{customPath}\\Function3.jpg";
            FunctionPicture3.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        #endregion

        private async void Run_Click(object sender, EventArgs e)
        {
            var mainFormGettingStarted = new MinFunGettingStarted
                (
                    int.Parse(MinFuncEarlyPopulationTextBox.Text),
                    int.Parse(MinFuncNumberOfParentsTextBox.Text),
                    int.Parse(MinFuncNumberOfGenerationRepetitionsTextBox.Text),
                    FindFunctionSelected(),
                    FindSelections(),
                    FindStrategies()
                );
            var trainer = new MinPointFunctionTrain(CreateFunctions());
            await trainer.DoTrain(mainFormGettingStarted);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private IList<IFunction> CreateFunctions()
        {
            IFunction function1 = new Function1();
            IFunction function2 = new Function2(int.Parse(aTextBox.Text), int.Parse(bTextBox.Text), int.Parse(cTextBox.Text));
            IFunction function3 = new Function3();
            var functionList = new List<IFunction>();
            functionList.Add(function1);
            functionList.Add(function2);
            functionList.Add(function3);
            return functionList;
        }
        private IList<Selection> FindSelections()
        {
            var selectionList = new List<Selection>();
            if (RouletteWheelCheckBox.Checked)
                selectionList.Add(Selection.RouletteWheel);
            else if(SUSCheckBox.Checked)
                selectionList.Add(Selection.SUS);
            else if (TournamentCheckBox.Checked)
                selectionList.Add(Selection.Tournament);
            return selectionList;
        }
        private IList<Strategy> FindStrategies()
        {
            var strategyList = new List<Strategy>();
            if (OnePerFiveStrategy.Checked)
                strategyList.Add(Strategy.SelfAdaptetion);
            else if (SelfAdaptionCheckBox.Checked)
                strategyList.Add(Strategy.SelfAdaptetion);
            return strategyList;
        }
        private FunctionSelected FindFunctionSelected()
        {
            if (radioFunction1.Checked)
                return FunctionSelected.Function1;
            else if (radioFunction2.Checked)
                return FunctionSelected.Function2;
            else if (radioFunction3.Checked)
                return FunctionSelected.Function3;
            else
                return FunctionSelected.None;

        }
    }
}
