using System;

namespace NeuroNet.Core.ActivationFunctions
{
    [Serializable]
    public class SigmoidActivationFunction : ActivationFunction
    {
        [NonSerialized]
        private Func<double, double> _sigmoid; 

        private readonly double _alpha;

        public SigmoidActivationFunction(double alpha = 1.0)
        {
            _alpha = alpha;

            _sigmoid = (x => 1.0 / (1.0 + Math.Exp(-_alpha * x)));
        }

        public override double Calculate(double inputIntensity)
        {
            EnsureSigmoid();

            return _sigmoid(inputIntensity);
        }

        public override double CalculateDerivative(double inputIntensity)
        {
            EnsureSigmoid();

            return _alpha * _sigmoid(inputIntensity) * (1 - _sigmoid(inputIntensity));
        }

        private void EnsureSigmoid()
        {
            if (_sigmoid == null)
            {
                _sigmoid = (x => 1.0 / (1.0 + Math.Exp(-_alpha * x)));
            }
        }
    }
}