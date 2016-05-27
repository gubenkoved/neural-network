using System;
using System.Collections.Generic;
using System.Linq;
using NeuroNet.Core.Common;
using NeuroNet.Core.Teachers;

namespace NeuroNet.Core.Training.Algorithms
{
    public class RandomTrainingAlgorithm : TrainingAlgorithm
    {
        private int _ages;
        private Random _random = new Random();

        public RandomTrainingAlgorithm(Teacher teacher, int ages)
            : base(teacher)
        {
            _ages = ages;
        }


        public override void Teach(TrainingSet teachSet)
        {
            #region Create progress

            var progress = new TrainingProgressArgs { AmountOfAllPairs = _ages * teachSet.TrainingCollection.Count };

            #endregion

            int n = teachSet.TrainingCollection.Count;

            for (int age = 0; age < _ages; age++)
            {
                for (int i = 0; i < n; i++)
                {
                    TrainingPair trainingPair = teachSet.TrainingCollection[_random.Next(n)];

                    Teacher.Teach(trainingPair.Input, trainingPair.Answer);

                    #region Progress update

                    ++progress.AmountOfTrainedPairs;

                    OnProgressChanged(progress);

                    #endregion
                }
            }

            OnTrainingCompleted();
        }
    }
}