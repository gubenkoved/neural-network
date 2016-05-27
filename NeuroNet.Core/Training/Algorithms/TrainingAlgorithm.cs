using System.Collections.Generic;
using System.Linq;
using NeuroNet.Core.Common;
using NeuroNet.Core.Teachers;

namespace NeuroNet.Core.Training.Algorithms
{
    public class TrainingProgressArgs
    {
        public double Progress
        {
            get { return (double) AmountOfTrainedPairs / AmountOfAllPairs; }
        }
        public int AmountOfTrainedPairs;
        public int AmountOfAllPairs;
    }

    public abstract class TrainingAlgorithm
    {
        public Teacher Teacher;

        protected TrainingAlgorithm(Teacher teacher )
        {
            Teacher = teacher;
        }

        public abstract void Teach(TrainingSet teachSet);

        public delegate void ProgressChangedHandler(object sender, TrainingProgressArgs e);
        public event ProgressChangedHandler ProgressChanged;

        public delegate void TrainingCompletedHandler(object sender);
        public event TrainingCompletedHandler TrainingCompleted;

        protected void OnProgressChanged(TrainingProgressArgs progress)
        {
            if (ProgressChanged != null)
                ProgressChanged(this, progress);
        }

        protected void OnTrainingCompleted()
        {
            if (TrainingCompleted != null)
                TrainingCompleted(this);
        }
    }
}