using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NeuroNet.Desktop
{
    public partial class NetworkDigitAnswerVisualizator : UserControl
    {
        public Color ActiveColor = Color.Red;
        public Color InactiveColor = Color.White;

        public NetworkDigitAnswerVisualizator()
        {
            InitializeComponent();
        }

        private Color GetColor(double intensity)
        {
            int a = (int)(intensity * ActiveColor.A) + (int)((1.0 - intensity) * InactiveColor.A);
            int r = (int)(intensity * ActiveColor.R) + (int)((1.0 - intensity) * InactiveColor.R);
            int g = (int)(intensity * ActiveColor.G) + (int)((1.0 - intensity) * InactiveColor.G);
            int b = (int)(intensity * ActiveColor.B) + (int)((1.0 - intensity) * InactiveColor.B);

            return Color.FromArgb(a, r, g, b);
        }

        public void VisualizeAnswer(double[] answer)
        {
            // normalize answer
            for (int i = 0; i < 10; i++)
            {
                answer[i] = (answer[i] - answer.Min()) / (answer.Max() - answer.Min());
            }

            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0:
                        Digit0Label.ForeColor = GetColor(answer[i]);
                        break;
                    case 1:
                        Digit1Label.ForeColor = GetColor(answer[i]);
                        break;
                    case 2:
                        Digit2Label.ForeColor = GetColor(answer[i]);
                        break;
                    case 3:
                        Digit3Label.ForeColor = GetColor(answer[i]);
                        break;
                    case 4:
                        Digit4Label.ForeColor = GetColor(answer[i]);
                        break;
                    case 5:
                        Digit5Label.ForeColor = GetColor(answer[i]);
                        break;
                    case 6:
                        Digit6Label.ForeColor = GetColor(answer[i]);
                        break;
                    case 7:
                        Digit7Label.ForeColor = GetColor(answer[i]);
                        break;
                    case 8:
                        Digit8Label.ForeColor = GetColor(answer[i]);
                        break;
                    case 9:
                        Digit9Label.ForeColor = GetColor(answer[i]);
                        break;
                }
            }
        }
    }
}
