using System;

namespace NeuroNet.Core.ActivationFunctions
{
    [Serializable]
    public class SigmoidActivationFunction : ActivationFunction
    {
        private readonly double _alpha;

        public SigmoidActivationFunction(double alpha = 1.0)
        {
            _alpha = alpha;
        }

        public override double Calculate(double inputIntensity)
        {
            return Sigmoid(inputIntensity);
        }

        public override double CalculateDerivative(double inputIntensity)
        {
            return _alpha * Sigmoid(inputIntensity) * (1 - Sigmoid(inputIntensity));
        }

        private double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-_alpha * x));
        }
    }
}