using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using NeuroNet.Core.Common;
using NeuroNet.Core.Teachers;
using NeuroNet.Core.Training.Algorithms;

namespace NeuroNet.Core.Training
{
    public class OnePairFromOneImageTrainingSet : TrainingSet
    {
        private Func<Color, double> _colorToSignalIntensityConverter;

        public OnePairFromOneImageTrainingSet(Teacher teacher, TrainingAlgorithm pairSelector) 
            : base(teacher, pairSelector)
        {
        }

        public void FillTeachCollection(string dirPath, int outputDimension, Func<Color, double> colorToSignalIntensityConverter)
        {
            _colorToSignalIntensityConverter = colorToSignalIntensityConverter;
            
            TrainingCollection = new List<TrainingPair>();

            foreach (var file in new DirectoryInfo(dirPath).GetFiles())
            {
                AddTeachPairFromFile(file, outputDimension);
            }
        }

        private double[] GetRightAnswer(FileInfo file, int outputDimension)
        {
            int rightAnswer = int.Parse(file.Name.Where(char.IsDigit).CreateString());

            return Helper.GenerateOutputVector(outputDimension, rightAnswer);
        }

        private void AddTeachPairFromFile(FileInfo file, int outputDimension)
        {
            Bitmap bitmap = new Bitmap(file.FullName);

            double[] d = GetRightAnswer(file, outputDimension);
            double[] x = new double[bitmap.Width * bitmap.Height];

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    x[i * bitmap.Width + j] = _colorToSignalIntensityConverter(bitmap.GetPixel(i, j));
                }
            }

            TrainingCollection.Add(new TrainingPair() {Input = x, Answer = d});
        }
    }
}