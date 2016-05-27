using System.Collections.Generic;
using System.Linq;
using NeuroNet.Core.Common;
using NeuroNet.Core.Teachers;

namespace NeuroNet.Core.Training.Algorithms
{
    public class SequentialTrainingAlgoritm : TrainingAlgorithm
    {
        private int _ages;

        public SequentialTrainingAlgoritm(Teacher teacher, int ages) 
            : base(teacher)
        {
            _ages = ages;
        }


        public override void Teach(TrainingSet teachSet)
        {
            #region Create progress

            var progress = new TrainingProgressArgs { AmountOfAllPairs = _ages * teachSet.TrainingCollection.Count };

            #endregion

            for (int age = 0; age < _ages; age++)
            {
                foreach (TrainingPair trainingPair in teachSet.TrainingCollection)
                {
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