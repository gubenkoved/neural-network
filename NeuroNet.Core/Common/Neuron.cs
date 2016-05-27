using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NeuroNet.Core.ActivationFunctions;

namespace NeuroNet.Core.Common
{
    [Serializable]
    public class Neuron : Cell, IHaveInputs
    {
        public ICollection<Connector> Inputs { get; private set; }

        public ActivationFunction ActivationFunction { get; private set; }        

        public Neuron(ActivationFunctionType activationFunctionType = ActivationFunctionType.Sigmoid)
        {
            // get reference on instance of activation function

            ActivationFunction = ActivationFunctionLib.GetInstanceByType(activationFunctionType);

            // setting default cell type

            CellType = CellType.Hidden;            

            // add bias connector

            Inputs = new Collection<Connector> { this.CreateBiasConnector().RandomizeWeight(-0.5, 0.5) };
        }

        /// <summary>
        /// Returns the argument of activation function
        /// </summary>
        public double GetLocalField()
        {
            return Inputs.Aggregate(0.0,
                                    (intensity, connector) =>
                                    intensity + connector.SynapticWeight * connector.InputCell.Signal);
        }

        public override void RecalculateSignal()
        {
            Signal = ActivationFunction.Calculate(GetLocalField());
        }
    }
}
