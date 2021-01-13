using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Entities.Common;
using knapsackEvolutionALgorithm.Service.Entities.Functions;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Mutations;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Recombinations;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Selections;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Trains;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies.Trains.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace knapsackEvolutionALgorithm.Presentation
{
    public partial class MinimumPointFunctions : Form
    {
        #region Services
        #region Selections
        private MinFuncRouletteWeelSelection _rouletteWeelSelection;
        private MinFuncStochasticSampleSelection _susSelection;
        private MinFuncTournamentSelection _tournamentSelection;
        private MinFuncRandomSelection _randomSelection;
        private MinFuncSelfAdaptionRandomSelection _randomSelfAdaptionSelection;
        private IList<object> _selectionList = new List<object>();
        #endregion

        #region Recombinations
        private MinFuncSingleRecombination _singleRecombination;
        private MinFuncSimpleRecombination _simpleRecombination;
        private MinFuncWholeRecombination _wholeRecombination;
        private IList<object> _reCombinationList = new List<object>();

        #endregion

        #region Mutations
        private MinFuncOnePerFiveMutation _onePerFiveMutation;
        private MinFuncSelfAdaptionMutation _selfAdaptionMutation;
        private IList<object> _mutationList = new List<object>();
        #endregion

        #region Functions
        private Function1 _function1;
        private Function2 _function2;
        private Function3 _function3;
        private IList<object> _functionList = new List<object>();
        #endregion
        #endregion

        #region properties
        private readonly System.Timers.Timer _timer;
        private decimal _timeCount;
        #endregion

        #region Handler
        private ITrainerHandler<MinFunGettingStarted> _trainerHandler;
        private IList<object> _trainerList;
        #endregion
        public MinimumPointFunctions()
        {
            InitializeComponent();
            _trainerList = new List<object>();

            _timer = new System.Timers.Timer();
            _timer.Interval = 10;
            _timer.Elapsed += _timer_Elapsed; ;
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timeCount = int.Parse(ExcutedTimeTextBox.Text);
            _timeCount++;
            if (ExcutedTimeTextBox.InvokeRequired)
            {
                ExcutedTimeTextBox.Invoke(new MethodInvoker(delegate
                {
                    ExcutedTimeTextBox.Text = _timeCount.ToString();
                }));
            }
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
            maximumChildsTextBox.Text = "";
            ExcutedTimeTextBox.Text = "0";

            var mainFormGettingStarted = new MinFunGettingStarted
                (
                    int.Parse(MinFuncEarlyPopulationTextBox.Text),
                    int.Parse(MinFuncNumberOfParentsTextBox.Text),
                    int.Parse(MinFuncNumberOfGenerationRepetitionsTextBox.Text),
                    int.Parse(MinFuncChromosomeLength.Text),
                    double.Parse(sigmaTextBox.Text),
                    int.Parse(KTournamentCheckBox.Text),

                    int.Parse(aTextBox.Text),
                    int.Parse(bTextBox.Text),
                    int.Parse(cTextBox.Text),

                    FindFunctionSelected(),
                    FindSelections(),
                    FindRecombination(),
                    FindMutation()
                ) ;
            InitializeService(mainFormGettingStarted);

            //Process in Handle Traner Process
            //var trainer = new MinPointFunctionTrain(mainFormGettingStarted, new Function1());
            var trainer = new MinPointFunctionTrain(_selectionList, _reCombinationList, _mutationList, _functionList);

            trainer.TryChanged += Trainer_TryChanged;
            trainer.ParentChanged += Trainer_ParentChanged;
            trainer.MaximumChildChanged += Trainer_MaximumChildChanged;

            _timer.Start();
            Run.Enabled = false;
            await trainer.DoTrain(mainFormGettingStarted);
            _timer.Stop();
            MessageBox.Show($"Fitness: {trainer.ExcetedFitness.Fitness}\nTime: {_timeCount / 100}s" +
                $"            \nChoromosome: {PrintnChoromosome(trainer.ExcetedFitness)}");
            Run.Enabled = true;

        }

        private string PrintnChoromosome(MinFuncIndividual individual)
        {
            string generates = "";
            for (int i = 0; i < individual.Generate.Count(); i++)
                generates += $"{individual.Generate[i]} | ";
            return generates;
        }

        private void Trainer_MaximumChildChanged(MinFuncIndividual minFuncIndividual, MutationOrRecombination mutationOrRecombination, int parentIndex, int tryIndex)
        {
            if (maximumChildsTextBox.InvokeRequired)
            {
                maximumChildsTextBox.Invoke(new MethodInvoker(delegate
                {
                    maximumChildsTextBox.Text += $"Choose Fitness: {minFuncIndividual.Fitness} | {mutationOrRecombination} | parent: {parentIndex} | try: {tryIndex}\n";
                }));
            }
        }

        private void Trainer_ParentChanged(int idenx)
        {
            if (ParentChangedTextBox.InvokeRequired)
            {
                ParentChangedTextBox.Invoke(new MethodInvoker(delegate
                {
                    ParentChangedTextBox.Text = (idenx).ToString();
                }));
            }
        }

        private void Trainer_TryChanged(int idenx)
        {
            if (GenerateChangedTextBox.InvokeRequired)
            {
                GenerateChangedTextBox.Invoke(new MethodInvoker(delegate
                {
                    GenerateChangedTextBox.Text = (idenx).ToString();
                }));
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private Selection FindSelections()
        {
            if (RouletteWheelRadiButton.Checked)
                return Selection.RouletteWheel;
            else if (SUSRadioButton.Checked)
                return Selection.SUS;
            else if (TournamentRadioButton.Checked)
                return Selection.Tournament;
            return Selection.None;
        }
        private Mutation FindMutation()
        {
            if (OnePerFiveRadioButton.Checked)
                return Mutation.OnePerFive;
            else if (SelfAdaptionRadioButton.Checked)
                return Mutation.SelfAdaptetion;
            else
                return Mutation.None;
        }
        private Recombination FindRecombination()
        {
            if (singleRecombinationRadioButton.Checked)
                return Recombination.Single;
            else if (SimpleREcombinationRadioButton.Checked)
                return Recombination.Simple;
            else if (WholeRecombinationrRdioButton.Checked)
                return Recombination.Whole;
            return Recombination.None;
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

        private void InitializeService(MinFunGettingStarted gettingStarted)
        {
            #region Selection Init
            _randomSelection = new MinFuncRandomSelection(gettingStarted.EarlyPopulation);
            _randomSelfAdaptionSelection = new MinFuncSelfAdaptionRandomSelection(gettingStarted.EarlyPopulation);
            _rouletteWeelSelection = new MinFuncRouletteWeelSelection();
            _susSelection = new MinFuncStochasticSampleSelection();
            _tournamentSelection = new MinFuncTournamentSelection(gettingStarted.KIndividualTornomantInit);

            _selectionList.Add(_randomSelection);
            _selectionList.Add(_randomSelfAdaptionSelection);
            _selectionList.Add(_rouletteWeelSelection);
            _selectionList.Add(_susSelection);
            _selectionList.Add(_tournamentSelection);
            #endregion
            #region Recombination Init
            _singleRecombination = new MinFuncSingleRecombination(gettingStarted.ChoromosemeLenght, 0.5);
            _simpleRecombination = new MinFuncSimpleRecombination(gettingStarted.ChoromosemeLenght, 0.5);
            _wholeRecombination = new MinFuncWholeRecombination(gettingStarted.ChoromosemeLenght, 0.5);

            _reCombinationList.Add(_singleRecombination);
            _reCombinationList.Add(_simpleRecombination);
            _reCombinationList.Add(_wholeRecombination);
            #endregion
            #region Mutation Init
            _onePerFiveMutation = new MinFuncOnePerFiveMutation(gettingStarted.ChoromosemeLenght, gettingStarted.Sigma);
            _selfAdaptionMutation = new MinFuncSelfAdaptionMutation(gettingStarted.ChoromosemeLenght, gettingStarted.Sigma);

            _mutationList.Add(_onePerFiveMutation);
            _mutationList.Add(_selfAdaptionMutation);
            #endregion
            #region Functions
            _function1 = new Function1(10);
            _function2 = new Function2(gettingStarted.A, gettingStarted.B, gettingStarted.C);
            _function3 = new Function3();

            _functionList.Add(_function1);
            _functionList.Add(_function2);
            _functionList.Add(_function3);
            #endregion
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void maximumChildsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SimpleREcombinationRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
