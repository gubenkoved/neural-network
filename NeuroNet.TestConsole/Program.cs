using NeuroNet.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroNet.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var nn = NeuronetWithInformation.Load(@"D:\Repos\NeuroNet\NeuroNet.Web\Neuronets\16x16.9000.150");
        }
    }
}
