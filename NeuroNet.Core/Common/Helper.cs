using System;
using System.Collections.Generic;
using System.Linq;
using NeuroNet.Core.Neuronets;

namespace NeuroNet.Core.Common
{
    public static class Helper
    {
        /// <summary>
        /// Create the bias connector. Source signal will be +1
        /// </summary>
        /// <param name="thisCell">Cell which we adding connector</param>
        /// <param name="synapticWeight">Synaptic weight</param>
        /// <returns></returns>
        public static Connector CreateBiasConnector(this Cell thisCell, double synapticWeight = 0.0)
        {
            return new Connector()
            {
                OutputCell = thisCell,
                InputCell = new SignalSource(1.0), 
                SynapticWeight = synapticWeight
            };
        }

        /// <summary>
        /// Creates cell connector.
        /// </summary>
        /// <param name="thisCell">Current cell</param>
        /// <param name="inputCell">Cell which be connected with this cell</param>
        /// <param name="synapticWeight">Synaptic weight</param>
        /// <returns></returns>
        public static Connector CreateCellConnector(this Cell thisCell, Cell inputCell, double synapticWeight = 0.0)
        {
            return new Connector()
            {
                OutputCell = thisCell,
                InputCell = inputCell,
                SynapticWeight = synapticWeight
            };
        }

        public static readonly Random Random = new Random(Environment.TickCount);

        public static Connector RandomizeWeight(this Connector connector, double min = 0.0, double max = 0.1)
        {
            connector.SynapticWeight = min + Random.NextDouble() * (max - min);

            return connector;
        }

        public static IEnumerable<Connector> GetConnectorsWhichHasCellAsInput(this IEnumerable<Cell> cells, Cell cell)
        {
            var connectors = new List<Connector>();

            foreach (var c in cells.OfType<IHaveInputs>())
            {
                var connector = c.Inputs.FirstOrDefault(i => i.InputCell == cell);

                if (connector != null)
                    connectors.Add(connector);
            }

            return connectors;
        }

        /// <summary>
        /// Calculating the error energy.
        /// </summary>
        /// <param name="d">Right answer</param>
        /// <param name="y">Network answer</param>
        /// <returns>Error energy</returns>
        public static double CalculateErrorEnergy(double[] d, double[] y)
        {
            if (d.Length != y.Length)
                throw new Exception("Dimensions must be equal");

            int n = d.Length;

            double energy = 0.0;

            for (int i = 0; i < n; i++)
            {
                energy += 0.5 * Math.Pow(d[i] - y[i], 2.0);
            }

            return energy;
        }

        /// <summary>
        /// Return vector with given size and 1.0 in double[k]
        /// </summary>
        /// <param name="size">Vector size</param>
        /// <param name="k">Position of the vector which contains 1.0</param>
        /// <returns></returns>
        public static double[] GenerateOutputVector(int size, int k)
        {
            double[] vector = new double[size];

            vector[k] = 1.0;

            return vector;
        }

        public static int AmountOfHiddenNeurons(this Neuronet neuronet)
        {
            return neuronet.Cells.Count(c => c.CellType == CellType.Hidden);
        }
    }
}
