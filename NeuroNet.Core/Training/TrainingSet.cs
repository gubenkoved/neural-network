using System.Collections.Generic;
using NeuroNet.Core.Common;
using NeuroNet.Core.Teachers;
using NeuroNet.Core.Training.Algorithms;
using System.Linq;

namespace NeuroNet.Core.Training
{
    

    public abstract class TrainingSet
    {
        public IList<TrainingPair> TrainingCollection { get; protected set; }
        public TrainingAlgorithm TrainingAlgorithm { get; private set; }
        public Teacher Teacher { get; private set; }

        protected TrainingSet(Teacher teacher, TrainingAlgorithm pairSelector)
        {
            TrainingAlgorithm = pairSelector;
            Teacher = teacher;
        }

        public void Teach()
        {
            TrainingAlgorithm.Teach(this);
        }
    }
}