using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using NeuroNet.Core.Common;

namespace NeuroNet.Core.Neuronets
{
    /// <summary>
    /// Base of each neuro-network class
    /// </summary>
    [Serializable]
    public abstract class Neuronet
    {
        /// <summary>
        /// Collection of all cells in neuronet
        /// </summary>
        public IEnumerable<Cell> Cells { get; protected set; }

        /// <summary>
        /// Set input vector
        /// </summary>
        /// <param name="inputVector"></param>
        public abstract void SetInput(double[] inputVector);

        /// <summary>
        /// Successively recalculate the signals of neurons in layers starting with the first hidden layer
        /// </summary>
        public abstract void RecalculateAllSignals();

        /// <summary>
        /// Get the network answer as vector
        /// </summary>
        public virtual double[] GetAnswer()
        {
            return Cells.Where(c => c.CellType == CellType.Output)
                .Select(c => c.Signal).ToArray();
        }
    }
}
