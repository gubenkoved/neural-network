using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuroNet.Core.Common;
using NeuroNet.Core.Neuronets;
using NeuroNet.Core.Serialization;
using NeuroNet.Core.Teachers;
using NeuroNet.Core.Training;
using NeuroNet.Core.Training.Algorithms;

namespace NeuroNet.Desktop
{
    public partial class MainForm : Form
    {
        private NeuronetWithInformation _neuronetWithInfo;
        private TrainingSet _trainingSet;

        private Thread _trainingThread;
        private DateTime _startTrainingTime;

        public MainForm()
        {
            InitializeComponent();

            PaintBoard.RecognizeRequest += RecognizeRequestReceived;
        }

        private void CreateNeuronetButton_Click(object sender, EventArgs e)
        {
            using (var creator = new CreateNeuronetForm())
            {
                creator.ShowDialog();

                _neuronetWithInfo = creator.NeuronetWithInfo;
                _trainingSet = creator.TrainingSet;

                PaintBoard.XResolution = _neuronetWithInfo.ImageSize.Width;
                PaintBoard.YResolution = _neuronetWithInfo.ImageSize.Height;
                
                creator.TrainingAlgorithm.ProgressChanged += TrainingProgressChanged;
                creator.TrainingAlgorithm.TrainingCompleted += TrainingCompleted;

                TeachByTrainingSetButton.Enabled = true;
                SaveButton.Enabled = true;

                CreateNeuronetButton.Enabled = false;
                LoadButton.Enabled = false;
                InfoButton.Enabled = true;
            }
        }

        private void TeachByImgButton_Click(object sender, EventArgs e)
        {
            _startTrainingTime = DateTime.Now;

            TeachByTrainingSet();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveNetwork();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadNetwork();

            PaintBoard.XResolution = _neuronetWithInfo.ImageSize.Width;
            PaintBoard.YResolution = _neuronetWithInfo.ImageSize.Height;

            TeachByTrainingSetButton.Enabled = false;
            CreateNeuronetButton.Enabled = false;
            LoadButton.Enabled = false;
            InfoButton.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_trainingThread != null)
            {
                _trainingThread.Abort();
            }

            if (SaveButton.Enabled)
            {
                if (MessageBox.Show("Do you want to save network?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveNetwork();
                }
            }
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            using (var infoViewer = new NeuronetInfoViewer(_neuronetWithInfo))
            {
                infoViewer.ShowDialog();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////

        private void TrainingProgressChanged(object sender, TrainingProgressArgs e)
        {
            Action d = delegate
            {
                ProgressBar.Value = (int)(e.Progress * 100);
                ProgressLabel.Text = string.Format("{0}/{1}",
                    e.AmountOfTrainedPairs, e.AmountOfAllPairs);
            };

            Invoke(d);
        }

        private void TrainingCompleted(object sender)
        {
            _trainingThread = null;

            _neuronetWithInfo.TrainingTime = DateTime.Now - _startTrainingTime;
        }

        private void RecognizeRequestReceived(object sender)
        {
            GetAnswer();
        }

        private void SaveNetwork()
        {
            using (var sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _neuronetWithInfo.Save(sfd.FileName);
                }
            }
        }

        private void LoadNetwork()
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _neuronetWithInfo = NeuronetWithInformation.Load(ofd.FileName);
                }
            }
        }

        private void TeachByTrainingSet()
        {
            if (_trainingThread == null)
            {
                _trainingThread = new Thread(_trainingSet.Teach);

                _trainingThread.Start();
            }
        }

        private void GetAnswer()
        {
            if (_neuronetWithInfo != null && _trainingThread == null)
            {
                _neuronetWithInfo.Neuronet.SetInput(PaintBoard.ImageAsVector);

                NetworkDigitAnswerVisualizator.VisualizeAnswer(_neuronetWithInfo.Neuronet.GetAnswer());
            }
        }

        

        
    }
}
