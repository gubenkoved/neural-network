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

        public BackpropagationTeacher(Neuronet network)
            : base(network)
        {
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
            int n = _outputLayer.Count;

            if (_inputLayer.Count != x.Length)
                throw new Exception($"Dimensions of input vector and amount of input neurons should match up");

            if (n != d.Length)
                throw new Exception($"Dimensions of output vector and amount of output neurons should match up");

            _neuronet.SetInput(x);

            double[] e = new double[n]; // error vector

            for (int i = 0; i < n; i++)
                e[i] = d[i] - _outputLayer[i].Signal;

            // local gradient map
            var lgMap = new Dictionary<Neuron, double>();

            // calculating local gradient for neurons in output layer

            for (int i = 0; i < _outputLayer.Count; i++)
            {
                Neuron neuron = _outputLayer[i];

                // value of the derivative of the activation-induced local field
                double afDerivative = neuron.ActivationFunction.CalculateDerivative(neuron.GetLocalField());

                lgMap[neuron] = e[i] * afDerivative;

                TeachNeuron(neuron, lgMap[neuron]);
            }

            // calculating local gradient for neurons in hidden layers

            for (int i = _hiddenLayers.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < _hiddenLayers[i].Count; j++)
                {
                    Neuron neuron = _hiddenLayers[i][j];

                    double afDerivative = neuron.ActivationFunction.CalculateDerivative(neuron.GetLocalField());

                    IEnumerable<Connector> inputConnectors;

                    if (_cellToInputConnectorsCache == null)
                        inputConnectors = _neuronet.Cells.GetConnectorsWhichHasCellAsInput(neuron);
                    else
                        inputConnectors = _cellToInputConnectorsCache[neuron];

                    double sumDeltaMultByW = inputConnectors.Sum(connector => connector.SynapticWeight * lgMap[connector.OutputCell as Neuron]);

                    lgMap[neuron] = afDerivative * sumDeltaMultByW;

                    TeachNeuron(neuron, lgMap[neuron]);
                }
            }

            _neuronet.RecalculateAllSignals();
        }

        #region Private methods
        /// <summary>
        /// Get cells which is input for cell in specified layer
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        private IEnumerable<Neuron> GetPreviousLayer(IEnumerable<Neuron> layer)
        {
            List<Neuron> currentLayer = layer.ToList();
            List<Neuron> previousLayer = new List<Neuron>();

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

            if (previousLayer.Count == 0)
                return null;

            return previousLayer;
        }

        private void FillLayers()
        {
            _inputLayer = new List<SignalSource>(_neuronet.Cells.OfType<SignalSource>());
            _outputLayer = new List<Neuron>(_neuronet.Cells.Where(n => n.CellType == CellType.Output).OfType<Neuron>());
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

            foreach (var hiddenCell in _neuronet.Cells.Where(c => c.CellType == CellType.Hidden))
            {
                _cellToInputConnectorsCache[hiddenCell] = _neuronet.Cells.GetConnectorsWhichHasCellAsInput(hiddenCell);
            }
        }

        private void TeachNeuron(Neuron neuron, double localGradient)
        {
            foreach (Connector connector in neuron.Inputs)
            {
                double y = connector.InputCell.Signal;

                connector.SynapticWeight += TeachingSpeed * localGradient * y;
            }
        }
        #endregion
    }
}
