using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NeuroNet.Core.Serialization;
using NeuroNet.Core.Common;

namespace NeuroNet.Desktop
{
    public partial class NeuronetInfoViewer : Form
    {
        private NeuronetWithInformation _neuronetWithInfo;

        public NeuronetInfoViewer(NeuronetWithInformation neuronetWithInfo )
        {
            InitializeComponent();

            _neuronetWithInfo = neuronetWithInfo;

            RenderInformation();
        }

        private void RenderInformation()
        {
            ImageSizeLabel.Text = string.Format("{0}x{1}", _neuronetWithInfo.ImageSize.Width,
                                                _neuronetWithInfo.ImageSize.Height);

            TrainingTimeLabel.Text = string.Format("{0:hh\\:mm\\:ss}", _neuronetWithInfo.TrainingTime);


            AmountOfHiddenNeuronsLabel.Text = _neuronetWithInfo.Neuronet.AmountOfHiddenNeurons().ToString();

            if (_neuronetWithInfo.AdditionalInformation != null)
            {
                foreach (var keyValuePair in _neuronetWithInfo.AdditionalInformation)
                {
                    AdditionalInfoList.Items.Add(string.Format("{0}:{1}", keyValuePair.Key, keyValuePair.Value));
                }
            }
        }
    }
}
