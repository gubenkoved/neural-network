using System;
using NeuroNet.Core.Neuronets;

namespace NeuroNet.Core.Teachers
{
    public abstract class Teacher
    {
        protected Neuronet _neuronet;

        /// <summary>
        /// Teach the network
        /// </summary>
        /// <param name="x">Input vector</param>
        /// <param name="d">Right network answer</param>
        public abstract void Teach(double[] x, double[] d);

        public Teacher(Neuronet neuronet)
        {
            if (neuronet == null)
                throw new ArgumentNullException(nameof(neuronet));

            _neuronet = neuronet;
        }
    }
}