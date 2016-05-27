using System;

namespace NeuroNet.Core.ActivationFunctions
{
    public enum ActivationFunctionType
    {
        Sigmoid
    }

    public static class ActivationFunctionLib
    {
        public static ActivationFunction Sigmoid = new SigmoidActivationFunction();

        public static ActivationFunction GetInstanceByType(ActivationFunctionType type)
        {
            switch (type)
            {
                case ActivationFunctionType.Sigmoid:
                    return Sigmoid;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
