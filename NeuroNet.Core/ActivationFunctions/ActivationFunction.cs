using System;

namespace NeuroNet.Core.ActivationFunctions
{
    /// <summary>
    /// Neuron activization function
    /// </summary>
    [Serializable]
    public abstract class ActivationFunction
    {
        public abstract double Calculate(double inputIntensity);

        public abstract double CalculateDerivative(double inputIntensity);
    }
}