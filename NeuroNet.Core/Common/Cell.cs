using System;

namespace NeuroNet.Core.Common
{
    [Serializable]
    public abstract class Cell
    {
        public double Signal;

        public abstract void RecalculateSignal();

        public CellType CellType = CellType.Unknown;
    }
}