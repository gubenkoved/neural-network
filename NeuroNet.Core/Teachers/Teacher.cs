using NeuroNet.Core.Neuronets;

namespace NeuroNet.Core.Teachers
{
    public abstract class Teacher
    {
        /// <summary>
        /// Teach the network
        /// </summary>
        /// <param name="x">Input vector</param>
        /// <param name="d">Right network answer</param>
        public abstract void Teach(double[] x, double[] d);

        public Neuronet Neuronet;
    }
}