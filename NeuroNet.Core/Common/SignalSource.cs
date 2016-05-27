using System;

namespace NeuroNet.Core.Common
{
    /// <summary>
    /// Singnal source is simple cell which just generating signal with a given intensity
    /// </summary>
    [Serializable]
    public class SignalSource : Cell, IAllowToSetSignal
    {
        public SignalSource(double signalIntensity = 0.0)
        {
            Signal = signalIntensity;
            
            CellType = CellType.Input;
        }

        public void SetSignal(double signalIntensity)
        {
            Signal = signalIntensity;
        }

        public override void RecalculateSignal()
        {
            // this is signal source reculculate is not required
        }
    }
}
