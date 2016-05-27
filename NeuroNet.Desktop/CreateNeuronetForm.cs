using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NeuroNet.Core;
using NeuroNet.Core.Neuronets;
using NeuroNet.Core.Serialization;
using NeuroNet.Core.Teachers;
using NeuroNet.Core.Training;
using NeuroNet.Core.Training.Algorithms;

namespace NeuroNet.Desktop
{
    public partial class CreateNeuronetForm : Form
    {
        public NeuronetWithInformation NeuronetWithInfo;
        public Teacher Teacher;
        public TrainingSet TrainingSet;
        public TrainingAlgorithm TrainingAlgorithm;

        public CreateNeuronetForm()
        {
            InitializeComponent();
        }

        private int[] ParseHiddenLayerAmounts()
        {
            string amounts = AmountOfHiddenNeuronsSelector.Text;

            return amounts.Split(new[] {',', ';'})
                .Select(int.Parse).ToArray();
        }

        private void CreateNeuronet()
        {
            NeuronetWithInfo = new NeuronetWithInformation()
                           {
                               Neuronet = NTirePerceptron.Create(
                                   (int) (WidthSelector.Value * HeightSelector.Value),
                                   (int) (AmountOfOutputNeuronsSelector.Value),
                                   ParseHiddenLayerAmounts()),
                               ImageSize = new Size((int) WidthSelector.Value, (int) HeightSelector.Value)
                           };
        }

        private double CalculateTrainingSpeed()
        {
            const double minTrainingSpeed = 0.01;
            const double maxTrainingSpeed = 1.0;

            // d in [0.0; 1.0]
            var d = (double)(TrainingSpeedSelector.Value - TrainingSpeedSelector.Minimum) /
                    (TrainingSpeedSelector.Maximum - TrainingSpeedSelector.Minimum);

            return minTrainingSpeed + d * (maxTrainingSpeed - minTrainingSpeed);
        }

        private void CreateTeacher()
        {
            Teacher = new BackpropagationTeacher(NeuronetWithInfo.Neuronet);

            Teacher.As<BackpropagationTeacher>().TeachingSpeed = CalculateTrainingSpeed();
        }

        private Func<Color, double> GetConverter()
        {
            if (DarkDigitSelector.Checked)
            {
                return color => 1.0 - color.GetBrightness();
            }
            else
            {
                return color => color.GetBrightness();
            }
        }

        private void CreateTrainingSet()
        {
            if (PathTextBox.Text == "")
                ChangePath();

            TrainingAlgorithm = new RandomTrainingAlgorithm(Teacher, (int) AgesSelector.Value);

            if (OnePairPerImageSelector.Checked)
            {
                var trainingSet = new OnePairFromOneImageTrainingSet(
                    Teacher,
                    TrainingAlgorithm);

                trainingSet.FillTeachCollection(
                    PathTextBox.Text,
                    (int)AmountOfOutputNeuronsSelector.Value,
                    GetConverter());
                
                TrainingSet = trainingSet;
            }
            else if (ManyPairsPerImageSelector.Checked)
            {
                var trainingSet = new ManyPairFromOneImageTrainingSet(
                    Teacher,
                    TrainingAlgorithm);

                trainingSet.FillTeachCollection(
                    PathTextBox.Text,
                    (int) AmountOfOutputNeuronsSelector.Value,
                    GetConverter(),
                    new Size((int) WidthSelector.Value, (int) HeightSelector.Value),
                    (int) MaxPairPerImageSelector.Value);

                TrainingSet = trainingSet;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateNeuronet();

                CreateTeacher();

                CreateTrainingSet();

                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception: " + exc.Message, "Try once again");
            }            
        }

        private void CahngePathButton_Click(object sender, EventArgs e)
        {
            ChangePath();
        }

        private void ChangePath()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                while (fbd.ShowDialog() != DialogResult.OK)
                {
                    // disallow exit without choosing
                }

                PathTextBox.Text = fbd.SelectedPath;
            }
        }

        private void TrainingSpeedSelector_Scroll(object sender, EventArgs e)
        {
            CurrentTrainigSpeedLabel.Text = CalculateTrainingSpeed().ToString("F2");
        }
    }
}
