using System;
using System.Collections.Generic;
using System.Linq;
using NeuroNet.Core.Common;

namespace NeuroNet.Core.Neuronets
{
    /// <summary>
    /// Fully connected n-tire perceptron
    /// </summary>
    [Serializable]
    public class NTirePerceptron : Neuronet
    {
        private int _amountOfHiddenLayers;

        public IEnumerable<SignalSource> Input { get; private set; }

        public IEnumerable<Neuron> Output { get; private set; }

        public IEnumerable<Neuron>[] Hidden { get; private set; }

        private NTirePerceptron()
        {
            
        }

        public static NTirePerceptron Create(int numberOfInputs, int numberOfOutputs, int[] numberOfNeuronInHiddenLayers)
        {
            int n = numberOfNeuronInHiddenLayers.Length;

            #region Creating cells
            IEnumerable<SignalSource> input = new List<SignalSource>();
            IEnumerable<Neuron> output = new List<Neuron>();
            IEnumerable<Neuron>[] hidden = new List<Neuron>[n];

            numberOfInputs.Times(() => input
                .As<IList<SignalSource>>()
                .Add(new SignalSource()));

            numberOfOutputs.Times(() => output
                .As<IList<Neuron>>()
                .Add(new Neuron { CellType = CellType.Output }));

            n.Times(k =>
                        {
                            hidden[k] = new List<Neuron>();
                            numberOfNeuronInHiddenLayers[k].Times(
                                () => hidden[k]
                                          .As<IList<Neuron>>()
                                          .Add(new Neuron { CellType = CellType.Hidden}));
                        });
            #endregion

            #region Creating connectors
            // union of all n + 2 layer for easy creating connectors
            var allLayers = new IEnumerable<Cell>[n + 2];

            allLayers[0] = input;
            allLayers[n + 1] = output;

            n.Times( i => allLayers[i + 1] = hidden[i]);

            for (int i = n + 1; i > 0; i--)
            {
                int currentLayer = i;
                int previousLayer = i - 1;

                foreach (var outputCell in allLayers[currentLayer])
                {
                    foreach (var inputCell in allLayers[previousLayer])
                    {
                        outputCell
                            .As<IHaveInputs>()
                            .Inputs
                            .Add(outputCell.CreateCellConnector(inputCell).RandomizeWeight(-0.5, 0.5));
                    }
                }
            }
            #endregion
            
            return new NTirePerceptron
                       {
                           _amountOfHiddenLayers = n,
                           Input = input, 
                           Hidden = hidden, 
                           Output = output,
                           Cells = allLayers.UnionArray()
                       };
        }

        public override void SetInput(double[] inputVector)
        {
            int inputCount = Input.Count();

            if (inputVector.GetLength(0) != inputCount)
            {
                throw new Exception("Dimensions of input vector and " +
                                    "amount of input of network must be equal");
            }

            for (int i = 0; i < inputCount; i++)
            {
                Input.ToList()[i].SetSignal(inputVector[i]);
            }

            RecalculateAllSignals();
        }

        public override void RecalculateAllSignals()
        {
            _amountOfHiddenLayers
                .Times(i =>
                           {
                               foreach (var neuron in Hidden[i])
                               {
                                   neuron.RecalculateSignal();
                               }
                           });


            foreach (var neuron in Output)
            {
                neuron.RecalculateSignal();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}-tire perceptron with {1} hidden nuerons", Hidden.Length + 2,
                                 this.AmountOfHiddenNeurons());
        }
    }
}