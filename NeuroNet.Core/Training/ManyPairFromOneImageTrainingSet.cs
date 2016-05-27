using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using NeuroNet.Core.Common;
using NeuroNet.Core.Teachers;
using NeuroNet.Core.Training.Algorithms;

namespace NeuroNet.Core.Training
{
    public class ManyPairFromOneImageTrainingSet : TrainingSet
    {
        private Func<Color, double> _colorToSignalIntensityConverter;

        public ManyPairFromOneImageTrainingSet(Teacher teacher, TrainingAlgorithm pairSelector) 
            : base(teacher, pairSelector)
        {
        }

        public void FillTeachCollection(string dirPath, int outputDimension, Func<Color, double> colorToSignalIntensityConverter, Size digitSize, int maxTrainingPairsPerImage = int.MaxValue)
        {
            _colorToSignalIntensityConverter = colorToSignalIntensityConverter;

            TrainingCollection = new List<TrainingPair>();

            foreach (var file in new DirectoryInfo(dirPath).GetFiles())
            {
                AddTeachPairFromFile(file, outputDimension, digitSize, maxTrainingPairsPerImage);
            }
        }

        private void AddTeachPairFromFile(FileInfo file, int outputDimension, Size digitSize, int maxTrainingPairsPerImage)
        {
            Bitmap bitmap = new Bitmap(file.FullName);

            int rightAnswer = int.Parse(file.Name.Where(char.IsDigit).CreateString());

            int xn = bitmap.Width / digitSize.Width;
            int yn = bitmap.Height / digitSize.Height;

            int fromImageAdded = 0;

            for (int i = 0; i < xn; i++)
            {
                for (int j = 0; j < yn; j++)
                {
                    AddTeachPairFromImage(
                        bitmap,
                        new Rectangle(i * digitSize.Width, j * digitSize.Height, digitSize.Width, digitSize.Height),
                        outputDimension,
                        rightAnswer);

                    ++fromImageAdded;

                    if (fromImageAdded >= maxTrainingPairsPerImage)
                        return;
                }
            }
        }

        private void AddTeachPairFromImage(Bitmap bitmap, Rectangle rect, int dimension, int rightAnswer)
        {
            double[] d = Helper.GenerateOutputVector(dimension, rightAnswer);
            double[] x = new double[rect.Width * rect.Height];

            int pixelNum = 0;

            for (int i = rect.X; i < rect.X + rect.Width; i++)
            {
                for (int j = rect.Y; j < rect.Y + rect.Height; j++)
                {
                    x[pixelNum++] = _colorToSignalIntensityConverter(bitmap.GetPixel(i, j));
                }
            }

            // filtering images without stable digit
            if (!x.All(intensity => Math.Abs(intensity) < 0.1))
                TrainingCollection.Add(new TrainingPair() {Input = x, Answer = d});
        }

    }
}