using System.Collections.Generic;

namespace NeuroNet.Core.Common
{
    public interface IHaveInputs
    {
        ICollection<Connector> Inputs { get; } 
    }
}