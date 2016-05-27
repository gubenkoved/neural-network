using System;
using System.Collections.Generic;
using System.Linq;
using NeuroNet.Core.Common;
using NeuroNet.Core.Neuronets;

namespace NeuroNet.Core.Teachers
{
    public class BackpropagationTeacher : Teacher
    {
        private List<SignalSource> _inputLayer;
        private List<Neuron> _outputLayer;
        private List<List<Neuron>> _hiddenLayers;
        private Dictionary<Cell, IEnumerable<Connector>> _cellToInputConnectorsCache;

        /// <summary>
        /// Number in range (0.0, 1.0]
        /// </summary>
        public double TeachingSpeed = 0.08;

        /// <summary>
        /// Get cells which is input for cell in specified layer
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        private IEnumerable<Neuron> GetPreviousLayer(IEnumerable<Neuron> layer)
        {
            var currentLayer = layer.ToList();
            var previousLayer = new List<Neuron>();

            foreach (Neuron neuron in currentLayer)
            {
                foreach (var inputCellConnector in neuron.Inputs)
                {
                    if (inputCellConnector.InputCell is Neuron)
                    {
                        if (!previousLayer.Contains(inputCellConnector.InputCell))
                        {
                            previousLayer.Add(inputCellConnector.InputCell as Neuron);
                        }
                    }
                }
            }

            if (previousLayer.Count != 0)
                return previousLayer;
            else
                return null;
        }

        private void FillLayers()
        {
            _inputLayer = new List<SignalSource>(Neuronet.Cells.OfType<SignalSource>());
            _outputLayer = new List<Neuron>(Neuronet.Cells.Where(n => n.CellType == CellType.Output).OfType<Neuron>());
            _hiddenLayers = new List<List<Neuron>>();

            // filling hidden layers
            IEnumerable<Neuron> currentLayer = _outputLayer;
            IEnumerable<Neuron> previousLayer = null;

            while ((previousLayer = GetPreviousLayer(currentLayer)) != null)
            {
                currentLayer = previousLayer;

                _hiddenLayers.Add(currentLayer.ToList());
            }

            _hiddenLayers.Reverse();
        }

        private void FillCellToInputConnectorsCache()
        {
            _cellToInputConnectorsCache = new Dictionary<Cell, IEnumerable<Connector>>();

            foreach (var hiddenCell in Neuronet.Cells.Where(c => c.CellType == CellType.Hidden))
            {
                _cellToInputConnectorsCache[hiddenCell] = Neuronet.Cells.GetConnectorsWhichHasCellAsInput(hiddenCell);

            }
        }

        private void TeachNeuron(Neuron neuron, double localGradient)
        {
            foreach (var connector in neuron.Inputs)
            {
                double y = connector.InputCell.Signal;

                connector.SynapticWeight += TeachingSpeed * localGradient * y;
            }
        }

        public BackpropagationTeacher(Neuronet network)
        {
            Neuronet = network;

            FillLayers();
            
            FillCellToInputConnectorsCache();
        }

        /// <summary>
        /// Backpropagation algorithm implementation
        /// </summary>
        /// <param name="x">Input vector</param>
        /// <param name="d">True answer vector</param>
        public override void Teach(double[] x, double[] d)
        {
            if (_inputLayer.Count != x.GetLength(0)
                || _outputLayer.Count != d.GetLength(0))
            {
                throw new Exception("Dimensions of input and output vector " +
                                    "have to be equals number of input and " +
                                    "output cells in neuronetwork");
            }

            Neuronet.SetInput(x);

            // real output
            double[] y = new double[_outputLayer.Count];
            
            _outputLayer.Count.Times(i => y[i] = _outputLayer[i].Signal);

            // error vector
            double[] e = new double[_outputLayer.Count];

            _outputLayer.Count.Times(i => e[i] = d[i] - y[i]);

            
            // local gradient map
            var lgMap = new Dictionary<Neuron, double>();

            // calculating local gradient for neurons in output layer

            for (int i = 0; i < _outputLayer.Count; i++)
            {
                var neuron = _outputLayer[i];

                // value of the derivative of the activation-induced local field
                var afDerivative = neuron.ActivationFunction.CalculateDerivative(neuron.GetLocalField());

                lgMap[neuron] = e[i] * afDerivative;

                TeachNeuron(neuron, lgMap[neuron]);
            }

            // calculating local gradient for neurons in hidden layers

            for (int i = _hiddenLayers.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < _hiddenLayers[i].Count; j++)
                {
                    var neuron = _hiddenLayers[i][j];

                    var afDerivative = neuron.ActivationFunction.CalculateDerivative(neuron.GetLocalField());

                    IEnumerable<Connector> inputConnectors;

                    if (_cellToInputConnectorsCache == null)
                        inputConnectors = Neuronet.Cells.GetConnectorsWhichHasCellAsInput(neuron);
                    else
                        inputConnectors = _cellToInputConnectorsCache[neuron];

                    var sumDeltaMultByW = inputConnectors.Sum(connector => connector.SynapticWeight * lgMap[connector.OutputCell as Neuron]);

                    lgMap[neuron] = afDerivative * sumDeltaMultByW;

                    TeachNeuron(neuron, lgMap[neuron]);
                }
            }

            Neuronet.RecalculateAllSignals();
        }
    }
}
