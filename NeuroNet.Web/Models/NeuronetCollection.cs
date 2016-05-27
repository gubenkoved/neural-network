using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using NeuroNet.Core.Neuronets;
using NeuroNet.Core.Serialization;

namespace NeuroNet.Web.Models
{
    public class NeuronetCollection
    {
        public static bool Loaded;
        public static IDictionary<Guid, NeuronetWithInformation> Neuronets;

        static NeuronetCollection()
        {
            Task.Factory.StartNew(() =>
            {
                string neuronetsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                    "Neuronets");

                Neuronets = new Dictionary<Guid, NeuronetWithInformation>();

                var dirInfo = new DirectoryInfo(neuronetsPath);

                foreach (var neuronetFile in dirInfo.GetFiles())
                {
                    Neuronets[Guid.NewGuid()] =
                        NeuronetWithInformation.Load(neuronetFile.FullName);
                }

                Loaded = true;
            });
        }
    }
}