using System;

namespace NeuroNet.Core.Common
{
    /// <summary>
    /// Objects that implement this interface is the connection between cells
    /// </summary>
    [Serializable]
    public class Connector
    {
        public Cell InputCell { get; set; }

        public Cell OutputCell { get; set; }

        public double SynapticWeight { get; set; }
    }
}