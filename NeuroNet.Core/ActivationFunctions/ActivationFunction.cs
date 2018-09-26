using System;

namespace NeuroNet.Core.ActivationFunctions
{
    /// <summary>
    /// Neuron activation function
    /// </summary>
    [Serializable]
    public abstract class ActivationFunction
    {
        public abstract double Calculate(double inputIntensity);

        public abstract double CalculateDerivative(double inputIntensity);
    }
}